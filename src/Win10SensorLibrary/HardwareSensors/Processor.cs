using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace mqttclient.HardwareSensors
{
    public static class Processor
    {
        public static string GetCpuProcessorTime()
        {
            try
            {
                var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                Thread.Sleep(1000);

                string t = Convert.ToString(Math.Round(Convert.ToDecimal(cpuCounter.NextValue().ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture), 2), CultureInfo.CurrentCulture);

                return t + "%";

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}