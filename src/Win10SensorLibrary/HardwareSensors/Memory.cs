using System;
using System.Diagnostics;

namespace mqttclient.HardwareSensors
{
    public static class Memory
    {
        public static string GetFreeMemory()
        {
            try
            {
                var ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                return ramCounter.NextValue() + "MB";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}