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
            get => (string) Properties.Settings.Default["mqttserver"];
            set => Properties.Settings.Default["mqttserver"] = value;
        }

        public static string MqttUsername
        {
            get => (string)Properties.Settings.Default["mqttusername"];
            set => Properties.Settings.Default["mqttusername"] = value;
        }

        public string MqttPassword
        {
            get => (string) Properties.Settings.Default["mqttpassword"];
            set => Properties.Settings.Default["mqttpassword"] = value;
        }

        public static string MqttTopic
        {
            get => (string) Properties.Settings.Default["mqtttopic"];
            set => Properties.Settings.Default["mqtttopic"] = value;
        }

        public static int MqttTimerInterval
        {
            get => (int)Properties.Settings.Default["mqtttimerinterval"];
            set => Properties.Settings.Default["mqtttimerinterval"] = value.ToString();
        }

        public static bool ScreenshotEnable
        {
            get => (bool)Properties.Settings.Default["screenshotenable"];
            set => Properties.Settings.Default["screenshotenable"] = value.ToString();
        }

        public static bool ScreenshotMqtt
        {
            get => (bool) Properties.Settings.Default["ScreenshotMqtt"];
            set => Properties.Settings.Default["ScreenshotMqtt"] = value.ToString();
        }

        public static string ScreenShotPath
        {
            get => (string)Properties.Settings.Default["ScreenShotpath"];
            set => Properties.Settings.Default["ScreenShotpath"] = value;
        }

        public static bool MinimizeToTray
        {
            get => (bool)Properties.Settings.Default["MinimizeToTray"];
            set => Properties.Settings.Default["MinimizeToTray"] = value.ToString();
        }

        public static bool MqttSlideshow
        {
            get => (bool)Properties.Settings.Default["MqttSlideshow"];
            set => Properties.Settings.Default["MqttSlideshow"] = value.ToString();
        }

        public static string MqttSlideshowFolder
        {
            get => (string) Properties.Settings.Default["MqttSlideshowFolder"];
            set => Properties.Settings.Default["MqttSlideshowFolder"] = value;
        }

        public static bool CpuSensor
        {
            get => (bool)Properties.Settings.Default["Cpusensor"];
            set => Properties.Settings.Default["Cpusensor"] = value.ToString();
        }

        public static bool FreeMemorySensor
        {
            get => (bool)Properties.Settings.Default["Freememorysensor"];
            set => Properties.Settings.Default["Freememorysensor"] = value.ToString();
        }

        public static bool VolumeSensor
        {
            get => (bool)Properties.Settings.Default["Volumesensor"];
            set => Properties.Settings.Default["Volumesensor"] = value.ToString();
        }
    }
}
