using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace mqttclient
{
    public partial class FrmOptions : Form
    {
        BindingList<MqttTrigger> MqttTriggerList = new BindingList<MqttTrigger>();
        readonly string appID = "win iot";
        public string TriggerFile { get; set; }

        public FrmMqttMain ParentForm;

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
        private void SaveTriggerlist()

        {
            string output = JsonConvert.SerializeObject(MqttTriggerList);
            try
            {
                File.WriteAllText(TriggerFile, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error durring file io: {TriggerFile} details: {ex.Message}");
                throw;
            }


        }
        //private void ClearNewTrigger()
        //{
        //    txtSubTopic.Text = "";
        //    txtCmd.Text = "";
        //    txtCmdParameter.Text = "";

        //}
        
        private void LoadSettings()
        {
            txtmqttserver.Text = MqttSettings.MqttServer;
            txtmqttusername.Text = MqttSettings.MqttUsername;
            txtmqttpassword.Text = MqttSettings.MqttPassword;
            txtmqtttopic.Text = MqttSettings.MqttTopic;
            txtMqttTimerInterval.Text = MqttSettings.MqttTimerInterval.ToString();
            ChkBatterySensor.Checked = MqttSettings.BatterySensor;
            ChkDiskSensor.Checked = MqttSettings.DiskSensor;
            chkCpuSensor.Checked = MqttSettings.CpuSensor;
            chkMemorySensor.Checked = MqttSettings.FreeMemorySensor;
            chkVolumeSensor.Checked = MqttSettings.VolumeSensor;
            ChkComputerUsed.Checked = MqttSettings.IsComputerUsed;
            chkMinimizeToTray.Checked = MqttSettings.MinimizeToTray;
            chkScreenshot.Checked = MqttSettings.ScreenshotEnable;
            chkTtsEnabled.Checked = MqttSettings.EnableTTS;
            ChkMonitor.Checked= MqttSettings.Monitor;
            chktoast.Checked = MqttSettings.Toast;
            ChkProcesses.Checked = MqttSettings.App;
            chkTTS.Checked = MqttSettings.Tts;
            chkHibernate.Checked = MqttSettings.Hibernate;
            chkShutdown.Checked = MqttSettings.Shutdown;
            chkReboot.Checked=MqttSettings.Reboot;
            chkSuspend.Checked = MqttSettings.Suspend;
            chkmute.Checked = MqttSettings.Mute;
            ChkVolume.Checked = MqttSettings.Volume;

            if (MqttSettings.ScreenshotMqtt)
            {
                chkScreenshotMqtt.Checked = true;
                txtScreenshotPath.Visible = false;
                LblScreenshotPath.Visible = false;
            }
            else
            {
                txtScreenshotPath.Text = MqttSettings.ScreenShotPath;
            }

            if (chkTtsEnabled.Checked == true)
            {
                cmbSpeaker.DataSource = HardwareSensors.Speaker.GetSpeakers();
                cmbSpeaker.SelectedItem = Properties.Settings.Default["TTSSpeaker"];
            }


            ChkSlideshow.Checked = Convert.ToBoolean(Properties.Settings.Default["MqttSlideshow"].ToString());
            txtSlideshowFolder.Text = Properties.Settings.Default["MqttSlideshowFolder"].ToString();
            chkStartUp.Checked = Convert.ToBoolean(Properties.Settings.Default["RunAtStart"]);
            ChkEnableWebCamPublish.Checked = Convert.ToBoolean(Properties.Settings.Default["EnableWebCamPublish"]);
            if (ChkEnableWebCamPublish.Checked == true)
            {
                LoadCameraDevices();
                if (Convert.ToString(Properties.Settings.Default["WebCamToPublish"]).Length > 0)
                {
                    cmbWebcam.SelectedText = Convert.ToString(Properties.Settings.Default["WebCamToPublish"]);
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
            MqttSettings.ScreenshotMqtt = Convert.ToBoolean(chkScreenshotMqtt.Checked);
            MqttSettings.ScreenShotPath = txtScreenshotPath.Text;
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
        private void AddRemovePrefinedItem(string name, Boolean Add)
        {
            if (Add == true)
            {
                MqttTrigger t = new MqttTrigger
                {
                    Name = name,
                    Predefined = true
                };
                MqttTriggerList.Add(t);
            }
            else
            {
                var tmpMqttTriggerList = MqttTriggerList;

                foreach (MqttTrigger t in MqttTriggerList)
                {
                    if (t.Name == name)
                    {
                        tmpMqttTriggerList.Remove(t);
                        break;
                    }
                }
                MqttTriggerList = tmpMqttTriggerList;
            }
            SaveTriggerlist();
        }
        //private void ChkScreenshotMqtt_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (chkScreenshotMqtt.Checked == true)
        //    {
        //        txtScreenshotPath.Visible = false;
        //        LblScreenshotPath.Visible = false;
        //    }
        //    else
        //    {
        //        txtScreenshotPath.Visible = true;
        //        LblScreenshotPath.Visible = true;
        //    }
        //    SaveSettings();
        //}
        //private void ChkBatterySensor_CheckedChanged(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default["BatterySensor"] = ChkBatterySensor.Checked;
        //    Properties.Settings.Default.Save();
        //}
        //private void DiskSensor_CheckedChanged(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default["DiskSensor"] = ChkDiskSensor.Checked;
        //    Properties.Settings.Default.Save();
        //}
        //private void IsComputerUsed_CheckedChanged(object sender, EventArgs e)
        //{
        //    MqttSettings.IsComputerUsed = ChkComputerUsed.Checked;
        //    MqttSettings.Save();
        //}
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show(anError.RowIndex + " " + anError.ColumnIndex);
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                anError.ThrowException = false;
            }
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
                    SaveTriggerlist();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durring SaveTriggerlist error:" + ex.Message);
                    throw;
                }
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
                    rk.SetValue(appID, Application.ExecutablePath.ToString());
                }
                else
                {
                    rk.DeleteValue(appID, false);
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
                HardwareSensors.Camera c = new HardwareSensors.Camera
                {
                    Filename = @"c:\temp\test.bmp"
                };
                c.GetPicture(cmbWebcam.SelectedValue.ToString());
                //using (FileStream file = new FileStream(c.Filename, FileMode.Create, FileAccess.Write))
                //{
                //    c.memoryStream.WriteTo(file);
                //}

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
                var client = new MqttClient(txtmqttserver.Text, Convert.ToInt16(textBox1.Text), false, null, null, MqttSslProtocols.None, null);

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
    }
}
