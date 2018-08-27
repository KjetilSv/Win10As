using System;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using mqttclient.Mqtt;

namespace mqttclient
{
    public partial class FrmMqttMain : Form
    {
        private readonly IMqttPublish _mqttPublish;
        private readonly IMqtt _mqtt;

        private const string NotifyIconText = "Mqtt client";
        private const string NotifyIconBalloonTipText = "Mqtt client minimized to systemtray";
        private const int NotifyIconBalloonTipTimer = 200;

        public FrmMqttMain(IMqtt mqtt, IMqttPublish mqttPublish, MainFormContainer mainFormContainer)
        {
            _mqtt = mqtt;
            _mqttPublish = mqttPublish;

            mainFormContainer.MainForm = this;

            try
            {
                InitializeComponent();
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                toolStripStatusLabel2.Text = "";

                Properties.Settings.Default.Upgrade();
                try
                {
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
            toolStripStatusLabel1.Text = "not connected";
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
            _mqtt.Connect(Properties.Settings.Default["mqttserver"].ToString(), Convert.ToInt32(Properties.Settings.Default["mqttport"].ToString()), Properties.Settings.Default["mqttusername"].ToString(), Properties.Settings.Default["mqttpassword"].ToString());
            SetupTimer();
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

