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
using System.Timers;
using System.Windows.Forms;
using static AGOS_GATE_EQUIPMENT.BarrierPage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AGOS_GATE_EQUIPMENT
{
    public partial class LogFilePageReader : Form
    {
        private System.Windows.Forms.Timer timer;
        private Form1 f1;
        public LogFilePageReader(Form1 F1)
        {
            InitializeComponent();
            f1 = F1;
            AutoTime(); // เรียกใช้ฟังก์ชัน AutoTime เมื่อสร้างหน้า
        }

        private void AutoTime()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // เช็คทุกวินาที
            timer.Tick += AutoLoadLogRT;
            timer.Start();
        }

        private void AutoLoadLogRT(object sender, EventArgs e)
        {
            // ดึงข้อมูลใหม่
            string newLogMessages = GetUpdatedLogMessages2();

            if (!string.IsNullOrEmpty(newLogMessages))
            {
                LogFileViewCR.Text = newLogMessages; // อัพเดทข้อความทั้งหมด
            }
        }
        private void LogFileViewCR_TextChanged(object sender, EventArgs e)
        {

        }
        private string GetUpdatedLogMessages2()
        {
            var now = DateTime.Now;
            var fileName = "KCD1GH01_" + now.ToString("yyyyMMdd") + ".txt";
            var filePath = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", fileName);

            StringBuilder allLogMessages2 = new StringBuilder();

            foreach (DataGridViewRow row in f1.ReaderViewL.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "View")
                {
                    string logMessage2 = $"{row.Cells[0].Value}, {row.Cells[1].Value}, {row.Cells[2].Value},{row.Cells[3].Value}";
                    allLogMessages2.AppendLine(logMessage2);
                }
            }
            return allLogMessages2.ToString();
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LogFilePage_Load(object sender, EventArgs e)
        {
            LogFileViewCR.Text = GetUpdatedLogMessages2();
        }
    }
}
