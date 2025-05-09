using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AGOS_GATE_EQUIPMENT
{
    public partial class Config : Form
    {
        private int logAttemptCount = 0;
        public Config()
        {
            InitializeComponent();
        }
        private void LoadConfig()
        {
            try
            {
                var filePath = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
                if (File.Exists(filePath))
                {
                    // อ่าน JSON จากไฟล์
                    var jsonString = File.ReadAllText(filePath);
                    // แปลง JSON เป็นวัตถุ
                    var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
                    KioskBox.Text = jsonObject?.KioskIP ?? "No IP address found.";
                    BarrierBox.Text = jsonObject?.BarrierIP ?? "Not found location.";
                    CardReaderBox.Text = jsonObject?.CardReaderIP?? "Not found File Name.";
                    LocationBox.Text = jsonObject?.GateLaneNo;
                    LaneBOX.Text = jsonObject?.TerminalNo;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading IP address: {ex.Message}");
            }
        }
        private void SaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new ConfigClass
                {
                    KioskIP = KioskBox.Text,
                    BarrierIP = BarrierBox.Text,
                    CardReaderIP = CardReaderBox.Text,
                    GateLaneNo = LocationBox.Text,
                    TerminalNo = LaneBOX.Text,
                };
                var filePath = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
                var jsonString = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }
        private void Config_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
}
