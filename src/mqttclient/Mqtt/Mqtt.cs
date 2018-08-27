using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows.UI.Notifications;
using mqttclient.HardwareSensors;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqttclient.Mqtt
{
    public class Mqtt : IMqtt
    {
        private readonly IToastMessage _toastMessage;
        private readonly IAudio _audio;
        private readonly ILogger _logger;
        private MqttClient _client;

        public string GMqtttopic { get; set; }

        public bool IsConnected
        {
            get
            {
                if (_client == null)
                    return false;
                return _client.IsConnected;
            }
        }


        private readonly string _gTriggerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "triggers.json");
        BindingList<MqttTrigger> MqttTriggerList = new BindingList<MqttTrigger>();

        #region monitor onoff
        public class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MONITORPOWER = 0xF170;
        private const int MonitorTurnOn = -1;
        private const int MonitorShutoff = 2;

        #endregion

        public Mqtt(IAudio audio, IToastMessage toastMessage, ILogger logger)
        {
            _audio = audio;
            _toastMessage = toastMessage;
            _logger = logger;

            LoadTriggerList();
        }

        public void PublishImage(string topic, string file)
        {
            if (_client.IsConnected == true)
            {
                _client.Publish(FullTopic(topic), File.ReadAllBytes(file));
            }
        }

        public void PublishByte(string topic, byte[] bytes)
        {
            _client.Publish(FullTopic(topic), bytes);
        }

        public void Publish(string topic, string message, bool retain = false)
        {
            var fullTopic = FullTopic(topic);
            if (_client.IsConnected == true)
            {
                if (retain == true)
                {

                    _client.Publish(fullTopic, Encoding.UTF8.GetBytes(message), 0, retain);
                }
                else
                {
                    _client.Publish(fullTopic, Encoding.UTF8.GetBytes(message));
                }
            }
        }

        public bool Connect(string hostname, int portNumber, string username, string password)
        {
            if (IsConnected)
            {
                _client.Disconnect();
            }

            try
            {
                if (!hostname.IsEmptyOrWhitespaced())
                {
                    try
                    {
                        _client = new MqttClient(hostname, portNumber, false, null, null, MqttSslProtocols.None, null);

                        if (username.IsEmptyOrWhitespaced())
                        {
                            byte code = _client.Connect(Guid.NewGuid().ToString());
                        }
                        else
                        {
                            byte code = _client.Connect(Guid.NewGuid().ToString(), username, password);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("not connected, check connection settings error:" + ex.Message);
                    }

                    try
                    {
                        if (_client.IsConnected == true)
                        {
                            GMqtttopic = Properties.Settings.Default["mqtttopic"].ToString() + "/#";
                            _client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                            _client.MqttMsgSubscribed += client_MqttMsgSubscribed;
                            _client.MqttMsgPublished += client_MqttMsgPublished;
                            //_client.ConnectionClosed += client_MqttConnectionClosed;

                            LoadTriggerList();
                            string[] topics = GetTopicsFromTriggerList();
                            byte[] qos = GetQos(topics.Length);

                            _client.Subscribe(topics, qos);

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("not connected,check mqtt setup error:" + ex.Message);
                    }
                }
                else
                {
                    throw new Exception("not connected, check settings mqttservername not entered");
                }
            }

            catch (Exception ex)
            {
                throw new Exception("not connected,check settings. Error:" + ex.InnerException.ToString());
            }
            return false;
        }

        private byte[] GetQos(int topicsLength)
        {
            byte[] qos = new byte[topicsLength];
            for (int i = 0; i < topicsLength; i++)
            {
                qos[i] = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE;
            }

            return qos;
        }

        private string[] GetTopicsFromTriggerList()
        {
            string[] topicsList = new string[MqttTriggerList.Count];
            int i = 0;
            foreach (var trigger in MqttTriggerList)
            {
                topicsList[i] = FullTopic(trigger.Name);
                i++;
            }

            return topicsList;
        }

        public string FullTopic(string topic)
        {
            return GMqtttopic.Replace("#", topic);
        }

        public void Disconnect()
        {
            if (_client != null)
            {
                if (IsConnected)
                {
                    _client.Disconnect();
                }
            }
        }

        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            try
            {
                _logger.Log("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            }
            catch (Exception ex)
            {
                _logger.Log("error: " + ex.Message);
            }

        }
        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            try
            {
                _logger.Log("Subscribed for id = " + e.MessageId);
            }
            catch (Exception ex)
            {
                _logger.Log("error: " + ex.Message);
            }

        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string message = Encoding.UTF8.GetString(e.Message);
                MqttTrigger currentMqttTrigger = new MqttTrigger();
                _logger.Log("Message recived " + e.Topic + " value " + message);

                string TopLevel = GMqtttopic.Replace("/#", "");
                string subtopic = e.Topic.Replace(TopLevel + "/", "");

                switch (subtopic)
                {
                    case "app/running":
                        Publish("app/running/" + message, Process.IsRunning(message, ""));
                        break;

                    case "app/close":
                        Publish("app/running/" + message, Process.Close(message));
                        break;

                    case "monitor/set":
                        using (var f = new Form())
                        {
                            if (message == "1")
                            {
                                NativeMethods.SendMessage(f.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MonitorTurnOn);
                                Publish("monitor", "1");
                            }
                            else
                            {
                                NativeMethods.SendMessage(f.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MonitorShutoff);
                                Publish("monitor", "0");
                            }
                        }
                        break;

                    case "mute/set":
                        if (message == "1" || message == "on")
                        {
                            _audio.Mute(true);
                        }
                        else
                        {
                            _audio.Mute(false);
                        }
                        Publish("mute", message);
                        break;

                    case "volume/set":
                        _audio.Volume(Convert.ToInt32(message));
                        break;

                    case "hibernate":
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                        break;

                    case "suspend":
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                        break;

                    case "reboot":
                        System.Diagnostics.Process.Start("shutdown.exe", $"-r -t {GetDelay(message)}");
                        break;

                    case "shutdown":
                        System.Diagnostics.Process.Start("shutdown.exe", $"-s -t {GetDelay(message)}");
                        break;

                    case "tts":
                        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                        synthesizer.Volume = 100;  // 0...100
                        synthesizer.SpeakAsync(message);
                        break;

                    case "toast":
                        string[] words = message.Split(',');
                        if (words.Length >= 3)
                        {
                            string imageUrl = words[words.Length - 1];
                            _toastMessage.ShowImage(words, imageUrl);
                        }
                        else
                        {
                            _toastMessage.ShowText(words);
                        }
                        break;

                    default:
                        if (currentMqttTrigger.CmdText.Length > 2)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo(currentMqttTrigger.CmdText);
                            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                            if (currentMqttTrigger.CmdParameters.Length > 2)
                            {
                                startInfo.Arguments = currentMqttTrigger.CmdParameters;
                            }
                            System.Diagnostics.Process.Start(startInfo);
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                //_logger.Log("error: " + ex.Message);
            }

        }

        private int GetDelay(string message)
        {
            var result = Int32.TryParse(message, out var delay);
            if (result)
            {
                return delay;
            }
            else
            {
                return 10;
            }
        }
        

        public void LoadTriggerList()
        {
            if (File.Exists(_gTriggerFile))
            {
                string s = File.ReadAllText(_gTriggerFile);
                BindingList<MqttTrigger> deserializedProduct = JsonConvert.DeserializeObject<BindingList<MqttTrigger>>(s);
                MqttTriggerList = deserializedProduct;

            }
        }
    }
}