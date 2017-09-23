using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

//namespace Win_Mqtt_Client
//{
    //public class HardwareSensors
//    {
//        public static string GetFreeMemory()
//        {
//            try
//            {
//                PerformanceCounter ramCounter;
//                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
//                return ramCounter.NextValue() + "MB";
//            }
//            catch (Exception)
//            {

//                throw;
//            }

//        }
//        public static string GetCpuProsessorTime()
//        {
//            try
//            {
//                PerformanceCounter cpuCounter;
//                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
//                cpuCounter.NextValue();
//                Thread.Sleep(1000);

//                string t = Convert.ToString(Math.Round(Convert.ToDecimal(cpuCounter.NextValue().ToString()), 2));

//                return t + "%";

//            }
//            catch (Exception)
//            {

//                throw;
//            }

//        }
//    }
//}
