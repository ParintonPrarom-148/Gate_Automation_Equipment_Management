namespace AGOS_GATE_EQUIPMENT
{
    partial class BarrierPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarrierPage));
            this.BackPage = new System.Windows.Forms.Button();
            this.CheckThreadTime = new System.Windows.Forms.TextBox();
            this.ResOriginTxt = new System.Windows.Forms.Label();
            this.ResOriginal = new System.Windows.Forms.TextBox();
            this.ResponseOC2 = new System.Windows.Forms.Label();
            this.ResponseOC = new System.Windows.Forms.TextBox();
            this.RequestOPtxt = new System.Windows.Forms.Label();
            this.RequestOP = new System.Windows.Forms.TextBox();
            this.ResponseBarrierBoxtxt = new System.Windows.Forms.Label();
            this.ResponseBarrierBox = new System.Windows.Forms.TextBox();
            this.StatusTxt = new System.Windows.Forms.Label();
            this.RsensorTxt = new System.Windows.Forms.Label();
            this.SaveIP = new System.Windows.Forms.Button();
            this.IPbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SensorStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RestStatus = new System.Windows.Forms.TextBox();
            this.ShowRealy = new System.Windows.Forms.Button();
            this.OpenB = new System.Windows.Forms.Button();
            this.BarrierStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseB = new System.Windows.Forms.Button();
            this.Test = new System.Windows.Forms.Button();
            this.AutoRestTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.IconMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuration_and_Control_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ID_Card_Reader_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Barrier_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Application_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusL = new System.Windows.Forms.Label();
            this.LabelBarrier = new System.Windows.Forms.Label();
            this.LabelLocation = new System.Windows.Forms.Label();
            this.FB_Test = new System.Windows.Forms.Button();
            this.BarrierIcon = new System.Windows.Forms.PictureBox();
            this.BarrierControl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // BackPage
            // 
            this.BackPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.BackPage.ForeColor = System.Drawing.Color.White;
            this.BackPage.Location = new System.Drawing.Point(11, 498);
            this.BackPage.Margin = new System.Windows.Forms.Padding(2);
            this.BackPage.Name = "BackPage";
            this.BackPage.Size = new System.Drawing.Size(63, 28);
            this.BackPage.TabIndex = 67;
            this.BackPage.Text = "Back";
            this.BackPage.UseVisualStyleBackColor = false;
            this.BackPage.Click += new System.EventHandler(this.BackPage_Click);
            // 
            // CheckThreadTime
            // 
            this.CheckThreadTime.Location = new System.Drawing.Point(463, 375);
            this.CheckThreadTime.Margin = new System.Windows.Forms.Padding(2);
            this.CheckThreadTime.Multiline = true;
            this.CheckThreadTime.Name = "CheckThreadTime";
            this.CheckThreadTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CheckThreadTime.Size = new System.Drawing.Size(128, 151);
            this.CheckThreadTime.TabIndex = 66;
            this.CheckThreadTime.Visible = false;
            this.CheckThreadTime.TextChanged += new System.EventHandler(this.CheckThreadTime_TextChanged);
            // 
            // ResOriginTxt
            // 
            this.ResOriginTxt.AutoSize = true;
            this.ResOriginTxt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResOriginTxt.Location = new System.Drawing.Point(684, 247);
            this.ResOriginTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResOriginTxt.Name = "ResOriginTxt";
            this.ResOriginTxt.Size = new System.Drawing.Size(177, 15);
            this.ResOriginTxt.TabIndex = 65;
            this.ResOriginTxt.Text = "Response(open/close)Original";
            this.ResOriginTxt.Visible = false;
            // 
            // ResOriginal
            // 
            this.ResOriginal.Location = new System.Drawing.Point(687, 264);
            this.ResOriginal.Margin = new System.Windows.Forms.Padding(2);
            this.ResOriginal.Multiline = true;
            this.ResOriginal.Name = "ResOriginal";
            this.ResOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResOriginal.Size = new System.Drawing.Size(139, 151);
            this.ResOriginal.TabIndex = 64;
            this.ResOriginal.Visible = false;
            // 
            // ResponseOC2
            // 
            this.ResponseOC2.AutoSize = true;
            this.ResponseOC2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseOC2.Location = new System.Drawing.Point(867, 82);
            this.ResponseOC2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResponseOC2.Name = "ResponseOC2";
            this.ResponseOC2.Size = new System.Drawing.Size(134, 15);
            this.ResponseOC2.TabIndex = 63;
            this.ResponseOC2.Text = "Response(open/close)";
            this.ResponseOC2.Visible = false;
            // 
            // ResponseOC
            // 
            this.ResponseOC.Location = new System.Drawing.Point(870, 94);
            this.ResponseOC.Margin = new System.Windows.Forms.Padding(2);
            this.ResponseOC.Multiline = true;
            this.ResponseOC.Name = "ResponseOC";
            this.ResponseOC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResponseOC.Size = new System.Drawing.Size(139, 151);
            this.ResponseOC.TabIndex = 62;
            this.ResponseOC.Visible = false;
            // 
            // RequestOPtxt
            // 
            this.RequestOPtxt.AutoSize = true;
            this.RequestOPtxt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestOPtxt.Location = new System.Drawing.Point(867, 247);
            this.RequestOPtxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RequestOPtxt.Name = "RequestOPtxt";
            this.RequestOPtxt.Size = new System.Drawing.Size(118, 15);
            this.RequestOPtxt.TabIndex = 61;
            this.RequestOPtxt.Text = "Request open/close";
            this.RequestOPtxt.Visible = false;
            // 
            // RequestOP
            // 
            this.RequestOP.Location = new System.Drawing.Point(870, 264);
            this.RequestOP.Margin = new System.Windows.Forms.Padding(2);
            this.RequestOP.Multiline = true;
            this.RequestOP.Name = "RequestOP";
            this.RequestOP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RequestOP.Size = new System.Drawing.Size(139, 151);
            this.RequestOP.TabIndex = 60;
            this.RequestOP.Visible = false;
            // 
            // ResponseBarrierBoxtxt
            // 
            this.ResponseBarrierBoxtxt.AutoSize = true;
            this.ResponseBarrierBoxtxt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseBarrierBoxtxt.Location = new System.Drawing.Point(174, 358);
            this.ResponseBarrierBoxtxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ResponseBarrierBoxtxt.Name = "ResponseBarrierBoxtxt";
            this.ResponseBarrierBoxtxt.Size = new System.Drawing.Size(110, 15);
            this.ResponseBarrierBoxtxt.TabIndex = 59;
            this.ResponseBarrierBoxtxt.Text = "Response(Barrier)";
            this.ResponseBarrierBoxtxt.Visible = false;
            // 
            // ResponseBarrierBox
            // 
            this.ResponseBarrierBox.Location = new System.Drawing.Point(177, 375);
            this.ResponseBarrierBox.Margin = new System.Windows.Forms.Padding(2);
            this.ResponseBarrierBox.Multiline = true;
            this.ResponseBarrierBox.Name = "ResponseBarrierBox";
            this.ResponseBarrierBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResponseBarrierBox.Size = new System.Drawing.Size(139, 151);
            this.ResponseBarrierBox.TabIndex = 58;
            this.ResponseBarrierBox.Visible = false;
            // 
            // StatusTxt
            // 
            this.StatusTxt.AutoSize = true;
            this.StatusTxt.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTxt.Location = new System.Drawing.Point(652, 503);
            this.StatusTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.Size = new System.Drawing.Size(58, 17);
            this.StatusTxt.TabIndex = 56;
            this.StatusTxt.Text = "Status :";
            this.StatusTxt.Visible = false;
            // 
            // RsensorTxt
            // 
            this.RsensorTxt.AutoSize = true;
            this.RsensorTxt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RsensorTxt.Location = new System.Drawing.Point(316, 358);
            this.RsensorTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RsensorTxt.Name = "RsensorTxt";
            this.RsensorTxt.Size = new System.Drawing.Size(113, 15);
            this.RsensorTxt.TabIndex = 55;
            this.RsensorTxt.Text = "Response(Sensor)";
            this.RsensorTxt.Visible = false;
            // 
            // SaveIP
            // 
            this.SaveIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.SaveIP.ForeColor = System.Drawing.Color.White;
            this.SaveIP.Location = new System.Drawing.Point(934, 498);
            this.SaveIP.Margin = new System.Windows.Forms.Padding(2);
            this.SaveIP.Name = "SaveIP";
            this.SaveIP.Size = new System.Drawing.Size(63, 28);
            this.SaveIP.TabIndex = 54;
            this.SaveIP.Text = "Save";
            this.SaveIP.UseVisualStyleBackColor = false;
            this.SaveIP.Click += new System.EventHandler(this.SaveIP_Click);
            // 
            // IPbox
            // 
            this.IPbox.Location = new System.Drawing.Point(444, 117);
            this.IPbox.Margin = new System.Windows.Forms.Padding(2);
            this.IPbox.Name = "IPbox";
            this.IPbox.Size = new System.Drawing.Size(200, 20);
            this.IPbox.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "Barrier IP ";
            // 
            // SensorStatus
            // 
            this.SensorStatus.AutoSize = true;
            this.SensorStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensorStatus.Location = new System.Drawing.Point(441, 161);
            this.SensorStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SensorStatus.Name = "SensorStatus";
            this.SensorStatus.Size = new System.Drawing.Size(13, 18);
            this.SensorStatus.TabIndex = 51;
            this.SensorStatus.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Sensor Status ";

            // 
            // RestStatus
            // 
            this.RestStatus.Location = new System.Drawing.Point(713, 503);
            this.RestStatus.Margin = new System.Windows.Forms.Padding(2);
            this.RestStatus.Multiline = true;
            this.RestStatus.Name = "RestStatus";
            this.RestStatus.Size = new System.Drawing.Size(217, 17);
            this.RestStatus.TabIndex = 49;
            this.RestStatus.Visible = false;
            // 
            // ShowRealy
            // 
            this.ShowRealy.Location = new System.Drawing.Point(11, 469);
            this.ShowRealy.Margin = new System.Windows.Forms.Padding(2);
            this.ShowRealy.Name = "ShowRealy";
            this.ShowRealy.Size = new System.Drawing.Size(63, 25);
            this.ShowRealy.TabIndex = 48;
            this.ShowRealy.Text = "Show Tools";
            this.ShowRealy.UseVisualStyleBackColor = true;
            this.ShowRealy.Visible = false;
            this.ShowRealy.Click += new System.EventHandler(this.ShowRealy_Click);
            // 
            // OpenB
            // 
            this.OpenB.Location = new System.Drawing.Point(446, 252);
            this.OpenB.Margin = new System.Windows.Forms.Padding(2);
            this.OpenB.Name = "OpenB";
            this.OpenB.Size = new System.Drawing.Size(84, 28);
            this.OpenB.TabIndex = 47;
            this.OpenB.Text = "Open";
            this.OpenB.UseVisualStyleBackColor = true;
            this.OpenB.Click += new System.EventHandler(this.OpenB_Click);
            // 
            // BarrierStatus
            // 
            this.BarrierStatus.AutoSize = true;
            this.BarrierStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarrierStatus.Location = new System.Drawing.Point(441, 207);
            this.BarrierStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BarrierStatus.Name = "BarrierStatus";
            this.BarrierStatus.Size = new System.Drawing.Size(13, 18);
            this.BarrierStatus.TabIndex = 46;
            this.BarrierStatus.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Barrier Status ";
            // 
            // CloseB
            // 
            this.CloseB.Location = new System.Drawing.Point(528, 252);
            this.CloseB.Margin = new System.Windows.Forms.Padding(2);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(84, 28);
            this.CloseB.TabIndex = 44;
            this.CloseB.Text = "Close";
            this.CloseB.UseVisualStyleBackColor = true;
            this.CloseB.Click += new System.EventHandler(this.CloseB_Click);
            // 
            // Test
            // 
            this.Test.Location = new System.Drawing.Point(934, 469);
            this.Test.Margin = new System.Windows.Forms.Padding(2);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(60, 25);
            this.Test.TabIndex = 43;
            this.Test.Text = "GET";
            this.Test.UseVisualStyleBackColor = true;
            this.Test.Visible = false;
            // 
            // AutoRestTextBox
            // 
            this.AutoRestTextBox.Location = new System.Drawing.Point(322, 375);
            this.AutoRestTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AutoRestTextBox.Multiline = true;
            this.AutoRestTextBox.Name = "AutoRestTextBox";
            this.AutoRestTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AutoRestTextBox.Size = new System.Drawing.Size(136, 151);
            this.AutoRestTextBox.TabIndex = 42;
            this.AutoRestTextBox.Visible = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(43, 12);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(396, 32);
            this.label.TabIndex = 23;
            this.label.Text = "Configuration Setup - Barrier";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 54);
            this.panel1.TabIndex = 23;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IconMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menu.Size = new System.Drawing.Size(1283, 44);
            this.menu.TabIndex = 24;
            // 
            // IconMenu
            // 
            this.IconMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.IconMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Menu,
            this.Configuration_and_Control_Setup_Menu,
            this.Application_Setup_Menu});
            this.IconMenu.Image = ((System.Drawing.Image)(resources.GetObject("IconMenu.Image")));
            this.IconMenu.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.IconMenu.Name = "IconMenu";
            this.IconMenu.Size = new System.Drawing.Size(40, 32);
            // 
            // Monitoring_Menu
            // 
            this.Monitoring_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.Monitoring_Menu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Monitoring_Menu.Name = "Monitoring_Menu";
            this.Monitoring_Menu.Size = new System.Drawing.Size(247, 22);
            this.Monitoring_Menu.Text = "Monitoring";
            this.Monitoring_Menu.Click += new System.EventHandler(this.Monitoring_Menu_Click);
            // 
            // Configuration_and_Control_Setup_Menu
            // 
            this.Configuration_and_Control_Setup_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.Configuration_and_Control_Setup_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ID_Card_Reader_Setup_Menu,
            this.Barrier_Setup_Menu});
            this.Configuration_and_Control_Setup_Menu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Configuration_and_Control_Setup_Menu.Name = "Configuration_and_Control_Setup_Menu";
            this.Configuration_and_Control_Setup_Menu.Size = new System.Drawing.Size(247, 22);
            this.Configuration_and_Control_Setup_Menu.Text = "Configuration and Control Setup";
            // 
            // ID_Card_Reader_Setup_Menu
            // 
            this.ID_Card_Reader_Setup_Menu.BackColor = System.Drawing.Color.White;
            this.ID_Card_Reader_Setup_Menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.ID_Card_Reader_Setup_Menu.Name = "ID_Card_Reader_Setup_Menu";
            this.ID_Card_Reader_Setup_Menu.Size = new System.Drawing.Size(185, 22);
            this.ID_Card_Reader_Setup_Menu.Text = "ID Card Reader Setup";
            this.ID_Card_Reader_Setup_Menu.Click += new System.EventHandler(this.ID_Card_Reader_Setup_Menu_Click);
            // 
            // Barrier_Setup_Menu
            // 
            this.Barrier_Setup_Menu.BackColor = System.Drawing.Color.White;
            this.Barrier_Setup_Menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.Barrier_Setup_Menu.Name = "Barrier_Setup_Menu";
            this.Barrier_Setup_Menu.Size = new System.Drawing.Size(185, 22);
            this.Barrier_Setup_Menu.Text = "Barrier Setup";
            this.Barrier_Setup_Menu.Click += new System.EventHandler(this.Barrier_Setup_Menu_Click);
            // 
            // Application_Setup_Menu
            // 
            this.Application_Setup_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.Application_Setup_Menu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Application_Setup_Menu.Name = "Application_Setup_Menu";
            this.Application_Setup_Menu.Size = new System.Drawing.Size(247, 22);
            this.Application_Setup_Menu.Text = "Application Setup";
            this.Application_Setup_Menu.Click += new System.EventHandler(this.Application_Setup_Menu_Click);
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusL.Location = new System.Drawing.Point(432, 74);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(85, 22);
            this.StatusL.TabIndex = 108;
            this.StatusL.Text = "D1GH01";
            // 
            // LabelBarrier
            // 
            this.LabelBarrier.AutoSize = true;
            this.LabelBarrier.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBarrier.Location = new System.Drawing.Point(522, 74);
            this.LabelBarrier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelBarrier.Name = "LabelBarrier";
            this.LabelBarrier.Size = new System.Drawing.Size(151, 22);
            this.LabelBarrier.TabIndex = 99;
            this.LabelBarrier.Text = "Barrier Status :";
            // 
            // LabelLocation
            // 
            this.LabelLocation.AutoSize = true;
            this.LabelLocation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLocation.Location = new System.Drawing.Point(324, 74);
            this.LabelLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLocation.Name = "LabelLocation";
            this.LabelLocation.Size = new System.Drawing.Size(103, 22);
            this.LabelLocation.TabIndex = 97;
            this.LabelLocation.Text = "Location :";
            // 
            // FB_Test
            // 
            this.FB_Test.Location = new System.Drawing.Point(11, 437);
            this.FB_Test.Margin = new System.Windows.Forms.Padding(2);
            this.FB_Test.Name = "FB_Test";
            this.FB_Test.Size = new System.Drawing.Size(63, 28);
            this.FB_Test.TabIndex = 89;
            this.FB_Test.Text = "Test";
            this.FB_Test.UseVisualStyleBackColor = true;
            this.FB_Test.Visible = false;
            this.FB_Test.Click += new System.EventHandler(this.FB_Test_Click);
            // 
            // BarrierIcon
            // 
            this.BarrierIcon.Image = ((System.Drawing.Image)(resources.GetObject("BarrierIcon.Image")));
            this.BarrierIcon.Location = new System.Drawing.Point(678, 67);
            this.BarrierIcon.Name = "BarrierIcon";
            this.BarrierIcon.Size = new System.Drawing.Size(38, 36);
            this.BarrierIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BarrierIcon.TabIndex = 106;
            this.BarrierIcon.TabStop = false;
            // 
            // BarrierControl
            // 
            this.BarrierControl.AutoSize = true;
            this.BarrierControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarrierControl.Location = new System.Drawing.Point(329, 256);
            this.BarrierControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BarrierControl.Name = "BarrierControl";
            this.BarrierControl.Size = new System.Drawing.Size(114, 18);
            this.BarrierControl.TabIndex = 109;
            this.BarrierControl.Text = "Barrier Control ";
            // 
            // BarrierPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.BarrierControl);
            this.Controls.Add(this.BarrierIcon);
            this.Controls.Add(this.FB_Test);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.LabelBarrier);
            this.Controls.Add(this.LabelLocation);
            this.Controls.Add(this.BackPage);
            this.Controls.Add(this.CheckThreadTime);
            this.Controls.Add(this.ResOriginTxt);
            this.Controls.Add(this.ResOriginal);
            this.Controls.Add(this.ResponseOC2);
            this.Controls.Add(this.ResponseOC);
            this.Controls.Add(this.RequestOPtxt);
            this.Controls.Add(this.RequestOP);
            this.Controls.Add(this.ResponseBarrierBoxtxt);
            this.Controls.Add(this.ResponseBarrierBox);
            this.Controls.Add(this.StatusTxt);
            this.Controls.Add(this.RsensorTxt);
            this.Controls.Add(this.SaveIP);
            this.Controls.Add(this.IPbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SensorStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RestStatus);
            this.Controls.Add(this.ShowRealy);
            this.Controls.Add(this.OpenB);
            this.Controls.Add(this.BarrierStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseB);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.AutoRestTextBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BarrierPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate Automation Equipment Management";
            this.Load += new System.EventHandler(this.BarrierPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BackPage;
        private System.Windows.Forms.TextBox CheckThreadTime;
        private System.Windows.Forms.Label ResOriginTxt;
        private System.Windows.Forms.TextBox ResOriginal;
        private System.Windows.Forms.Label ResponseOC2;
        private System.Windows.Forms.TextBox ResponseOC;
        private System.Windows.Forms.Label RequestOPtxt;
        private System.Windows.Forms.TextBox RequestOP;
        private System.Windows.Forms.Label ResponseBarrierBoxtxt;
        private System.Windows.Forms.TextBox ResponseBarrierBox;
        private System.Windows.Forms.Label StatusTxt;
        private System.Windows.Forms.Label RsensorTxt;
        private System.Windows.Forms.Button SaveIP;
        private System.Windows.Forms.TextBox IPbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SensorStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RestStatus;
        private System.Windows.Forms.Button ShowRealy;
        private System.Windows.Forms.Button OpenB;
        private System.Windows.Forms.Label BarrierStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseB;
        private System.Windows.Forms.Button Test;
        private System.Windows.Forms.TextBox AutoRestTextBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label StatusL;
        private System.Windows.Forms.Label LabelBarrier;
        private System.Windows.Forms.Label LabelLocation;
        private System.Windows.Forms.Button FB_Test;
        private System.Windows.Forms.PictureBox BarrierIcon;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem IconMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Menu;
        private System.Windows.Forms.ToolStripMenuItem Configuration_and_Control_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem ID_Card_Reader_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem Barrier_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem Application_Setup_Menu;
        private System.Windows.Forms.Label BarrierControl;
    }
}