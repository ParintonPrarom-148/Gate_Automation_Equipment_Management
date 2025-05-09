using Newtonsoft.Json;
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
using static AGOS_GATE_EQUIPMENT.BarrierPage;
namespace AGOS_GATE_EQUIPMENT
{
    public partial class ApplicationSetupPage : Form
    {
        private Form1 f1;
        public ApplicationSetupPage(Form1 F1)
        {
            InitializeComponent();
        }
    private void LoadingSetting()
        {
            try
            {
                var filePath = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\KioskSetting.json";
                if (File.Exists(filePath))
                {
                    // อ่าน JSON จากไฟล์
                    var jsonString = File.ReadAllText(filePath);
                    // แปลง JSON เป็นวัตถุ
                    var jsonObject = JsonConvert.DeserializeObject<ApplicationSettingClass>(jsonString);
                    IPbox.Text = jsonObject?.KisokIP ?? "-";
                    LocationLogFileBox.Text = jsonObject?.KioskLocationLogFile ?? "-";
                    BarrierNameBox.Text = jsonObject?.BarrierName ?? "-";
                    ReaderNameBOX.Text = jsonObject.ReaderName ?? "-";
                    //ReaderNameBOX.Text = jsonObject?.KioskLogFileName ?? "Not found File Name.";
                    RemarkBox.Text = jsonObject?.Remark ?? "-";
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading IP address: {ex.Message}");
            }
        }
        private void BackBTN_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new ApplicationSettingClass
                {
                    KisokIP = IPbox.Text,
                    KioskLocationLogFile = LocationLogFileBox.Text,
                    BarrierName = BarrierNameBox.Text,
                    ReaderName = ReaderNameBOX.Text,
                    Remark = RemarkBox.Text
                };
                var filePath = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\KioskSetting.json";
                var jsonString = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);
                MessageBox.Show("All Setting saved to JSON file successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }
        private void ApplicationSetupPage_Load(object sender, EventArgs e)
        {
            LoadingSetting();
        }
        private void IPbox_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"Test");
        }
        private void Monitoring_Menu_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void ID_Card_Reader_Setup_Menu_Click(object sender, EventArgs e)
        {
            CardReaderPage CRP = new CardReaderPage(f1);
            CRP.Show();
            this.Hide();
        }
        private void Barrier_Setup_Menu_Click(object sender, EventArgs e)
        {
            BarrierPage barrierPage = new BarrierPage(f1);
            barrierPage.Show();
            this.Hide();
        }
        private void Application_Setup_Menu_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
