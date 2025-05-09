using System.Windows.Forms;
using System;

namespace AGOS_GATE_EQUIPMENT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.IconMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuration_and_Control_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ID_Card_Reader_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Barrier_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Application_Setup_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportLogView = new System.Windows.Forms.DataGridView();
            this.BarrierShowLog = new System.Windows.Forms.Button();
            this.ReaderShowLog = new System.Windows.Forms.Button();
            this.BarrierViewL = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ReaderViewL = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.LabelReader = new System.Windows.Forms.Label();
            this.LabelBarrier = new System.Windows.Forms.Label();
            this.LabelLocation = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BarrierIcon = new System.Windows.Forms.PictureBox();
            this.ReaderIcon = new System.Windows.Forms.PictureBox();
            this.StatusL = new System.Windows.Forms.Label();
            this.TestSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportLogView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierViewL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderViewL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 51);
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
            this.label.Size = new System.Drawing.Size(156, 32);
            this.label.TabIndex = 23;
            this.label.Text = "Monitoring";
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
            this.menu.Size = new System.Drawing.Size(1011, 44);
            this.menu.TabIndex = 24;
            // 
            // IconMenu
            // 
            this.IconMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.IconMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Menu,
            this.Configuration_and_Control_Setup_Menu,
            this.Application_Setup_Menu});
            this.IconMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
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
            this.Monitoring_Menu.Size = new System.Drawing.Size(181, 22);
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
            this.Configuration_and_Control_Setup_Menu.Size = new System.Drawing.Size(181, 22);
            this.Configuration_and_Control_Setup_Menu.Text = "Configuration Setup";
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
            this.Application_Setup_Menu.Size = new System.Drawing.Size(181, 22);
            this.Application_Setup_Menu.Text = "Application Setup";
            this.Application_Setup_Menu.Click += new System.EventHandler(this.Application_Setup_Menu_Click);
            // 
            // ReportLogView
            // 
            this.ReportLogView.BackgroundColor = System.Drawing.Color.White;
            this.ReportLogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportLogView.Location = new System.Drawing.Point(77, 140);
            this.ReportLogView.Margin = new System.Windows.Forms.Padding(2);
            this.ReportLogView.Name = "ReportLogView";
            this.ReportLogView.RowHeadersWidth = 51;
            this.ReportLogView.RowTemplate.Height = 24;
            this.ReportLogView.Size = new System.Drawing.Size(862, 324);
            this.ReportLogView.TabIndex = 26;
            this.ReportLogView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReportLogView_CellContentClick);
            // 
            // BarrierShowLog
            // 
            this.BarrierShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BarrierShowLog.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarrierShowLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.BarrierShowLog.Location = new System.Drawing.Point(77, 117);
            this.BarrierShowLog.Margin = new System.Windows.Forms.Padding(2);
            this.BarrierShowLog.Name = "BarrierShowLog";
            this.BarrierShowLog.Size = new System.Drawing.Size(82, 24);
            this.BarrierShowLog.TabIndex = 27;
            this.BarrierShowLog.Text = "Barrier";
            this.BarrierShowLog.UseVisualStyleBackColor = true;
            this.BarrierShowLog.Click += new System.EventHandler(this.BarrierShowLog_Click);
            // 
            // ReaderShowLog
            // 
            this.ReaderShowLog.BackColor = System.Drawing.Color.Gainsboro;
            this.ReaderShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReaderShowLog.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.ReaderShowLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(255)))));
            this.ReaderShowLog.Location = new System.Drawing.Point(160, 117);
            this.ReaderShowLog.Margin = new System.Windows.Forms.Padding(0);
            this.ReaderShowLog.Name = "ReaderShowLog";
            this.ReaderShowLog.Size = new System.Drawing.Size(102, 24);
            this.ReaderShowLog.TabIndex = 28;
            this.ReaderShowLog.Text = "ID Card Reader";
            this.ReaderShowLog.UseVisualStyleBackColor = false;
            this.ReaderShowLog.Click += new System.EventHandler(this.ReaderShowLog_Click);
            // 
            // BarrierViewL
            // 
            this.BarrierViewL.BackgroundColor = System.Drawing.Color.LightCyan;
            this.BarrierViewL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarrierViewL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column11,
            this.Column5});
            this.BarrierViewL.Location = new System.Drawing.Point(24, 583);
            this.BarrierViewL.Margin = new System.Windows.Forms.Padding(2);
            this.BarrierViewL.Name = "BarrierViewL";
            this.BarrierViewL.RowHeadersWidth = 51;
            this.BarrierViewL.RowTemplate.Height = 24;
            this.BarrierViewL.Size = new System.Drawing.Size(223, 106);
            this.BarrierViewL.TabIndex = 30;
            this.BarrierViewL.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Timestamp";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Command Send";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Error";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Return Value";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Description";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Log File";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 125;
            // 
            // ReaderViewL
            // 
            this.ReaderViewL.BackgroundColor = System.Drawing.Color.LightCyan;
            this.ReaderViewL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReaderViewL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.ReaderViewL.Location = new System.Drawing.Point(265, 583);
            this.ReaderViewL.Margin = new System.Windows.Forms.Padding(2);
            this.ReaderViewL.Name = "ReaderViewL";
            this.ReaderViewL.RowHeadersWidth = 51;
            this.ReaderViewL.RowTemplate.Height = 24;
            this.ReaderViewL.Size = new System.Drawing.Size(254, 106);
            this.ReaderViewL.TabIndex = 31;
            this.ReaderViewL.Visible = false;
            this.ReaderViewL.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReaderViewL_CellValueChanged);
            this.ReaderViewL.CurrentCellDirtyStateChanged += new System.EventHandler(this.ReaderViewL_CurrentCellDirtyStateChanged);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Timestamp";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ID";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Error";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Reading";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Log File";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 125;
            // 
            // LabelReader
            // 
            this.LabelReader.AutoSize = true;
            this.LabelReader.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelReader.Location = new System.Drawing.Point(612, 74);
            this.LabelReader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelReader.Name = "LabelReader";
            this.LabelReader.Size = new System.Drawing.Size(152, 22);
            this.LabelReader.TabIndex = 100;
            this.LabelReader.Text = "Reader Status :";
            // 
            // LabelBarrier
            // 
            this.LabelBarrier.AutoSize = true;
            this.LabelBarrier.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBarrier.Location = new System.Drawing.Point(413, 74);
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
            this.LabelLocation.Location = new System.Drawing.Point(215, 74);
            this.LabelLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLocation.Name = "LabelLocation";
            this.LabelLocation.Size = new System.Drawing.Size(103, 22);
            this.LabelLocation.TabIndex = 97;
            this.LabelLocation.Text = "Location :";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 33);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BarrierIcon
            // 
            this.BarrierIcon.Image = ((System.Drawing.Image)(resources.GetObject("BarrierIcon.Image")));
            this.BarrierIcon.Location = new System.Drawing.Point(569, 67);
            this.BarrierIcon.Name = "BarrierIcon";
            this.BarrierIcon.Size = new System.Drawing.Size(38, 36);
            this.BarrierIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BarrierIcon.TabIndex = 106;
            this.BarrierIcon.TabStop = false;
            // 
            // ReaderIcon
            // 
            this.ReaderIcon.Image = ((System.Drawing.Image)(resources.GetObject("ReaderIcon.Image")));
            this.ReaderIcon.Location = new System.Drawing.Point(769, 67);
            this.ReaderIcon.Name = "ReaderIcon";
            this.ReaderIcon.Size = new System.Drawing.Size(38, 36);
            this.ReaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ReaderIcon.TabIndex = 107;
            this.ReaderIcon.TabStop = false;
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusL.Location = new System.Drawing.Point(323, 74);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(85, 22);
            this.StatusL.TabIndex = 108;
            this.StatusL.Text = "D1GH01";
            // 
            // TestSave
            // 
            this.TestSave.Location = new System.Drawing.Point(77, 468);
            this.TestSave.Margin = new System.Windows.Forms.Padding(2);
            this.TestSave.Name = "TestSave";
            this.TestSave.Size = new System.Drawing.Size(82, 22);
            this.TestSave.TabIndex = 105;
            this.TestSave.Text = "Test Save";
            this.TestSave.UseVisualStyleBackColor = true;
            this.TestSave.Visible = false;
            this.TestSave.Click += new System.EventHandler(this.TestSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 537);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.ReaderIcon);
            this.Controls.Add(this.BarrierIcon);
            this.Controls.Add(this.TestSave);
            this.Controls.Add(this.LabelReader);
            this.Controls.Add(this.LabelBarrier);
            this.Controls.Add(this.LabelLocation);
            this.Controls.Add(this.ReaderViewL);
            this.Controls.Add(this.BarrierViewL);
            this.Controls.Add(this.ReaderShowLog);
            this.Controls.Add(this.BarrierShowLog);
            this.Controls.Add(this.ReportLogView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate Automation Equipment Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportLogView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierViewL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderViewL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarrierIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button BarrierShowLog;
        private System.Windows.Forms.Button ReaderShowLog;
        public System.Windows.Forms.DataGridView BarrierViewL;
        public System.Windows.Forms.DataGridView ReaderViewL;
        private System.Windows.Forms.DataGridView ReportLogView;
        private Label LabelReader;
        private Label LabelBarrier;
        private Label LabelLocation;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewLinkColumn Column10;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewLinkColumn Column5;
        private MenuStrip menu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem IconMenu;
        private ToolStripMenuItem Monitoring_Menu;
        private ToolStripMenuItem Configuration_and_Control_Setup_Menu;
        private ToolStripMenuItem ID_Card_Reader_Setup_Menu;
        private ToolStripMenuItem Barrier_Setup_Menu;
        private ToolStripMenuItem Application_Setup_Menu;
        private ContextMenuStrip contextMenuStrip1;
        private PictureBox BarrierIcon;
        private PictureBox ReaderIcon;
        private Label StatusL;
        private Button TestSave;
    }
}

