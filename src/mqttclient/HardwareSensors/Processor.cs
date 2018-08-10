using System;
using System.Diagnostics;
using System.Threading;

namespace mqttclient
{
    public class Processor
    {
        public static string GetCpuProcessorTime()
        {
            try
            {
                var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                Thread.Sleep(1000);

                string t = Convert.ToString(Math.Round(Convert.ToDecimal(cpuCounter.NextValue().ToString()), 2));

                return t + "%";

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}