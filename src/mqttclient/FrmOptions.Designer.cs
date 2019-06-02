namespace mqttclient
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMqttTimerInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmqtttopic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmqttpassword = new System.Windows.Forms.TextBox();
            this.txtmqttusername = new System.Windows.Forms.TextBox();
            this.txtmqttserver = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ChkComputerUsed = new System.Windows.Forms.CheckBox();
            this.chkVolumeSensor = new System.Windows.Forms.CheckBox();
            this.chkCpuSensor = new System.Windows.Forms.CheckBox();
            this.chkMemorySensor = new System.Windows.Forms.CheckBox();
            this.ChkDiskSensor = new System.Windows.Forms.CheckBox();
            this.ChkBatterySensor = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChkProcesses = new System.Windows.Forms.CheckBox();
            this.ChkMonitor = new System.Windows.Forms.CheckBox();
            this.chktoast = new System.Windows.Forms.CheckBox();
            this.chkTTS = new System.Windows.Forms.CheckBox();
            this.chkReboot = new System.Windows.Forms.CheckBox();
            this.ChkVolume = new System.Windows.Forms.CheckBox();
            this.chkHibernate = new System.Windows.Forms.CheckBox();
            this.chkmute = new System.Windows.Forms.CheckBox();
            this.chkShutdown = new System.Windows.Forms.CheckBox();
            this.chkSuspend = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkScreenDumpPrimonitor = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ChkEnableWebCamPublish = new System.Windows.Forms.CheckBox();
            this.CmdWebCamTest = new System.Windows.Forms.Button();
            this.cmbWebcam = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkScreenshotMqtt = new System.Windows.Forms.CheckBox();
            this.LblScreenshotPath = new System.Windows.Forms.Label();
            this.txtScreenshotPath = new System.Windows.Forms.TextBox();
            this.chkScreenshot = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ChkSlideshow = new System.Windows.Forms.CheckBox();
            this.txtSlideshowFolder = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkTtsEnabled = new System.Windows.Forms.CheckBox();
            this.CmdTestSpeaker = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSpeaker = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbAudioOutput = new System.Windows.Forms.ComboBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.CmdDiscovery = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(619, 651);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(95, 23);
            this.CmdSave.TabIndex = 42;
            this.CmdSave.Text = "Save and close";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CmdClose
            // 
            this.CmdClose.Location = new System.Drawing.Point(518, 651);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(95, 23);
            this.CmdClose.TabIndex = 43;
            this.CmdClose.Text = "Close";
            this.CmdClose.UseVisualStyleBackColor = true;
            this.CmdClose.Click += new System.EventHandler(this.CmdClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 613);
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMqttTimerInterval);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtmqtttopic);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtmqttpassword);
            this.groupBox2.Controls.Add(this.txtmqttusername);
            this.groupBox2.Controls.Add(this.txtmqttserver);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 212);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MQTT client options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "test connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Port";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "1883";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Timer inverval";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMqttTimerInterval
            // 
            this.txtMqttTimerInterval.Location = new System.Drawing.Point(97, 133);
            this.txtMqttTimerInterval.Name = "txtMqttTimerInterval";
            this.txtMqttTimerInterval.Size = new System.Drawing.Size(164, 20);
            this.txtMqttTimerInterval.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Topic";
            // 
            // txtmqtttopic
            // 
            this.txtmqtttopic.Location = new System.Drawing.Point(97, 159);
            this.txtmqtttopic.Name = "txtmqtttopic";
            this.txtmqtttopic.Size = new System.Drawing.Size(164, 20);
            this.txtmqtttopic.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Server";
            // 
            // txtmqttpassword
            // 
            this.txtmqttpassword.Location = new System.Drawing.Point(97, 76);
            this.txtmqttpassword.Name = "txtmqttpassword";
            this.txtmqttpassword.PasswordChar = '*';
            this.txtmqttpassword.Size = new System.Drawing.Size(164, 20);
            this.txtmqttpassword.TabIndex = 3;
            // 
            // txtmqttusername
            // 
            this.txtmqttusername.Location = new System.Drawing.Point(97, 46);
            this.txtmqttusername.Name = "txtmqttusername";
            this.txtmqttusername.Size = new System.Drawing.Size(165, 20);
            this.txtmqttusername.TabIndex = 2;
            // 
            // txtmqttserver
            // 
            this.txtmqttserver.Location = new System.Drawing.Point(97, 19);
            this.txtmqttserver.Name = "txtmqttserver";
            this.txtmqttserver.Size = new System.Drawing.Size(165, 20);
            this.txtmqttserver.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sensors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(27, 303);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(381, 154);
            this.textBox4.TabIndex = 42;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ChkComputerUsed);
            this.groupBox6.Controls.Add(this.chkVolumeSensor);
            this.groupBox6.Controls.Add(this.chkCpuSensor);
            this.groupBox6.Controls.Add(this.chkMemorySensor);
            this.groupBox6.Controls.Add(this.ChkDiskSensor);
            this.groupBox6.Controls.Add(this.ChkBatterySensor);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(611, 282);
            this.groupBox6.TabIndex = 41;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensors";
            // 
            // ChkComputerUsed
            // 
            this.ChkComputerUsed.AutoSize = true;
            this.ChkComputerUsed.Location = new System.Drawing.Point(95, 70);
            this.ChkComputerUsed.Name = "ChkComputerUsed";
            this.ChkComputerUsed.Size = new System.Drawing.Size(107, 17);
            this.ChkComputerUsed.TabIndex = 5;
            this.ChkComputerUsed.Text = "Is computer used";
            this.ChkComputerUsed.UseVisualStyleBackColor = true;
            // 
            // chkVolumeSensor
            // 
            this.chkVolumeSensor.AutoSize = true;
            this.chkVolumeSensor.Location = new System.Drawing.Point(10, 46);
            this.chkVolumeSensor.Name = "chkVolumeSensor";
            this.chkVolumeSensor.Size = new System.Drawing.Size(61, 17);
            this.chkVolumeSensor.TabIndex = 4;
            this.chkVolumeSensor.Text = "Volume";
            this.chkVolumeSensor.UseVisualStyleBackColor = true;
            // 
            // chkCpuSensor
            // 
            this.chkCpuSensor.AutoSize = true;
            this.chkCpuSensor.Location = new System.Drawing.Point(95, 46);
            this.chkCpuSensor.Name = "chkCpuSensor";
            this.chkCpuSensor.Size = new System.Drawing.Size(45, 17);
            this.chkCpuSensor.TabIndex = 3;
            this.chkCpuSensor.Text = "Cpu";
            this.chkCpuSensor.UseVisualStyleBackColor = true;
            // 
            // chkMemorySensor
            // 
            this.chkMemorySensor.AutoSize = true;
            this.chkMemorySensor.Location = new System.Drawing.Point(10, 69);
            this.chkMemorySensor.Name = "chkMemorySensor";
            this.chkMemorySensor.Size = new System.Drawing.Size(63, 17);
            this.chkMemorySensor.TabIndex = 2;
            this.chkMemorySensor.Text = "Memory";
            this.chkMemorySensor.UseVisualStyleBackColor = true;
            // 
            // ChkDiskSensor
            // 
            this.ChkDiskSensor.AutoSize = true;
            this.ChkDiskSensor.Location = new System.Drawing.Point(95, 23);
            this.ChkDiskSensor.Name = "ChkDiskSensor";
            this.ChkDiskSensor.Size = new System.Drawing.Size(52, 17);
            this.ChkDiskSensor.TabIndex = 1;
            this.ChkDiskSensor.Text = "Disks";
            this.ChkDiskSensor.UseVisualStyleBackColor = true;
            // 
            // ChkBatterySensor
            // 
            this.ChkBatterySensor.AutoSize = true;
            this.ChkBatterySensor.Location = new System.Drawing.Point(10, 23);
            this.ChkBatterySensor.Name = "ChkBatterySensor";
            this.ChkBatterySensor.Size = new System.Drawing.Size(56, 17);
            this.ChkBatterySensor.TabIndex = 0;
            this.ChkBatterySensor.Text = "Power";
            this.ChkBatterySensor.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(694, 587);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Presets";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChkProcesses);
            this.groupBox3.Controls.Add(this.ChkMonitor);
            this.groupBox3.Controls.Add(this.chktoast);
            this.groupBox3.Controls.Add(this.chkTTS);
            this.groupBox3.Controls.Add(this.chkReboot);
            this.groupBox3.Controls.Add(this.ChkVolume);
            this.groupBox3.Controls.Add(this.chkHibernate);
            this.groupBox3.Controls.Add(this.chkmute);
            this.groupBox3.Controls.Add(this.chkShutdown);
            this.groupBox3.Controls.Add(this.chkSuspend);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(620, 529);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Enable Presets";
            // 
            // ChkProcesses
            // 
            this.ChkProcesses.AutoSize = true;
            this.ChkProcesses.Location = new System.Drawing.Point(201, 43);
            this.ChkProcesses.Name = "ChkProcesses";
            this.ChkProcesses.Size = new System.Drawing.Size(75, 17);
            this.ChkProcesses.TabIndex = 33;
            this.ChkProcesses.Text = "Processes";
            this.ChkProcesses.UseVisualStyleBackColor = true;
            this.ChkProcesses.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // ChkMonitor
            // 
            this.ChkMonitor.AutoSize = true;
            this.ChkMonitor.Location = new System.Drawing.Point(201, 20);
            this.ChkMonitor.Name = "ChkMonitor";
            this.ChkMonitor.Size = new System.Drawing.Size(61, 17);
            this.ChkMonitor.TabIndex = 32;
            this.ChkMonitor.Text = "Monitor";
            this.ChkMonitor.UseVisualStyleBackColor = true;
            this.ChkMonitor.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chktoast
            // 
            this.chktoast.AutoSize = true;
            this.chktoast.Location = new System.Drawing.Point(134, 20);
            this.chktoast.Name = "chktoast";
            this.chktoast.Size = new System.Drawing.Size(53, 17);
            this.chktoast.TabIndex = 31;
            this.chktoast.Text = "Toast";
            this.chktoast.UseVisualStyleBackColor = true;
            this.chktoast.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkTTS
            // 
            this.chkTTS.AutoSize = true;
            this.chkTTS.Location = new System.Drawing.Point(134, 43);
            this.chkTTS.Name = "chkTTS";
            this.chkTTS.Size = new System.Drawing.Size(47, 17);
            this.chkTTS.TabIndex = 30;
            this.chkTTS.Text = "TTS";
            this.chkTTS.UseVisualStyleBackColor = true;
            this.chkTTS.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkReboot
            // 
            this.chkReboot.AutoSize = true;
            this.chkReboot.Location = new System.Drawing.Point(134, 66);
            this.chkReboot.Name = "chkReboot";
            this.chkReboot.Size = new System.Drawing.Size(61, 17);
            this.chkReboot.TabIndex = 18;
            this.chkReboot.Text = "Reboot";
            this.chkReboot.UseVisualStyleBackColor = true;
            this.chkReboot.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // ChkVolume
            // 
            this.ChkVolume.AutoSize = true;
            this.ChkVolume.Location = new System.Drawing.Point(24, 43);
            this.ChkVolume.Name = "ChkVolume";
            this.ChkVolume.Size = new System.Drawing.Size(61, 17);
            this.ChkVolume.TabIndex = 16;
            this.ChkVolume.Text = "Volume";
            this.ChkVolume.UseVisualStyleBackColor = true;
            this.ChkVolume.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkHibernate
            // 
            this.chkHibernate.AutoSize = true;
            this.chkHibernate.Location = new System.Drawing.Point(134, 89);
            this.chkHibernate.Name = "chkHibernate";
            this.chkHibernate.Size = new System.Drawing.Size(72, 17);
            this.chkHibernate.TabIndex = 16;
            this.chkHibernate.Text = "Hibernate";
            this.chkHibernate.UseVisualStyleBackColor = true;
            this.chkHibernate.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkmute
            // 
            this.chkmute.AutoSize = true;
            this.chkmute.Location = new System.Drawing.Point(24, 20);
            this.chkmute.Name = "chkmute";
            this.chkmute.Size = new System.Drawing.Size(92, 17);
            this.chkmute.TabIndex = 15;
            this.chkmute.Text = "Mute/Unmute";
            this.chkmute.UseVisualStyleBackColor = true;
            this.chkmute.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkShutdown
            // 
            this.chkShutdown.AutoSize = true;
            this.chkShutdown.Location = new System.Drawing.Point(24, 88);
            this.chkShutdown.Name = "chkShutdown";
            this.chkShutdown.Size = new System.Drawing.Size(74, 17);
            this.chkShutdown.TabIndex = 15;
            this.chkShutdown.Text = "Shutdown";
            this.chkShutdown.UseVisualStyleBackColor = true;
            this.chkShutdown.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // chkSuspend
            // 
            this.chkSuspend.AutoSize = true;
            this.chkSuspend.Location = new System.Drawing.Point(24, 66);
            this.chkSuspend.Name = "chkSuspend";
            this.chkSuspend.Size = new System.Drawing.Size(68, 17);
            this.chkSuspend.TabIndex = 14;
            this.chkSuspend.Text = "Suspend";
            this.chkSuspend.UseVisualStyleBackColor = true;
            this.chkSuspend.CheckStateChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(694, 587);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Camera";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.chkScreenDumpPrimonitor);
            this.groupBox1.Location = new System.Drawing.Point(7, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 218);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screenshots";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Interval(ms)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 100);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-81, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Path";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(175, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 30;
            // 
            // chkScreenDumpPrimonitor
            // 
            this.chkScreenDumpPrimonitor.AutoSize = true;
            this.chkScreenDumpPrimonitor.Location = new System.Drawing.Point(23, 28);
            this.chkScreenDumpPrimonitor.Name = "chkScreenDumpPrimonitor";
            this.chkScreenDumpPrimonitor.Size = new System.Drawing.Size(165, 17);
            this.chkScreenDumpPrimonitor.TabIndex = 29;
            this.chkScreenDumpPrimonitor.Text = "Screenshot of primary monitor";
            this.chkScreenDumpPrimonitor.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ChkEnableWebCamPublish);
            this.groupBox10.Controls.Add(this.CmdWebCamTest);
            this.groupBox10.Controls.Add(this.cmbWebcam);
            this.groupBox10.Location = new System.Drawing.Point(7, 159);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(352, 151);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Webcam";
            // 
            // ChkEnableWebCamPublish
            // 
            this.ChkEnableWebCamPublish.AutoSize = true;
            this.ChkEnableWebCamPublish.Location = new System.Drawing.Point(15, 29);
            this.ChkEnableWebCamPublish.Name = "ChkEnableWebCamPublish";
            this.ChkEnableWebCamPublish.Size = new System.Drawing.Size(59, 17);
            this.ChkEnableWebCamPublish.TabIndex = 56;
            this.ChkEnableWebCamPublish.Text = "Enable";
            this.ChkEnableWebCamPublish.UseVisualStyleBackColor = true;
            this.ChkEnableWebCamPublish.CheckedChanged += new System.EventHandler(this.ChkEnableWebCamPublish_CheckedChanged);
            // 
            // CmdWebCamTest
            // 
            this.CmdWebCamTest.Location = new System.Drawing.Point(226, 78);
            this.CmdWebCamTest.Name = "CmdWebCamTest";
            this.CmdWebCamTest.Size = new System.Drawing.Size(80, 24);
            this.CmdWebCamTest.TabIndex = 55;
            this.CmdWebCamTest.Text = "Test";
            this.CmdWebCamTest.UseVisualStyleBackColor = true;
            this.CmdWebCamTest.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cmbWebcam
            // 
            this.cmbWebcam.FormattingEnabled = true;
            this.cmbWebcam.Location = new System.Drawing.Point(88, 29);
            this.cmbWebcam.Name = "cmbWebcam";
            this.cmbWebcam.Size = new System.Drawing.Size(219, 21);
            this.cmbWebcam.TabIndex = 54;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkScreenshotMqtt);
            this.groupBox5.Controls.Add(this.LblScreenshotPath);
            this.groupBox5.Controls.Add(this.txtScreenshotPath);
            this.groupBox5.Controls.Add(this.chkScreenshot);
            this.groupBox5.Location = new System.Drawing.Point(7, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(352, 70);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Screenshot";
            // 
            // chkScreenshotMqtt
            // 
            this.chkScreenshotMqtt.AutoSize = true;
            this.chkScreenshotMqtt.Location = new System.Drawing.Point(95, 19);
            this.chkScreenshotMqtt.Name = "chkScreenshotMqtt";
            this.chkScreenshotMqtt.Size = new System.Drawing.Size(57, 17);
            this.chkScreenshotMqtt.TabIndex = 3;
            this.chkScreenshotMqtt.Text = "MQTT";
            this.chkScreenshotMqtt.UseVisualStyleBackColor = true;
            // 
            // LblScreenshotPath
            // 
            this.LblScreenshotPath.AutoSize = true;
            this.LblScreenshotPath.Location = new System.Drawing.Point(19, 44);
            this.LblScreenshotPath.Name = "LblScreenshotPath";
            this.LblScreenshotPath.Size = new System.Drawing.Size(29, 13);
            this.LblScreenshotPath.TabIndex = 2;
            this.LblScreenshotPath.Text = "Path";
            // 
            // txtScreenshotPath
            // 
            this.txtScreenshotPath.Location = new System.Drawing.Point(88, 41);
            this.txtScreenshotPath.Name = "txtScreenshotPath";
            this.txtScreenshotPath.Size = new System.Drawing.Size(219, 20);
            this.txtScreenshotPath.TabIndex = 1;
            // 
            // chkScreenshot
            // 
            this.chkScreenshot.AutoSize = true;
            this.chkScreenshot.Location = new System.Drawing.Point(18, 19);
            this.chkScreenshot.Name = "chkScreenshot";
            this.chkScreenshot.Size = new System.Drawing.Size(59, 17);
            this.chkScreenshot.TabIndex = 0;
            this.chkScreenshot.Text = "Enable";
            this.chkScreenshot.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.ChkSlideshow);
            this.groupBox7.Controls.Add(this.txtSlideshowFolder);
            this.groupBox7.Location = new System.Drawing.Point(7, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(352, 74);
            this.groupBox7.TabIndex = 54;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Slideshow";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Filepath";
            // 
            // ChkSlideshow
            // 
            this.ChkSlideshow.AutoSize = true;
            this.ChkSlideshow.Location = new System.Drawing.Point(15, 19);
            this.ChkSlideshow.Name = "ChkSlideshow";
            this.ChkSlideshow.Size = new System.Drawing.Size(74, 17);
            this.ChkSlideshow.TabIndex = 50;
            this.ChkSlideshow.Text = "Slideshow";
            this.ChkSlideshow.UseVisualStyleBackColor = true;
            // 
            // txtSlideshowFolder
            // 
            this.txtSlideshowFolder.Location = new System.Drawing.Point(88, 48);
            this.txtSlideshowFolder.Name = "txtSlideshowFolder";
            this.txtSlideshowFolder.Size = new System.Drawing.Size(219, 20);
            this.txtSlideshowFolder.TabIndex = 49;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(694, 587);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Commands";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox9);
            this.tabPage6.Controls.Add(this.groupBox8);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(694, 587);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Sound";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkTtsEnabled);
            this.groupBox9.Controls.Add(this.CmdTestSpeaker);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.cmbSpeaker);
            this.groupBox9.Location = new System.Drawing.Point(7, 106);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(352, 108);
            this.groupBox9.TabIndex = 56;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Text to speach";
            // 
            // chkTtsEnabled
            // 
            this.chkTtsEnabled.AutoSize = true;
            this.chkTtsEnabled.Location = new System.Drawing.Point(24, 20);
            this.chkTtsEnabled.Name = "chkTtsEnabled";
            this.chkTtsEnabled.Size = new System.Drawing.Size(83, 17);
            this.chkTtsEnabled.TabIndex = 59;
            this.chkTtsEnabled.Text = "Enable TTS";
            this.chkTtsEnabled.UseVisualStyleBackColor = true;
            this.chkTtsEnabled.CheckedChanged += new System.EventHandler(this.ChkTtsEnabled_CheckedChanged);
            // 
            // CmdTestSpeaker
            // 
            this.CmdTestSpeaker.Location = new System.Drawing.Point(286, 43);
            this.CmdTestSpeaker.Name = "CmdTestSpeaker";
            this.CmdTestSpeaker.Size = new System.Drawing.Size(42, 23);
            this.CmdTestSpeaker.TabIndex = 58;
            this.CmdTestSpeaker.Text = "test";
            this.CmdTestSpeaker.UseVisualStyleBackColor = true;
            this.CmdTestSpeaker.Click += new System.EventHandler(this.CmdTestSpeaker_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "TTS speaker";
            // 
            // cmbSpeaker
            // 
            this.cmbSpeaker.FormattingEnabled = true;
            this.cmbSpeaker.Location = new System.Drawing.Point(111, 43);
            this.cmbSpeaker.Name = "cmbSpeaker";
            this.cmbSpeaker.Size = new System.Drawing.Size(166, 21);
            this.cmbSpeaker.TabIndex = 56;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBox2);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.cmbAudioOutput);
            this.groupBox8.Location = new System.Drawing.Point(7, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(352, 97);
            this.groupBox8.TabIndex = 52;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Audio device";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(24, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 17);
            this.checkBox2.TabIndex = 61;
            this.checkBox2.Text = "Use non-default device";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "Audio device";
            // 
            // cmbAudioOutput
            // 
            this.cmbAudioOutput.FormattingEnabled = true;
            this.cmbAudioOutput.Location = new System.Drawing.Point(111, 42);
            this.cmbAudioOutput.Name = "cmbAudioOutput";
            this.cmbAudioOutput.Size = new System.Drawing.Size(213, 21);
            this.cmbAudioOutput.TabIndex = 51;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.chkMinimizeToTray);
            this.tabPage7.Controls.Add(this.chkStartUp);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(694, 587);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Application";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(7, 35);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(98, 17);
            this.chkMinimizeToTray.TabIndex = 43;
            this.chkMinimizeToTray.Text = "Minimize to tray";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(7, 3);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(81, 17);
            this.chkStartUp.TabIndex = 42;
            this.chkStartUp.Text = "Run at start";
            this.chkStartUp.UseVisualStyleBackColor = true;
            this.chkStartUp.CheckedChanged += new System.EventHandler(this.ChkStartUp_CheckedChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.CmdDiscovery);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(694, 587);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Discovery";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // CmdDiscovery
            // 
            this.CmdDiscovery.Enabled = false;
            this.CmdDiscovery.Location = new System.Drawing.Point(40, 24);
            this.CmdDiscovery.Name = "CmdDiscovery";
            this.CmdDiscovery.Size = new System.Drawing.Size(155, 23);
            this.CmdDiscovery.TabIndex = 0;
            this.CmdDiscovery.Text = "Send discovery";
            this.CmdDiscovery.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 691);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CmdClose);
            this.Controls.Add(this.CmdSave);
            this.Name = "FrmOptions";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMqttTimerInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmqtttopic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmqttpassword;
        private System.Windows.Forms.TextBox txtmqttusername;
        private System.Windows.Forms.TextBox txtmqttserver;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox ChkComputerUsed;
        private System.Windows.Forms.CheckBox chkVolumeSensor;
        private System.Windows.Forms.CheckBox chkCpuSensor;
        private System.Windows.Forms.CheckBox chkMemorySensor;
        private System.Windows.Forms.CheckBox ChkDiskSensor;
        private System.Windows.Forms.CheckBox ChkBatterySensor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ChkProcesses;
        private System.Windows.Forms.CheckBox ChkMonitor;
        private System.Windows.Forms.CheckBox chktoast;
        private System.Windows.Forms.CheckBox chkTTS;
        private System.Windows.Forms.CheckBox chkReboot;
        private System.Windows.Forms.CheckBox ChkVolume;
        private System.Windows.Forms.CheckBox chkHibernate;
        private System.Windows.Forms.CheckBox chkmute;
        private System.Windows.Forms.CheckBox chkShutdown;
        private System.Windows.Forms.CheckBox chkSuspend;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkScreenshotMqtt;
        private System.Windows.Forms.Label LblScreenshotPath;
        private System.Windows.Forms.TextBox txtScreenshotPath;
        private System.Windows.Forms.CheckBox chkScreenshot;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ChkSlideshow;
        private System.Windows.Forms.TextBox txtSlideshowFolder;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button CmdTestSpeaker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSpeaker;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbAudioOutput;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.CheckBox chkStartUp;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cmbWebcam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkScreenDumpPrimonitor;
        private System.Windows.Forms.Button CmdWebCamTest;
        private System.Windows.Forms.CheckBox ChkEnableWebCamPublish;
        private System.Windows.Forms.CheckBox chkTtsEnabled;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button CmdDiscovery;
        private System.Windows.Forms.TextBox textBox4;
    }
}