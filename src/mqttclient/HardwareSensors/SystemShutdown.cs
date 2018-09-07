using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mqttclient.Mqtt;
using Microsoft.Win32;

namespace mqttclient.HardwareSensors
{
    public class SystemShutdown
    {
        private readonly IMqtt _mqtt;

        public SystemShutdown(IMqtt mqtt)
        {
            _mqtt = mqtt;
        }

        public void Subscribe()
        {
            SystemEvents.SessionEnding += (sender, args) => _mqtt.Publish("", "off", true);
        }

    }
}
