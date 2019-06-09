
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace mqttclient
{
    public partial class FrmOptions : Form
    {
        public string TriggerFile { get; set; }
        public FrmMqttMain ParentForm { get; set; }
        public FrmOptions(FrmMqttMain Mainform)
        {

            InitializeComponent();
            ParentForm = Mainform;
            TriggerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "triggers.json");
            LoadSettings();
            if (txtmqtttopic.TextLength == 0)
            {
                txtmqtttopic.Text = System.Environment.MachineName;
            }

            if (txtMqttTimerInterval.TextLength == 0)
            {
                txtMqttTimerInterval.Text = "60000";
            }

            if (txtmqtttopic.Text.Contains("#") == true)
            {
                txtmqtttopic.Text = txtmqtttopic.Text.Replace("/#", "");
                Properties.Settings.Default["mqtttopic"] = txtmqtttopic.Text;
                Properties.Settings.Default.Save();
            }
            LoadAudioDevices();

        }
        private void LoadSettings()
        {
            txtmqttserver.Text = MqttSettings.MqttServer;
            txtmqttusername.Text = MqttSettings.MqttUsername;
            txtmqttpassword.Text = MqttSettings.MqttPassword;
            txtmqtttopic.Text = MqttSettings.MqttTopic;
            txtMqttTimerInterval.Text = MqttSettings.MqttTimerInterval.ToString(CultureInfo.CurrentCulture);
            ChkBatterySensor.Checked = MqttSettings.BatterySensor;
            ChkDiskSensor.Checked = MqttSettings.DiskSensor;
            chkCpuSensor.Checked = MqttSettings.CpuSensor;
            chkMemorySensor.Checked = MqttSettings.FreeMemorySensor;
            chkVolumeSensor.Checked = MqttSettings.VolumeSensor;
            ChkComputerUsed.Checked = MqttSettings.IsComputerUsed;
            chkMinimizeToTray.Checked = MqttSettings.MinimizeToTray;
            chkScreenshot.Checked = MqttSettings.ScreenshotEnable;
            chkTtsEnabled.Checked = MqttSettings.EnableTTS;
            ChkMonitor.Checked = MqttSettings.Monitor;
            chktoast.Checked = MqttSettings.Toast;
            ChkProcesses.Checked = MqttSettings.App;
            chkTTS.Checked = MqttSettings.Tts;
            chkHibernate.Checked = MqttSettings.Hibernate;
            chkShutdown.Checked = MqttSettings.Shutdown;
            chkReboot.Checked = MqttSettings.Reboot;
            chkSuspend.Checked = MqttSettings.Suspend;
            chkmute.Checked = MqttSettings.Mute;
            ChkVolume.Checked = MqttSettings.Volume;

           

            if (chkTtsEnabled.Checked == true)
            {
                cmbSpeaker.DataSource = HardwareSensors.Speaker.GetSpeakers();
                cmbSpeaker.SelectedItem = Properties.Settings.Default["TTSSpeaker"];
            }


            ChkSlideshow.Checked = Convert.ToBoolean(Properties.Settings.Default["MqttSlideshow"].ToString(), CultureInfo.CurrentCulture);
            txtSlideshowFolder.Text = Properties.Settings.Default["MqttSlideshowFolder"].ToString();
            chkStartUp.Checked = Convert.ToBoolean(Properties.Settings.Default["RunAtStart"], CultureInfo.CurrentCulture);
            ChkEnableWebCamPublish.Checked = Convert.ToBoolean(Properties.Settings.Default["EnableWebCamPublish"], CultureInfo.CurrentCulture);
            if (ChkEnableWebCamPublish.Checked == true)
            {
                LoadCameraDevices();
                if (Convert.ToString(Properties.Settings.Default["WebCamToPublish"], CultureInfo.CurrentCulture).Length > 0)
                {
                    cmbWebcam.SelectedText = Convert.ToString(Properties.Settings.Default["WebCamToPublish"], CultureInfo.CurrentCulture);
                }
            }
            else
            {
                cmbWebcam.Visible = false;
                CmdWebCamTest.Visible = false;
            }



        }
        private void SaveSettings()
        {
            MqttSettings.MqttServer = txtmqttserver.Text;
            MqttSettings.MqttUsername = txtmqttusername.Text;
            MqttSettings.MqttPassword = txtmqttpassword.Text;
            MqttSettings.MqttTopic = txtmqtttopic.Text;
            MqttSettings.MqttTimerInterval = txtMqttTimerInterval.Text;
            MqttSettings.ScreenshotEnable = Convert.ToBoolean(chkScreenshot.Checked);
            MqttSettings.MinimizeToTray = chkMinimizeToTray.Checked;
            MqttSettings.MqttSlideshow = ChkSlideshow.Checked;
            MqttSettings.MqttSlideshowFolder = txtSlideshowFolder.Text;
            MqttSettings.CpuSensor = chkCpuSensor.Checked;
            MqttSettings.FreeMemorySensor = chkMemorySensor.Checked;
            MqttSettings.VolumeSensor = chkVolumeSensor.Checked;
            MqttSettings.EnableWebCamPublish = ChkEnableWebCamPublish.Checked;
            MqttSettings.DiskSensor = (bool)ChkDiskSensor.Checked;
            MqttSettings.IsComputerUsed = ChkComputerUsed.Checked;
            MqttSettings.BatterySensor = ChkBatterySensor.Checked;
            MqttSettings.Monitor = ChkMonitor.Checked;
            MqttSettings.Toast = chktoast.Checked;
            MqttSettings.App = ChkProcesses.Checked;
            MqttSettings.Tts = chkTTS.Checked;
            MqttSettings.Hibernate = chkHibernate.Checked;
            MqttSettings.Shutdown = chkShutdown.Checked;
            MqttSettings.Reboot = chkReboot.Checked;
            MqttSettings.Suspend = chkSuspend.Checked;
            MqttSettings.Mute = chkmute.Checked;
            MqttSettings.Volume = ChkVolume.Checked;

            if (ChkEnableWebCamPublish.Checked == true)
            {
                CmdWebCamTest.Visible = true;
            }
            else
            {
                CmdWebCamTest.Visible = false;
            }

            MqttSettings.EnableTTS = chkTtsEnabled.Checked;
            if (cmbSpeaker.SelectedItem != null)
            {
                MqttSettings.TTSSpeaker = cmbSpeaker.SelectedItem.ToString();
            }
            if (cmbWebcam.SelectedItem != null)
            {
                MqttSettings.WebCamToPublish = cmbWebcam.SelectedItem.ToString();
            }
            MqttSettings.Save();
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    SaveSettings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durring savesettings error:" + ex.Message);
                    throw;
                }

                try
                {
                    ParentForm.ReloadApp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durring ReloadApp error:" + ex.Message);
                    throw;
                }
                try
                {
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durring Close error:" + ex.Message);

                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message + " details: " + ex.InnerException);
                throw;
            }

        }
        private void CmdTestSpeaker_Click(object sender, EventArgs e)
        {
            if (cmbSpeaker.SelectedItem.ToString().Length > 0)
            {
                HardwareSensors.Speaker.Speak("testing", cmbSpeaker.SelectedItem.ToString());
            }
        }
        private void ChkStartUp_CheckedChanged(object sender, EventArgs e)
        {
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (chkStartUp.Checked)
                {
                    rk.SetValue(MqttSettings.AppId, Application.ExecutablePath.ToString(CultureInfo.CurrentCulture));
                }
                else
                {
                    rk.DeleteValue(MqttSettings.AppId, false);
                }
                Properties.Settings.Default["RunAtStart"] = chkStartUp.Checked;
            }
        }
        private void LoadAudioDevices()
        {
            cmbAudioOutput.DataSource = HardwareSensors.Audio.GetAudioDevices();
        }
        private void LoadCameraDevices()
        {
            cmbWebcam.DataSource = HardwareSensors.Camera.GetDevices();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (cmbWebcam.SelectedValue.ToString().Length > 0)
            {
                try
                {
                    string Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) +  @"\cameratest.jpeg";

                    if (HardwareSensors.Camera.Save(Filename))
                    {
                        MessageBox.Show($"camera image saved to {Filename}");
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
        }
        private void ChkEnableWebCamPublish_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnableWebCamPublish.Checked)
            {
                cmbWebcam.Visible = true;
                LoadCameraDevices();
                CmdWebCamTest.Visible = true;
            }
            else
            {
                cmbWebcam.DataSource = null;
                cmbWebcam.Visible = false;
                CmdWebCamTest.Visible = false;
            }
        }
        private void ChkTtsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTtsEnabled.Checked == true)
            {
                cmbSpeaker.DataSource = HardwareSensors.Speaker.GetSpeakers();
                cmbSpeaker.SelectedItem = Properties.Settings.Default["TTSSpeaker"];
            }
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var client = new MqttClient(txtmqttserver.Text, Convert.ToInt16(textBox1.Text, CultureInfo.CurrentCulture), false, null, null, MqttSslProtocols.None, null);

                if (txtmqttusername.Text.Length == 0)
                {
                    byte code = client.Connect(Guid.NewGuid().ToString());
                }
                else
                {
                    byte code = client.Connect(Guid.NewGuid().ToString(), txtmqttusername.Text, txtmqttpassword.Text);
                }
                MessageBox.Show($"connection ok id: {client.ClientId}");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed");
                //throw;
            }
        }
        private void CmdSelectSlideShowPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSlideshowFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
