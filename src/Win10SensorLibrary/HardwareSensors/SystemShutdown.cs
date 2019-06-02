using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace mqttclient.HardwareSensors
{
    public class SystemShutdown
    {
        public void Subscribe()
        {
           // SystemEvents.SessionEnding += (sender, args) => _mqtt.Publish("", "off", true);
        }

    }
}
