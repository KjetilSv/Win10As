using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mqttclient
{
    [XmlRoot(ElementName = "mqtttriggers")]
    public class mqtttrigger
    {
        public long id { get; set; }
        public string name { get; set; }
        public string cmdtext { get; set; }
        public string cmdparameters { get; set; }
        public Boolean Predefined { get; set; }
    }
}
