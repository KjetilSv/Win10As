using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using mqttclient.HardwareSensors;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Monitor = mqttclient.HardwareSensors.Monitor;

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

        public Mqtt(IAudio audio, IToastMessage toastMessage, ILogger logger)
        {
            _audio = audio;
            _toastMessage = toastMessage;
            _logger = logger;
        }

        public void PublishImage(string topic, string file)
        {
            if (_client.IsConnected)
            {
                if (File.Exists(file))
                {
                    _client.Publish(FullTopic(topic), File.ReadAllBytes(file));
                }

            }
        }

        public void PublishByte(string topic, byte[] bytes)
        {
            _client.Publish(FullTopic(topic), bytes);
        }

        public void Publish(string topic, string message, bool retain = false)
        {
            var fullTopic = FullTopic(topic);
            if (_client.IsConnected)
            {
                if (retain)
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
            if (!TryConnection(hostname, portNumber, username, password))
            {
                throw new Exception("Cannot connect to MQTT broker. Check connection data");
            }

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
                        if (_client.IsConnected)
                        {
                            GMqtttopic = Properties.Settings.Default["mqtttopic"].ToString() + "/#";
                            _client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
                            _client.MqttMsgSubscribed += ClientMqttMsgSubscribed;
                            _client.MqttMsgPublished += ClientMqttMsgPublished;
                            _client.ConnectionClosed += ClientMqttConnectionClosed;

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

        public bool TryConnection(string hostname, int portNumber, string username, string password)
        {
            try
            {
                var client = new MqttClient(hostname, portNumber, false, null, null, MqttSslProtocols.None, null);

                if (!username.IsEmptyOrWhitespaced())
                {
                    byte code = client.Connect(Guid.NewGuid().ToString());
                }
                else
                {
                    byte code = client.Connect(Guid.NewGuid().ToString(), username, password);
                }
                client.Disconnect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
            var mqttTriggerList = GetTriggerList();
            string[] topicsList = new string[mqttTriggerList.Count];
            int i = 0;
            foreach (var trigger in mqttTriggerList)
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

        private void ClientMqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
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

        private void ClientMqttConnectionClosed(object sender, System.EventArgs e)
        {
            try
            {
                _logger.Log("Mqtt Connection closed");
            }
            catch (Exception ex)
            {
                _logger.Log("error: " + ex.Message);
            }

        }

        private void ClientMqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
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

        private void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string message = Encoding.UTF8.GetString(e.Message);
                _logger.Log("Message recived " + e.Topic + " value " + message);

                string TopLevel = GMqtttopic.Replace("/#", "");
                string subtopic = e.Topic.Replace(TopLevel + "/", "");

                MessageReceived(subtopic, message);

            }
            catch (Exception ex)
            {
                _logger.Log("error: " + ex.Message);
            }

        }

        private void MessageReceived(string subtopic, string message)
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
                    if (message == "1" || message == "on")
                    {
                        Monitor.TurnOn();
                        Publish("monitor", "1");
                    }
                    else if (message == "0" || message == "off")
                    {
                        Monitor.TurnOff();
                        Publish("monitor", "0");
                    }
                    break;

                case "mute/set":
                    if (message == "1" || message == "on")
                    {
                        _audio.Mute(true);
                    }
                    else if (message == "0" || message == "off")
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
                    synthesizer.Volume = 100; // 0...100
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
                    MqttTrigger currentMqttTrigger = new MqttTrigger();
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


        public BindingList<MqttTrigger> GetTriggerList()
        {
            if (File.Exists(_gTriggerFile))
            {
                string s = File.ReadAllText(_gTriggerFile);
                return JsonConvert.DeserializeObject<BindingList<MqttTrigger>>(s);
            }
            return new BindingList<MqttTrigger>();
        }
    }
}