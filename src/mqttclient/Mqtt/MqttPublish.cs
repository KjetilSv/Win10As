using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using mqttclient.HardwareSensors;
using Newtonsoft.Json;

namespace mqttclient.Mqtt
{
    public class MqttPublish : IMqttPublish
    {
        private readonly IAudio _audioobj;
        private readonly IMqtt _mqtt;
        private readonly string GLocalScreetshotFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "primonitor.jpg");
        private readonly string GLocalWebcamFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "webcam.png");
        public MqttPublish(IMqtt mqtt, IAudio audio)
        {
            _mqtt = mqtt;
            _audioobj = audio;
        }
        public void PublishSystemData()
        {
            if (_mqtt.IsConnected == false)
            {
                _mqtt.Connect(MqttSettings.MqttServer, MqttSettings.MqttPort, MqttSettings.MqttUsername, MqttSettings.MqttPassword);
            }

            if (_mqtt.IsConnected == true)
            {
                if (MqttSettings.IsComputerUsed)
                {
                    PublishStatus();
                }
                if (MqttSettings.CpuSensor)
                {

                    _mqtt.Publish("cpuprosessortime", Processor.GetCpuProcessorTime());

                }
                if (MqttSettings.FreeMemorySensor)
                {
                    _mqtt.Publish("freememory", Memory.GetFreeMemory());
                }
                if (MqttSettings.VolumeSensor)
                {
                    PublishAudio();
                }
                if (MqttSettings.MqttSlideshow)
                {
                    if (Properties.Settings.Default["MqttSlideshowFolder"].ToString().Length > 5)
                    {
                        string folder = @Properties.Settings.Default["MqttSlideshowFolder"].ToString();
                        MqttCameraSlide(folder);
                    }
                }
                if (MqttSettings.BatterySensor)
                {
                    PublishBattery();
                }
                if (MqttSettings.DiskSensor)
                {
                    PublishDiskStatus();
                }
                if (MqttSettings.EnableWebCamPublish)
                {
                    PublishCamera();
                }
                if (MqttSettings.ScreenshotEnable)
                {
                    PublishScreenshot();
                }
            }
        }
        private void PublishAudio(bool DiscoveryPacket = false)
        {

            if (DiscoveryPacket == true)
            {
                string fullltopic = _mqtt.FullTopic("switch/mute");
                MqttConfig _MqttConfig = new MqttConfig();
                _MqttConfig.device_class = "switch";
                _MqttConfig.name = MqttSettings.MqttTopic + "switch-mute";
                _MqttConfig.state_topic = fullltopic + "/set";
                string configTopic = "switch/mute/config";
                string ConfigPayload = JsonConvert.SerializeObject(_MqttConfig, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                _mqtt.Publish(configTopic, ConfigPayload);
            }



            _mqtt.Publish("volume", _audioobj.GetVolume(), true);

            try
            {
                if (_audioobj.IsMuted() == true)
                {
                    _mqtt.Publish("mute", "1");
                }
                else
                {
                    _mqtt.Publish("mute", "0");
                }
            }
            catch (Exception)
            {
            }
        }
        private void PublishStatus()
        {
            if (UsingComputer.IsUsing())
            {
                _mqtt.Publish("binary_sensor/inUse", "on");
            }
            else
            {
                _mqtt.Publish("binary_sensor/inUse", "off");
            }

        }
        private void PublishBattery()
        {
            //_mqtt.Publish("Power/BatteryChargeStatus", Power.BatteryChargeStatus());
            //_mqtt.Publish("Power/BatteryFullLifetime", Power.BatteryFullLifetime());
            //_mqtt.Publish("Power/BatteryLifePercent", Power.BatteryLifePercent());
            //_mqtt.Publish("Power/BatteryLifeRemaining", Power.BatteryLifeRemaining());
            //_mqtt.Publish("Power/PowerLineStatus", Power.PowerLineStatus());
        }
        private void PublishDiskStatus()
        {
            try
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    double freeSpace = drive.TotalFreeSpace;
                    double totalSpace = drive.TotalSize;
                    double percentFree = (freeSpace / totalSpace) * 100;
                    float num = (float)percentFree;

                    string rawdrivename = drive.Name.Replace(":\\", "");

                    _mqtt.Publish("drive/" + rawdrivename + "/totalsize", drive.TotalSize.ToString(CultureInfo.CurrentCulture));
                    _mqtt.Publish("drive/" + rawdrivename + "/percentfree", Convert.ToString(Math.Round(Convert.ToDouble(percentFree.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture), 0), CultureInfo.CurrentCulture));
                    _mqtt.Publish("drive/" + rawdrivename + "/availablefreespace", drive.AvailableFreeSpace.ToString(CultureInfo.CurrentCulture));
                }
            }
            catch (Exception)
            {
                // throw;
            }

        }
        private static bool NetworkUp()
        {

            try
            {
                return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            }
            catch (Exception)
            {
                return false;
            }

        }
        private void PublishScreenshot()
        {
            try
            {
                if (NetworkUp() == true)
                {
                    using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
                    {
                        using (var gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                        {
                            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);


                            bmpScreenshot.Save(GLocalScreetshotFile, ImageFormat.Png);
                            _mqtt.PublishImage("screenshot", GLocalScreetshotFile);

                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private void PublishCamera()
        {
            try
            {
                if (HardwareSensors.Camera.Save(GLocalWebcamFile))
                {
                    _mqtt.PublishImage("webcamera", GLocalWebcamFile);

                }
                else
                {

                    MessageBox.Show($"Failed to save image");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void MqttCameraSlide(string folder)
        {
            var rand = new Random();
            var files = Directory.GetFiles(folder, "*.jpg");
            string topic = "slideshow";
            _mqtt.PublishByte(topic, File.ReadAllBytes(files[rand.Next(files.Length)]));
        }
        public void DiscoveryMessage(string topic, string Message)
        {

            _mqtt.Publish(topic, Message);

        }
    }
}