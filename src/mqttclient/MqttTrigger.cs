using System;
using System.Xml.Serialization;

namespace mqttclient
{
    [XmlRoot(ElementName = "mqtttriggers")]
    public class MqttTrigger
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CmdText { get; set; }
        public string CmdParameters { get; set; }
        public Boolean Predefined { get; set; }
    }
}
