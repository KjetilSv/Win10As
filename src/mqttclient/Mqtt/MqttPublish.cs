using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using mqttclient.HardwareSensors;

namespace mqttclient.Mqtt
{
    public class MqttPublish : IMqttPublish
    {
        private readonly IAudio _audioobj;
        private readonly IMqtt _mqtt;
        private readonly string GLocalScreetshotFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "primonitor.jpg");

        public MqttPublish(IMqtt mqtt, IAudio audio)
        {
            _mqtt = mqtt;
            _audioobj = audio;
        }

        public void PublishSystemData()
        {
            if (_mqtt.IsConnected == false)
            {
                _mqtt.Connect(Properties.Settings.Default["mqttserver"].ToString(),
                    Convert.ToInt32(Properties.Settings.Default["mqttport"].ToString()),
                    Properties.Settings.Default["mqttusername"].ToString(),
                    Properties.Settings.Default["mqttpassword"].ToString());
            }

            if (_mqtt.IsConnected == true)
            {
                if (Convert.ToBoolean(Properties.Settings.Default["IsComputerUsed"].ToString()))
                {
                    PublishStatus();
                }
                if (Convert.ToBoolean(Properties.Settings.Default["Cpusensor"].ToString()) == true)
                {
                    try
                    {
                        _mqtt.Publish("cpuprosessortime", Processor.GetCpuProcessorTime());
                    }
                    catch (Exception)
                    {
                        //we ignore 
                    }
                }

                if (Convert.ToBoolean(Properties.Settings.Default["Freememorysensor"].ToString()) == true)
                {
                    _mqtt.Publish("freememory", Memory.GetFreeMemory());
                }

                if (Convert.ToBoolean(Properties.Settings.Default["Volumesensor"].ToString()) == true)
                {
                    PublishAudio();
                }

                if (Convert.ToBoolean(Properties.Settings.Default["screenshotenable"]) == true)
                {
                    PublishScreenshot(Properties.Settings.Default["ScreenShotpath"].ToString());
                }

                if (Convert.ToBoolean(Properties.Settings.Default["MqttSlideshow"].ToString()) == true)
                {
                    if (Properties.Settings.Default["MqttSlideshowFolder"].ToString().Length > 5)
                    {
                        string folder = @Properties.Settings.Default["MqttSlideshowFolder"].ToString();
                        MqttCameraSlide(folder);
                    }
                }

                if (Convert.ToBoolean(Properties.Settings.Default["BatterySensor"].ToString()) == true)
                {
                    PublishBattery();
                }

                if (Convert.ToBoolean(Properties.Settings.Default["DiskSensor"].ToString()) == true)
                {
                    PublishDiskStatus();
                }
            }
        }

        private void PublishAudio()
        {
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
                _mqtt.Publish("", "on");
            }
            else
            {
                _mqtt.Publish("", "off");
            }
            
        }

        private void PublishBattery()
        {
            _mqtt.Publish("Power/BatteryChargeStatus", Power.BatteryChargeStatus());
            _mqtt.Publish("Power/BatteryFullLifetime", Power.BatteryFullLifetime());
            _mqtt.Publish("Power/BatteryLifePercent", Power.BatteryLifePercent());
            _mqtt.Publish("Power/BatteryLifeRemaining", Power.BatteryLifeRemaining());
            _mqtt.Publish("Power/PowerLineStatus", Power.PowerLineStatus());
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

                    _mqtt.Publish("drive/" + rawdrivename + "/totalsize", drive.TotalSize.ToString());
                    _mqtt.Publish("drive/" + rawdrivename + "/percentfree", Convert.ToString(Math.Round(Convert.ToDouble(percentFree.ToString()), 0)));
                    _mqtt.Publish("drive/" + rawdrivename + "/availablefreespace", drive.AvailableFreeSpace.ToString());
                }
            }
            catch (Exception)
            {
                // throw;
            }

        }

        private bool NetworkUp()
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

        private void PublishScreenshot(string fileUri)
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

                            if (Convert.ToBoolean(Properties.Settings.Default["ScreenshotMqtt"]) == true)
                            {
                                bmpScreenshot.Save(GLocalScreetshotFile, ImageFormat.Png);
                                _mqtt.PublishImage("mqttcamera", GLocalScreetshotFile);
                            }
                            else
                            {
                                bmpScreenshot.Save(fileUri, ImageFormat.Jpeg);
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void MqttCameraSlide(string folder)
        {
            var rand = new Random();
            var files = Directory.GetFiles(folder, "*.jpg");
            string topic = "slideshow";
            _mqtt.PublishByte(topic, File.ReadAllBytes(files[rand.Next(files.Length)]));
        }
    }
}