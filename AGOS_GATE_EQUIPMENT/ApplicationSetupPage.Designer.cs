namespace AGOS_GATE_EQUIPMENT
{
    partial class ApplicationSetupPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSetupPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.IconMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuration_and_Control_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ID_Card_Reader_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Barrier_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Application_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IPbox = new System.Windows.Forms.TextBox();
            this.LocationLogFileBox = new System.Windows.Forms.TextBox();
            this.ReaderNameBOX = new System.Windows.Forms.TextBox();
            this.RemarkBox = new System.Windows.Forms.TextBox();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.BackBTN = new System.Windows.Forms.Button();
            this.LabelLocation = new System.Windows.Forms.Label();
            this.BarrierNameBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.StatusL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 54);
            this.panel1.TabIndex = 24;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(43, 12);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(248, 32);
            this.label.TabIndex = 23;
            this.label.Text = "Application Setup";

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
            this.menu.Size = new System.Drawing.Size(1093, 44);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kiosk Location Log File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 26;
            this.label2.Text = "Kiosk IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "ID Card Reader Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 371);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 28;
            this.label5.Text = "Remark";
            // 
            // IPbox
            // 
            this.IPbox.Location = new System.Drawing.Point(545, 121);
            this.IPbox.Margin = new System.Windows.Forms.Padding(2);
            this.IPbox.Name = "IPbox";
            this.IPbox.Size = new System.Drawing.Size(177, 20);
            this.IPbox.TabIndex = 29;
            this.IPbox.TextChanged += new System.EventHandler(this.IPbox_TextChanged);
            // 
            // LocationLogFileBox
            // 
            this.LocationLogFileBox.Location = new System.Drawing.Point(545, 183);
            this.LocationLogFileBox.Margin = new System.Windows.Forms.Padding(2);
            this.LocationLogFileBox.Name = "LocationLogFileBox";
            this.LocationLogFileBox.Size = new System.Drawing.Size(177, 20);
            this.LocationLogFileBox.TabIndex = 30;
            // 
            // ReaderNameBOX
            // 
            this.ReaderNameBOX.Location = new System.Drawing.Point(545, 309);
            this.ReaderNameBOX.Margin = new System.Windows.Forms.Padding(2);
            this.ReaderNameBOX.Name = "ReaderNameBOX";
            this.ReaderNameBOX.Size = new System.Drawing.Size(177, 20);
            this.ReaderNameBOX.TabIndex = 31;
            // 
            // RemarkBox
            // 
            this.RemarkBox.Location = new System.Drawing.Point(545, 374);
            this.RemarkBox.Margin = new System.Windows.Forms.Padding(2);
            this.RemarkBox.Name = "RemarkBox";
            this.RemarkBox.Size = new System.Drawing.Size(177, 20);
            this.RemarkBox.TabIndex = 32;
            // 
            // SaveBTN
            // 
            this.SaveBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.SaveBTN.ForeColor = System.Drawing.Color.White;
            this.SaveBTN.Location = new System.Drawing.Point(935, 497);
            this.SaveBTN.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(62, 29);
            this.SaveBTN.TabIndex = 76;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = false;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // BackBTN
            // 
            this.BackBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.BackBTN.ForeColor = System.Drawing.Color.White;
            this.BackBTN.Location = new System.Drawing.Point(11, 497);
            this.BackBTN.Margin = new System.Windows.Forms.Padding(2);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(62, 29);
            this.BackBTN.TabIndex = 77;
            this.BackBTN.Text = "Back";
            this.BackBTN.UseVisualStyleBackColor = false;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // LabelLocation
            // 
            this.LabelLocation.AutoSize = true;
            this.LabelLocation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLocation.Location = new System.Drawing.Point(414, 74);
            this.LabelLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLocation.Name = "LabelLocation";
            this.LabelLocation.Size = new System.Drawing.Size(103, 22);
            this.LabelLocation.TabIndex = 97;
            this.LabelLocation.Text = "Location :";
            // 
            // BarrierNameBox
            // 
            this.BarrierNameBox.Location = new System.Drawing.Point(545, 246);
            this.BarrierNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.BarrierNameBox.Name = "BarrierNameBox";
            this.BarrierNameBox.Size = new System.Drawing.Size(177, 20);
            this.BarrierNameBox.TabIndex = 98;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(317, 243);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 21);
            this.label14.TabIndex = 97;
            this.label14.Text = "Barrier File Name";
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusL.Location = new System.Drawing.Point(522, 74);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(85, 22);
            this.StatusL.TabIndex = 108;
            this.StatusL.Text = "D1GH01";
            // 
            // ApplicationSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.BarrierNameBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LabelLocation);
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.RemarkBox);
            this.Controls.Add(this.ReaderNameBOX);
            this.Controls.Add(this.LocationLogFileBox);
            this.Controls.Add(this.IPbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ApplicationSetupPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Setup";
            this.Load += new System.EventHandler(this.ApplicationSetupPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IPbox;
        private System.Windows.Forms.TextBox LocationLogFileBox;
        private System.Windows.Forms.TextBox ReaderNameBOX;
        private System.Windows.Forms.TextBox RemarkBox;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.Label LabelLocation;
        private System.Windows.Forms.TextBox BarrierNameBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem IconMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Menu;
        private System.Windows.Forms.ToolStripMenuItem Configuration_and_Control_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem ID_Card_Reader_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem Barrier_Setup_Menu;
        private System.Windows.Forms.ToolStripMenuItem Application_Setup_Menu;
        private System.Windows.Forms.Label StatusL;
    }
}