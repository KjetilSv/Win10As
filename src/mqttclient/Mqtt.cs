using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using Windows.UI.Notifications;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqttclient
{
    public class Mqtt
    {
        private readonly ToastMessage _toastMessage = new ToastMessage();
        private readonly Audio _audioobj = new Audio();

        private MqttClient _client;

        public string GMqtttopic { get; set; }

        public bool IsConnected => _client.IsConnected;

        
        private string GTriggerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "triggers.json");
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

        public Mqtt()
        {
            LoadTriggerlist();
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
            try
            {
                if (hostname.Length > 3)
                {
                    try
                    {
                        _client = new MqttClient(hostname, portNumber, false, null, null, MqttSslProtocols.None, null);

                        if (username.Length > 3)
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
                            //_client.ConnectionClosed += client_MqttConnectionClosed;
                            _client.Subscribe(new string[] { GMqtttopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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
                //WriteToLog("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            }
            catch (Exception ex)
            {
                //WriteToLog("error: " + ex.Message);
            }

        }
        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            try
            {
                //WriteToLog("Subscribed for id = " + e.MessageId);
            }
            catch (Exception ex)
            {
                //WriteToLog("error: " + ex.Message);
            }

        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string message = Encoding.UTF8.GetString(e.Message);
                MqttTrigger currentMqttTrigger = new MqttTrigger();
                //WriteToLog("Message recived " + e.Topic + " value " + message);

                string TopLevel = Properties.Settings.Default["mqtttopic"].ToString().Replace("/#", "");
                string subtopic = e.Topic.Replace(TopLevel + "/", "");

                foreach (MqttTrigger tmpTrigger in MqttTriggerList)
                {
                    if (tmpTrigger.Name == subtopic)
                    {
                        currentMqttTrigger = tmpTrigger;
                        currentMqttTrigger.Id = 1;
                        break;
                    }
                }

                if (currentMqttTrigger.Id == 1)
                {

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

                            if (message == "1")
                            {
                                _audioobj.Mute(true);
                            }
                            else
                            {
                                _audioobj.Mute(false);
                            }

                            Publish("mute", message);
                            break;
                        case "mute":
                            break;
                        case "volume":
                            break;
                        case "volume/set":
                            _audioobj.Volume(Convert.ToInt32(message));
                            break;
                        case "hibernate":
                            Application.SetSuspendState(PowerState.Hibernate, true, true);
                            break;
                        case "suspend":
                            Application.SetSuspendState(PowerState.Suspend, true, true);
                            break;
                        case "reboot":
                            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 10");
                            break;
                        case "shutdown":
                            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 10");
                            break;
                        case "tts":
                            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                            // synthesizer.GetInstalledVoices

                            synthesizer.Volume = 100;  // 0...100
                            synthesizer.SpeakAsync(message);
                            break;
                        case "toast":

                            int i = 0;

                            string Line1 = "";
                            string Line2 = "";
                            string Line3 = "";
                            string FileURI = "";

                            string[] words = message.Split(',');
                            foreach (string word in words)
                            {

                                switch (i)
                                {
                                    case 0:
                                        Line1 = word;
                                        break;
                                    case 1:
                                        Line2 = word;
                                        break;
                                    case 2:
                                        Line3 = word;
                                        break;
                                    case 3:
                                        FileURI = word;
                                        break;
                                    default:
                                        break;
                                }
                                i = i + 1;
                            }
                            _toastMessage.Toastmessage(Line1, Line2, Line3, FileURI, ToastTemplateType.ToastImageAndText04);


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

            }
            catch (Exception ex)
            {
                //WriteToLog("error: " + ex.Message);

            }

        }

        public void LoadTriggerlist()
        {
            if (File.Exists(GTriggerFile))
            {
                string s = File.ReadAllText(GTriggerFile);
                BindingList<MqttTrigger> deserializedProduct = JsonConvert.DeserializeObject<BindingList<MqttTrigger>>(s);
                MqttTriggerList = deserializedProduct;

            }
        }
    }
}