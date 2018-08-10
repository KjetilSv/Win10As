using System;
using System.IO;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace mqttclient
{
    public class Mqtt
    {
        private MqttClient _client;

        public string GMqtttopic { get; set; }

        public bool IsConnected => _client.IsConnected;

        public void PublishImage(string topic, string file)
        {
            if (_client.IsConnected == true)
            {
                _client.Publish(SetSubTopic(topic), File.ReadAllBytes(file));
            }
        }

        public void PublishByte(string topic, byte[] bytes)
        {
            _client.Publish(SetSubTopic(topic), bytes);
        }

        public void Publish(string topic, string message, bool retain = false)
        {
            if (_client.IsConnected == true)
            {
                if (retain == true)
                {

                    _client.Publish(topic, Encoding.UTF8.GetBytes(message), 0, retain);
                }
                else
                {
                    _client.Publish(topic, Encoding.UTF8.GetBytes(message));
                }
            }
        }

        public void MqttConnect(string hostname, int portNumber, string username, string password)
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
                        throw new Exception("not connected,check connection settings error:" + ex.Message);
                    }

                    try
                    {
                        if (_client.IsConnected == true)
                        {
                            GMqtttopic = Properties.Settings.Default["mqtttopic"].ToString() + "/#";
                            //_client.MqttMsgPublishReceived += _frmMqttMain.client_MqttMsgPublishReceived;
                            //_client.ConnectionClosed += _frmMqttMain.client_MqttConnectionClosed;
                            //_client.Subscribe(new string[] { GMqtttopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                            //_frmMqttMain.toolStripStatusLabel1.Text = "connected";
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

        }

        public string SetSubTopic(string topic)
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
    }
}