namespace AGOS_GATE_EQUIPMENT
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.KioskBox = new System.Windows.Forms.TextBox();
            this.BarrierBox = new System.Windows.Forms.TextBox();
            this.CardReaderBox = new System.Windows.Forms.TextBox();
            this.LocationBox = new System.Windows.Forms.TextBox();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LaneBOX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // KioskBox
            // 
            this.KioskBox.Location = new System.Drawing.Point(160, 41);
            this.KioskBox.Margin = new System.Windows.Forms.Padding(2);
            this.KioskBox.Name = "KioskBox";
            this.KioskBox.Size = new System.Drawing.Size(224, 20);
            this.KioskBox.TabIndex = 0;
            // 
            // BarrierBox
            // 
            this.BarrierBox.Location = new System.Drawing.Point(160, 80);
            this.BarrierBox.Margin = new System.Windows.Forms.Padding(2);
            this.BarrierBox.Name = "BarrierBox";
            this.BarrierBox.Size = new System.Drawing.Size(224, 20);
            this.BarrierBox.TabIndex = 1;
            // 
            // CardReaderBox
            // 
            this.CardReaderBox.Location = new System.Drawing.Point(160, 124);
            this.CardReaderBox.Margin = new System.Windows.Forms.Padding(2);
            this.CardReaderBox.Name = "CardReaderBox";
            this.CardReaderBox.Size = new System.Drawing.Size(224, 20);
            this.CardReaderBox.TabIndex = 2;
            // 
            // LocationBox
            // 
            this.LocationBox.Location = new System.Drawing.Point(160, 167);
            this.LocationBox.Margin = new System.Windows.Forms.Padding(2);
            this.LocationBox.Name = "LocationBox";
            this.LocationBox.Size = new System.Drawing.Size(224, 20);
            this.LocationBox.TabIndex = 3;
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(223, 243);
            this.SaveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(56, 19);
            this.SaveConfig.TabIndex = 4;
            this.SaveConfig.Text = "Save";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kiosk IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Barrier ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Card Reader ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Location";
            // 
            // LaneBOX
            // 
            this.LaneBOX.Location = new System.Drawing.Point(160, 210);
            this.LaneBOX.Margin = new System.Windows.Forms.Padding(2);
            this.LaneBOX.Name = "LaneBOX";
            this.LaneBOX.Size = new System.Drawing.Size(224, 20);
            this.LaneBOX.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 214);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Terminal";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 339);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LaneBOX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.LocationBox);
            this.Controls.Add(this.CardReaderBox);
            this.Controls.Add(this.BarrierBox);
            this.Controls.Add(this.KioskBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate Automation Equipment Management";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KioskBox;
        private System.Windows.Forms.TextBox BarrierBox;
        private System.Windows.Forms.TextBox CardReaderBox;
        private System.Windows.Forms.TextBox LocationBox;
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LaneBOX;
        private System.Windows.Forms.Label label5;
    }
}