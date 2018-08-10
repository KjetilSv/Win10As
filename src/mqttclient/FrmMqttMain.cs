using System;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading;
using System.Reflection;

namespace mqttclient
{
    public partial class FrmMqttMain : Form
    {
        private readonly MqttPublish _mqttPublish;
        private readonly Mqtt _mqtt = new Mqtt();

        private const string NotifyIconText = "Mqtt client";
        private const string NotifyIconBalloonTipText = "Mqtt client minimized to systemtray";
        private const int NotifyIconBalloonTipTimer = 200;

        private string GTriggerFile { get; set; }

        public FrmMqttMain()
        {
            try
            {
                InitializeComponent();
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                toolStripStatusLabel2.Text = "";

                Properties.Settings.Default.Upgrade();
                try
                {
                    _mqttPublish = new MqttPublish(_mqtt);
                    _mqtt.Connect(Properties.Settings.Default["mqttserver"].ToString(), Convert.ToInt32(Properties.Settings.Default["mqttport"].ToString()), Properties.Settings.Default["mqttusername"].ToString(), Properties.Settings.Default["mqttpassword"].ToString());
                }
                catch (Exception e)
                {
                    toolStripStatusLabel1.Text = e.Message;
                }
                SetupTimer();

                notifyIcon1.Visible = false;
                notifyIcon1.Text = NotifyIconText;
                notifyIcon1.BalloonTipText = NotifyIconBalloonTipText;
                notifyIcon1.ShowBalloonTip(NotifyIconBalloonTipTimer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetupTimer()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default["mqtttimerinterval"].ToString()))
            {
                Properties.Settings.Default["mqtttimerinterval"] = 6000;
                Properties.Settings.Default.Save();
            }

            timer1.Interval = Convert.ToInt32(Properties.Settings.Default["mqtttimerinterval"].ToString());
            timer1.Start();
        }
        private void client_MqttConnectionClosed(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "not connected";
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            try
            {
                WriteToLog("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            }
            catch (Exception ex)
            {
                WriteToLog("error: " + ex.Message);
            }

        }
        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            try
            {
                WriteToLog("Subscribed for id = " + e.MessageId);
            }
            catch (Exception ex)
            {
                WriteToLog("error: " + ex.Message);
            }

        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string message = Encoding.UTF8.GetString(e.Message);
                MqttTrigger currentMqttTrigger = new MqttTrigger();
                WriteToLog("Message recived " + e.Topic + " value " + message);

                string TopLevel = Properties.Settings.Default["mqtttopic"].ToString().Replace("/#", "");
                string subtopic = e.Topic.Replace(TopLevel + "/", "");

                foreach (MqttTrigger tmpTrigger in MqttTriggerList)
                {
                    if (tmpTrigger.Name == subtopic)
                    {
                        currentMqttTrigger = tmpTrigger;
                        currentMqttTrigger.Id = 1;
                        break;
                    }
                }

                if (currentMqttTrigger.Id == 1)
                {

                    switch (subtopic)
                    {
                        case "app/running":
                            _mqtt.Publish("app/running/" + message, ExeRunning(message, ""));
                            break;
                        case "app/close":
                            _mqtt.Publish("app/running/" + message, ExeClose(message));
                            break;

                        case "monitor/set":

                            using (var f = new Form())
                            {
                                if (message == "1")
                                {

                                    NativeMethods.SendMessage(f.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MonitorTurnOn);
                                    _mqtt.Publish("monitor", "1");
                                }
                                else
                                {
                                    NativeMethods.SendMessage(f.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MonitorShutoff);
                                    _mqtt.Publish("monitor", "0");
                                }
                            }
                            break;

                        case "mute/set":

                            if (message == "1")
                            {
                                _audioobj.Mute(true);
                            }
                            else
                            {
                                _audioobj.Mute(false);
                            }

                            _mqtt.Publish("mute", message);
                            break;
                        case "mute":
                            break;
                        case "volume":
                            break;
                        case "volume/set":
                            _audioobj.Volume(Convert.ToInt32(message));
                            break;
                        case "hibernate":
                            Application.SetSuspendState(PowerState.Hibernate, true, true);
                            break;
                        case "suspend":
                            Application.SetSuspendState(PowerState.Suspend, true, true);
                            break;
                        case "reboot":
                            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 10");
                            break;
                        case "shutdown":
                            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 10");
                            break;
                        case "tts":
                            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                            // synthesizer.GetInstalledVoices

                            synthesizer.Volume = 100;  // 0...100
                            synthesizer.SpeakAsync(message);
                            break;
                        case "toast":

                            int i = 0;

                            string Line1 = "";
                            string Line2 = "";
                            string Line3 = "";
                            string FileURI = "";

                            string[] words = message.Split(',');
                            foreach (string word in words)
                            {

                                switch (i)
                                {
                                    case 0:
                                        Line1 = word;
                                        break;
                                    case 1:
                                        Line2 = word;
                                        break;
                                    case 2:
                                        Line3 = word;
                                        break;
                                    case 3:
                                        FileURI = word;
                                        break;
                                    default:
                                        break;
                                }
                                i = i + 1;
                            }
                            Toastmessage(Line1, Line2, Line3, FileURI, ToastTemplateType.ToastImageAndText04);


                            break;
                        default:

                            if (currentMqttTrigger.CmdText.Length > 2)
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo(currentMqttTrigger.CmdText);
                                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                if (currentMqttTrigger.CmdParameters.Length > 2)
                                {
                                    startInfo.Arguments = currentMqttTrigger.CmdParameters;
                                }
                                Process.Start(startInfo);
                            }

                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                WriteToLog("error: " + ex.Message);

            }

        }
        private void Toastmessage(string line1, string line2, string line3, string fileUri, ToastTemplateType ts)
        {
            switch (ts)
            {
                case ToastTemplateType.ToastImageAndText04:

                    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

                    string tempLine = "";

                    XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
                    for (int i = 0; i < stringElements.Length; i++)
                    {

                        switch (i)
                        {
                            case 0:
                                tempLine = line1;
                                break;
                            case 1:
                                tempLine = line2;
                                break;
                            case 2:
                                tempLine = line3;
                                break;
                        }
                        stringElements[i].AppendChild(toastXml.CreateTextNode(tempLine));
                    }

                    String imagePath = "file:///" + fileUri;

                    XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
                    ((XmlElement)toastImageAttributes[0]).SetAttribute("src", imagePath);
                    ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "alt text");

                    ToastNotification toast = new ToastNotification(toastXml);
                    toast.Activated += ToastActivated;
                    toast.Dismissed += ToastDismissed;
                    toast.Failed += ToastFailed;
                    ToastNotificationManager.CreateToastNotifier(appID).Show(toast);
                    break;

                default:
                    break;

            }
        }
        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs args)
        {
            throw new NotImplementedException();
        }
        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs args)
        {
            throw new NotImplementedException();
        }
        private void ToastActivated(ToastNotification sender, object args)
        {
            throw new NotImplementedException();
        }

        private void WriteToLog(string logtext)
        {
            try
            {
                this.Invoke((MethodInvoker)(() => listBox1.Items.Insert(0, logtext)));
                if (listBox1.Items.Count > 20)
                {
                    this.Invoke((MethodInvoker)(() => listBox1.Items.RemoveAt(20)));
                }
            }
            catch (Exception)
            {

                // throw;
            }

        }
        delegate void SetTextCallback(string text);

        private void timer1_Tick(object sender, EventArgs e)
        {
            _mqttPublish.PublishSystemData();
        }

        public void HandleUnhandledException(Exception e)
        {
            if (MessageBox.Show("An unexpected error has occurred. details:" + e.Message + "innerException:" + e.InnerException + "Continue?",
                "MqttClient" + e.Message + " inner:" + e.InnerException, MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
            }
        }
        public void UnhandledThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            this.HandleUnhandledException(e.Exception);
        }
        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != listBox1) return;

            if (e.Control && e.KeyCode == Keys.C)
                try
                {
                    Clipboard.SetText(listBox1.SelectedItems[0].ToString());
                }
                catch (Exception)
                {
                }

        }
       
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSettingsFrom = new FrmOptions(this);
            frmSettingsFrom.Show();
        }

        public void ReloadApp()
        {
            _mqtt.Disconnect();

            _mqtt.Connect(Properties.Settings.Default["mqttserver"].ToString(), Convert.ToInt32(Properties.Settings.Default["mqttport"].ToString()), Properties.Settings.Default["mqttusername"].ToString(), Properties.Settings.Default["mqttpassword"].ToString());
            SetupTimer();
            _mqtt.LoadTriggerlist();
        }
        private void FrmMqttMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (Convert.ToBoolean(Properties.Settings.Default["MinimizeToTray"].ToString()) == true)
                {
                    notifyIcon1.Visible = true;
                    this.ShowInTaskbar = false;
                    this.Hide();
                }
            }
            else
            {
                this.Show();
            }
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void FrmMqttMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //hard exit
            Environment.Exit(0);
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}

