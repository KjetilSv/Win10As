using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace mqttclient
{
    public partial class FrmOptions : Form
    {
        BindingList<mqtttrigger> MqttTriggerList = new BindingList<mqtttrigger>();
        string appID = "win iot";
        public string g_TriggerFile { get; set; }
        public string g_LocalScreetshotFile { get; set; }
        public FrmOptions()
        {

            InitializeComponent();
            g_TriggerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "triggers.json");
            LoadSettings();
            if (txtmqtttopic.TextLength == 0)
            {
                txtmqtttopic.Text = System.Environment.MachineName;
            }

            if (txtMqttTimerInterval.TextLength == 0)
            {
                txtMqttTimerInterval.Text = "60000";
            }
            LoadTriggerlist();
            dataGridView1.DataSource = MqttTriggerList;
            dataGridView1.Columns[0].Visible = false;

            if (txtmqtttopic.Text.Contains("#") == true)
            {
                txtmqtttopic.Text = txtmqtttopic.Text.Replace("/#", "");
                Properties.Settings.Default["mqtttopic"] = txtmqtttopic.Text;
                Properties.Settings.Default.Save();

            }

        }
        private void SaveTriggerlist()

        {
            string output = JsonConvert.SerializeObject(MqttTriggerList);
            try
            {
                File.WriteAllText(g_TriggerFile, output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error durring file io:" + g_TriggerFile + " details:" + ex.Message);
                throw;
            }


        }
        private void ClearNewTrigger()
        {
            txtSubTopic.Text = "";
            txtCmd.Text = "";
            txtCmdParameter.Text = "";

        }
        private void LoadTriggerlist()
        {
            if (File.Exists(g_TriggerFile))
            {
                string s = File.ReadAllText(g_TriggerFile);
                BindingList<mqtttrigger> deserializedProduct = JsonConvert.DeserializeObject<BindingList<mqtttrigger>>(s);
                MqttTriggerList = deserializedProduct;
                foreach (mqtttrigger t in MqttTriggerList)
                {
                    if (t.Predefined == true)
                    {
                        switch (t.name.ToLower())
                        {
                            case "mute/set":
                                chkmute.Checked = true;
                                break;
                            case "volume":
                                ChkVolume.Checked = true;
                                break;
                            case "suspend":
                                chkSuspend.Checked = true;
                                break;
                            case "reboot":
                                chkReboot.Checked = true;
                                break;
                            case "shutdown":
                                chkShutdown.Checked = true;
                                break;
                            case "hibernate":
                                chkHibernate.Checked = true;
                                break;
                            case "tts":
                                chkTTS.Checked = true;
                                break;
                            case "toast":
                                chktoast.Checked = true;
                                break;
                            case "monitor/set":
                                ChkMonitor.Checked = true;
                                break;
                            case "app/running":
                                ChkProcesses.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

        }
        private void LoadSettings()
        {
            txtmqttserver.Text = Properties.Settings.Default["mqttserver"].ToString();
            txtmqttusername.Text = Properties.Settings.Default["mqttusername"].ToString();
            txtmqttpassword.Text = Properties.Settings.Default["mqttpassword"].ToString();
            txtmqtttopic.Text = Properties.Settings.Default["mqtttopic"].ToString();
            txtMqttTimerInterval.Text = Properties.Settings.Default["mqtttimerinterval"].ToString();
            ChkBatterySensor.Checked = Convert.ToBoolean(Properties.Settings.Default["BatterySensor"].ToString());
            ChkDiskSensor.Checked = Convert.ToBoolean(Properties.Settings.Default["DiskSensor"].ToString());

            chkMinimizeToTray.Checked = Convert.ToBoolean(Properties.Settings.Default["MinimizeToTray"].ToString());

            if (Convert.ToBoolean(Properties.Settings.Default["ScreenShotEnable"]) == true)
            {
                chkScreenshot.Checked = true;
            }
            if (Convert.ToBoolean(Properties.Settings.Default["ScreenshotMqtt"]) == true)
            {
                chkScreenshotMqtt.Checked = true;
                txtScreenshotPath.Visible = false;
                LblScreenshotPath.Visible = false;
                g_LocalScreetshotFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "localscreenmqtt.jpg");
            }
            else
            {
                txtScreenshotPath.Text = Properties.Settings.Default["ScreenShotpath"].ToString();
            }

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            foreach (InstalledVoice i in synthesizer.GetInstalledVoices())
            {
                comboBox1.Items.Add(i.VoiceInfo.Name);
            }

            comboBox1.SelectedItem = Properties.Settings.Default["TTSSpeaker"];
            ChkSlideshow.Checked = Convert.ToBoolean(Properties.Settings.Default["MqttSlideshow"].ToString());
            txtSlideshowFolder.Text = Properties.Settings.Default["MqttSlideshowFolder"].ToString();
            chkStartUp.Checked = Convert.ToBoolean(Properties.Settings.Default["RunAtStart"]);


        }
        private void savesettings()
        {

            Properties.Settings.Default["mqttserver"] = txtmqttserver.Text;
            Properties.Settings.Default["mqttusername"] = txtmqttusername.Text;
            Properties.Settings.Default["mqttpassword"] = txtmqttpassword.Text;
            Properties.Settings.Default["mqtttopic"] = txtmqtttopic.Text;
            Properties.Settings.Default["mqtttimerinterval"] = txtMqttTimerInterval.Text;
            Properties.Settings.Default["screenshotenable"] = chkScreenshot.Checked;
            Properties.Settings.Default["ScreenshotMqtt"] = chkScreenshotMqtt.Checked;
            Properties.Settings.Default["ScreenShotpath"] = txtScreenshotPath.Text;
            Properties.Settings.Default["MinimizeToTray"] = chkMinimizeToTray.Checked;

            Properties.Settings.Default["MqttSlideshow"] = ChkSlideshow.Checked;
            Properties.Settings.Default["MqttSlideshowFolder"] = txtSlideshowFolder.Text;


            if (comboBox1.SelectedItem != null)
            {
                Properties.Settings.Default["TTSSpeaker"] = comboBox1.SelectedItem.ToString();
            }

            Properties.Settings.Default.Save();

        }
        private void AddRemovePrefinedItem(string name, Boolean Add)
        {
            if (Add == true)
            {
                mqtttrigger t = new mqtttrigger();
                t.name = name;
                t.Predefined = true;
                MqttTriggerList.Add(t);
            }
            else
            {

                BindingList<mqtttrigger> tmpMqttTriggerList;

                tmpMqttTriggerList = MqttTriggerList;

                foreach (mqtttrigger t in MqttTriggerList)
                {
                    if (t.name == name)
                    {
                        tmpMqttTriggerList.Remove(t);
                        break;
                    }
                }
                MqttTriggerList = tmpMqttTriggerList;
            }
            SaveTriggerlist();



        }
        private void refreshgridandsavefile()
        {

            try
            {
                SaveTriggerlist();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void checkbox_predefined_click(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            switch (chk.Name)
            {
                case "chkHibernate":
                    AddRemovePrefinedItem("hibernate", chkHibernate.Checked);
                    break;
                case "chkSuspend":
                    AddRemovePrefinedItem("suspend", chkSuspend.Checked);
                    break;
                case "chkShutdown":
                    AddRemovePrefinedItem("shutdown", chkShutdown.Checked);
                    break;
                case "ChkVolume":
                    AddRemovePrefinedItem("volume/set", ChkVolume.Checked);
                    break;
                case "chkmute":
                    AddRemovePrefinedItem("mute/set", chkmute.Checked);
                    break;
                case "chkReboot":
                    AddRemovePrefinedItem("reboot", chkReboot.Checked);
                    break;
                case "chkTTS":
                    AddRemovePrefinedItem("tts", chkTTS.Checked);
                    break;
                case "chktoast":
                    AddRemovePrefinedItem("toast", chktoast.Checked);
                    break;
                case "ChkMonitor":
                    AddRemovePrefinedItem("monitor/set", chktoast.Checked);
                    break;
                case "ChkProcesses":
                    AddRemovePrefinedItem("app/running", ChkProcesses.Checked);
                    break;

                default:
                    break;
            }
        }
        private void CmdAddTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                mqtttrigger newtrigger = new mqtttrigger();
                newtrigger.name = txtSubTopic.Text;
                newtrigger.cmdtext = txtCmd.Text;
                newtrigger.cmdparameters = txtCmdParameter.Text;
                newtrigger.Predefined = false;
                MqttTriggerList.Add(newtrigger);
                SaveTriggerlist();
                ClearNewTrigger();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message + " details: " + ex.InnerException);
            }
        }
        private void chkScreenshotMqtt_CheckedChanged(object sender, EventArgs e)
        {

            if (chkScreenshotMqtt.Checked == true)
            {
                txtScreenshotPath.Visible = false;
                LblScreenshotPath.Visible = false;
            }
            else
            {
                txtScreenshotPath.Visible = true;
                LblScreenshotPath.Visible = true;
            }
            savesettings();
        }
        private void ChkBatterySensor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["BatterySensor"] = ChkBatterySensor.Checked;
            Properties.Settings.Default.Save();
        }
        private void DiskSensor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["DiskSensor"] = ChkDiskSensor.Checked;
            Properties.Settings.Default.Save();
        }
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
            this.Close();
        }
        private void CmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveTriggerlist();
                savesettings();
                //todo : make a cleaner restart
                Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message + " details: " + ex.InnerException);
                throw;
            }

        }
        private void CmdTestSpeaker_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoice(comboBox1.SelectedItem.ToString());
            synthesizer.Speak("testing");
        }
        private void chkStartUp_CheckedChanged(object sender, EventArgs e)
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
    }
}
