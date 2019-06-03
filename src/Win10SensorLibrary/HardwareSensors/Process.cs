using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace mqttclient
{
    public static class Process
    {
        public static string IsRunning(string exename, string location)
        {
            try
            {
                bool isRunning = System.Diagnostics.Process.GetProcessesByName(exename)
                                        .FirstOrDefault(p => p.MainModule.FileName.StartsWith(location)) != default(System.Diagnostics.Process);
                if (isRunning == true)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public static string Close(string exename)
        {
            try
            {
                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName(exename))
                {
                    proc.Kill();
                }
                return "1";
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
}