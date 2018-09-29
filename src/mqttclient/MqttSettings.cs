using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqttclient
{
    public class MqttSettings
    {
        public static string MqttServer
        {
            get => (string)Properties.Settings.Default["mqttserver"];
            set => Properties.Settings.Default["mqttserver"] = value;
        }

        public static string MqttUsername
        {
            get => (string)Properties.Settings.Default["mqttusername"];
            set => Properties.Settings.Default["mqttusername"] = value;
        }

        public static string MqttPassword
        {
            get => (string)Properties.Settings.Default["mqttpassword"];
            set => Properties.Settings.Default["mqttpassword"] = value;
        }

        public static string MqttTopic
        {
            get => (string)Properties.Settings.Default["mqtttopic"];
            set => Properties.Settings.Default["mqtttopic"] = value;
        }

        public static int MqttPort
        {
            get => (int)Properties.Settings.Default["mqttport"];
            set => Properties.Settings.Default["mqttport"] = value.ToString();
        }

        public static string MqttTimerInterval
        {
            get => (string)Properties.Settings.Default["mqtttimerinterval"];
            //{
            //    if (string.IsNullOrEmpty(Properties.Settings.Default["mqtttimerinterval"].ToString()))
            //    {
            //        Properties.Settings.Default["mqtttimerinterval"] = 6000;
            //        Properties.Settings.Default.Save();
            //    }
            //    => (Int)Properties.Settings.Default["mqtttimerinterval"];
            //}

            set => Properties.Settings.Default["mqtttimerinterval"] = value.ToString();
        }

        public static bool ScreenshotEnable
        {
            get => (bool)Properties.Settings.Default["screenshotenable"];
            set => Properties.Settings.Default["screenshotenable"] = Convert.ToBoolean(value.ToString());
        }

        public static bool ScreenshotMqtt
        {
            get => (bool)Properties.Settings.Default["ScreenshotMqtt"];
            set => Properties.Settings.Default["ScreenshotMqtt"] = Convert.ToBoolean(value.ToString());
        }

        public static string ScreenShotPath
        {
            get => (string)Properties.Settings.Default["ScreenShotpath"];
            set => Properties.Settings.Default["ScreenShotpath"] = value;
        }

        public static bool MinimizeToTray
        {
            get => (bool)Properties.Settings.Default["MinimizeToTray"];
            set => Properties.Settings.Default["MinimizeToTray"] = Convert.ToBoolean(value.ToString());
        }

        public static bool MqttSlideshow
        {
            get => (bool)Properties.Settings.Default["MqttSlideshow"];
            set => Properties.Settings.Default["MqttSlideshow"] = Convert.ToBoolean(value.ToString());
        }

        public static string MqttSlideshowFolder
        {
            get => (string)Properties.Settings.Default["MqttSlideshowFolder"];
            set => Properties.Settings.Default["MqttSlideshowFolder"] = value;
        }

        public static bool CpuSensor
        {
            get => (bool)Properties.Settings.Default["Cpusensor"];
            set => Properties.Settings.Default["Cpusensor"] = Convert.ToBoolean(value.ToString());
        }

        public static bool FreeMemorySensor
        {
            get => (bool)Properties.Settings.Default["Freememorysensor"];
            set => Properties.Settings.Default["Freememorysensor"] = Convert.ToBoolean(value.ToString());
        }

        public static bool VolumeSensor
        {
            get => (bool)Properties.Settings.Default["Volumesensor"];
            set => Properties.Settings.Default["Volumesensor"] = Convert.ToBoolean(value.ToString());
        }

        public static bool IsComputerUsed
        {
            get => (bool)Properties.Settings.Default["IsComputerUsed"];
            set => Properties.Settings.Default["IsComputerUsed"] = Convert.ToBoolean(value.ToString());
        }

        public static bool BatterySensor
        {
            get => (bool)Properties.Settings.Default["BatterySensor"];
            set => Properties.Settings.Default["BatterySensor"] = Convert.ToBoolean(value.ToString());
        }
        public static bool DiskSensor
        {
            get => (bool)Properties.Settings.Default["DiskSensor"];
            set => Properties.Settings.Default["DiskSensor"] = value.ToString();
        }
        public static bool EnableWebCamPublish
        {
            get => (bool)Properties.Settings.Default["EnableWebCamPublish"];
            set => Properties.Settings.Default["EnableWebCamPublish"] = Convert.ToBoolean(value.ToString());
        }
        public static string WebCamToPublish
        {
            get => (string)Properties.Settings.Default["WebCamToPublish"];
            set => Properties.Settings.Default["WebCamToPublish"] = value.ToString();
        }
        public static bool EnableTTS
        {
            get => (bool)Properties.Settings.Default["EnableTTS"];
            set => Properties.Settings.Default["EnableTTS"] = Convert.ToBoolean(value.ToString());
        }

        


        public static string TTSSpeaker { get; internal set; }

        internal static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
