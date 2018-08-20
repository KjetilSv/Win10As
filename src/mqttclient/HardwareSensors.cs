using System;
using System.Diagnostics;
using System.Threading;
using AudioSwitcher.AudioApi.CoreAudio;

namespace mqttclient
{
    public class HardwareSensors
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
        public static string GetCpuProsessorTime()
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
    public class Audio
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

        public void Mute(Boolean Enable)
        {
            try
            {
                defaultPlaybackDevice.Mute(Enable);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public Boolean IsMuted()
        {
            try
            {
                return defaultPlaybackDevice.IsMuted;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void Volume(int level)
        {
            try
            {
                defaultPlaybackDevice.Volume = Convert.ToDouble(level);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string GetVolume()
        {
            try
            {
                return defaultPlaybackDevice.Volume + "%";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
    public class Power
    {

        public static string BatteryChargeStatus()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
        }


        public static string BatteryFullLifetime()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryFullLifetime.ToString();
        }

        public static string BatteryLifePercent()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryLifePercent.ToString();
        }

        public static string BatteryLifeRemaining()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryLifeRemaining.ToString();
        }

        public static string PowerLineStatus()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus.ToString();
        }

    }
}

