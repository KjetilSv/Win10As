using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqttclient
{
    public static class MqttSettings
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
            set => Properties.Settings.Default["mqttport"] = value.ToString(CultureInfo.CurrentCulture);
        }
        internal static void Init()
        {
            Properties.Settings.Default.Upgrade();
        }
        public static string MqttTimerInterval
        {
            get => (string)Properties.Settings.Default["mqtttimerinterval"];
            set => Properties.Settings.Default["mqtttimerinterval"] = value.ToString(CultureInfo.CurrentCulture);
        }
        public static bool ScreenshotEnable
        {
            get => (bool)Properties.Settings.Default["screenshotenable"];
            set => Properties.Settings.Default["screenshotenable"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static string ScreenShotPath
        {
            get => (string)Properties.Settings.Default["ScreenShotpath"];
            set => Properties.Settings.Default["ScreenShotpath"] = value;
        }
        public static bool MinimizeToTray
        {
            get => (bool)Properties.Settings.Default[nameof(MinimizeToTray)];
            set => Properties.Settings.Default[nameof(MinimizeToTray)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool MqttSlideshow
        {
            get => (bool)Properties.Settings.Default[nameof(MqttSlideshow)];
            set => Properties.Settings.Default[nameof(MqttSlideshow)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static string MqttSlideshowFolder
        {
            get => (string)Properties.Settings.Default[nameof(MqttSlideshowFolder)];
            set => Properties.Settings.Default[nameof(MqttSlideshowFolder)] = value;
        }
        public static bool CpuSensor
        {
            get => (bool)Properties.Settings.Default["Cpusensor"];
            set => Properties.Settings.Default["Cpusensor"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool FreeMemorySensor
        {
            get => (bool)Properties.Settings.Default["Freememorysensor"];
            set => Properties.Settings.Default["Freememorysensor"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool VolumeSensor
        {
            get => (bool)Properties.Settings.Default["Volumesensor"];
            set => Properties.Settings.Default["Volumesensor"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool IsComputerUsed
        {
            get => (bool)Properties.Settings.Default[nameof(IsComputerUsed)];
            set => Properties.Settings.Default[nameof(IsComputerUsed)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture),CultureInfo.CurrentCulture);
        }
        public static bool BatterySensor
        {
            get => (bool)Properties.Settings.Default[nameof(BatterySensor)];
            set => Properties.Settings.Default[nameof(BatterySensor)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool DiskSensor
        {
            get => (bool)Properties.Settings.Default[nameof(DiskSensor)];
            set => Properties.Settings.Default[nameof(DiskSensor)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static bool EnableWebCamPublish
        {
            get => (bool)Properties.Settings.Default[nameof(EnableWebCamPublish)];
            set => Properties.Settings.Default[nameof(EnableWebCamPublish)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static string WebCamToPublish
        {
            get => (string)Properties.Settings.Default[nameof(WebCamToPublish)];
            set => Properties.Settings.Default[nameof(WebCamToPublish)] = value.ToString(CultureInfo.CurrentCulture);
        }
        public static bool EnableTTS
        {
            get => (bool)Properties.Settings.Default[nameof(EnableTTS)];
            set => Properties.Settings.Default[nameof(EnableTTS)] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static string TTSSpeaker { get; internal set; }
        public static Boolean Monitor
        {
            get => (Boolean)Properties.Settings.Default["CmdMonitor"];
            set => Properties.Settings.Default["CmdMonitor"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Toast
        {
            get => (Boolean)Properties.Settings.Default["CmdToast"];
            set => Properties.Settings.Default["CmdToast"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean App
        {
            get => (Boolean)Properties.Settings.Default["CmdApp"];
            set => Properties.Settings.Default["CmdApp"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Tts
        {
            get => (Boolean)Properties.Settings.Default["CmdTts"];
            set => Properties.Settings.Default["CmdTts"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Hibernate
        {
            get => (Boolean)Properties.Settings.Default["CmdHibernate"];
            set => Properties.Settings.Default["CmdHibernate"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Shutdown
        {
            get => (Boolean)Properties.Settings.Default["CmdShutdown"];
            set => Properties.Settings.Default["CmdShutdown"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Reboot
        {
            get => (Boolean)Properties.Settings.Default["CmdReboot"];
            set => Properties.Settings.Default["CmdReboot"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Suspend
        {
            get => (Boolean)Properties.Settings.Default["CmdSuspend"];
            set => Properties.Settings.Default["CmdSuspend"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Mute
        {
            get => (Boolean)Properties.Settings.Default["CmdMute"];
            set => Properties.Settings.Default["CmdMute"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        public static Boolean Volume
        {
            get => (Boolean)Properties.Settings.Default["CmdVolume"];
            set => Properties.Settings.Default["CmdVolume"] = Convert.ToBoolean(value.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
        }
        internal static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
