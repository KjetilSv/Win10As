namespace mqttclient.Mqtt
{
    public interface IMqtt
    {
        string GMqtttopic { get; set; }
        bool IsConnected { get; }

        bool Connect(string hostname, int portNumber, string username, string password);
        void Disconnect();
        string FullTopic(string topic);
        void LoadTriggerlist();
        void Publish(string topic, string message, bool retain = false);
        void PublishByte(string topic, byte[] bytes);
        void PublishImage(string topic, string file);
    }
}