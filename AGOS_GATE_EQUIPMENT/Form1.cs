using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using static AGOS_GATE_EQUIPMENT.Config;
using System.Net.Http;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
namespace AGOS_GATE_EQUIPMENT
{
	public partial class Form1 : Form
	{
		private StringBuilder logMessages = new StringBuilder();
		private CardReaderPage CRP;
		private LogFilePage LP;
		private BarrierPage BP;
		private string filePath;
		private System.Windows.Forms.Timer timer;
		private int logAttemptCount = 0;
		public Form1()
		{
			InitializeComponent();
			CRP = new CardReaderPage(this);
			LP = new LogFilePage(this);
			BP = new BarrierPage(this);
			StartSaveTime();
			this.Load += new EventHandler(Form1_Load);
			DeleteEmptyDataTime();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
			ControlTimeSend();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			BP.ThreadsAllCenter();
			BP.IconStatusChanged += UpdateIconInBarrier;
			BP.GET_Barrier();
			BarrierShowLog_Click(sender, EventArgs.Empty);
			Config cf = new Config();
			cf.Show();
		}
		private void UpdateIconInBarrier(bool isOnline)
		{  // เช็คว่าต้องทำการ Invoke หรือไม่
			if (BarrierIcon.InvokeRequired)
			{
				// หากใช่ ให้เรียกใช้ UpdateIconInForm1 ผ่าน Invoke
				BarrierIcon.Invoke(new Action<bool>(UpdateIconInBarrier), isOnline);
			}
			else
			{
				// อัปเดต iconPictureBox ใน Form1 ตามสถานะที่ส่งมา
				if (isOnline)
				{
					BarrierIcon.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "online_icon.png"));
				}
				else
				{
					BarrierIcon.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "offline_icon.png"));
				}
			}
		}
		private void UpdateIconInReader(bool isOnline)
		{  // เช็คว่าต้องทำการ Invoke หรือไม่
			if (BarrierIcon.InvokeRequired)
			{
				// หากใช่ ให้เรียกใช้ UpdateIconInForm1 ผ่าน Invoke
				ReaderIcon.Invoke(new Action<bool>(UpdateIconInReader), isOnline);
			}
			else
			{
				// อัปเดต iconPictureBox ใน Form1 ตามสถานะที่ส่งมา
				if (isOnline)
				{
					ReaderIcon.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "online_icon.png"));
				}
				else
				{
					ReaderIcon.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "offline_icon.png"));
				}
			}
		}
		private void ReportLogView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5 && BarrierViewL.Rows[e.RowIndex].Cells[5].Value.ToString() == "View")
			{
				LogFilePage lf = new LogFilePage(this);
				// สร้าง StringBuilder เพื่อเก็บข้อมูลทั้งหมด
				StringBuilder allLogMessages = new StringBuilder();
				// วนลูปเพื่อดึงข้อมูลทั้งหมดจาก DataGridView
				foreach (DataGridViewRow row in BarrierViewL.Rows)
				{
					if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() == "View")
					{
						// สร้างสตริงใหม่จากข้อมูลในแต่ละแถว
						string logMessage = $"{row.Cells[0].Value}, {row.Cells[1].Value}, {row.Cells[2].Value}, {row.Cells[3].Value}, {row.Cells[4].Value}";
						allLogMessages.AppendLine(logMessage); // เพิ่มข้อความลงใน StringBuilder
					}
				}
				LogFilePage logFilePage = new LogFilePage(this);
				lf.Show();
				lf.LogFileViewR.Text = allLogMessages.ToString();
			}
			else if (e.ColumnIndex == 4 && ReaderViewL.Rows[e.RowIndex].Cells[4].Value.ToString() == "View")
			{
				LogFilePage lf = new LogFilePage(this);
				// สร้าง StringBuilder เพื่อเก็บข้อมูลทั้งหมด
				StringBuilder allLogMessages2 = new StringBuilder();
				// วนลูปเพื่อดึงข้อมูลทั้งหมดจาก DataGridView
				foreach (DataGridViewRow row in ReaderViewL.Rows)
				{
					if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "View")
					{
						// สร้างสตริงใหม่จากข้อมูลในแต่ละแถว
						string logMessage2 = $"{row.Cells[0].Value}, {row.Cells[1].Value}, {row.Cells[2].Value}, {row.Cells[3].Value}";
						allLogMessages2.AppendLine(logMessage2); // เพิ่มข้อความลงใน StringBuilder
					}
				}
				LogFilePageReader lf2 = new LogFilePageReader(this);
				lf2.Show();
				lf2.LogFileViewCR.Text = allLogMessages2.ToString();
			}
		}
		public void DeleteEmptyDataTime()
		{
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += TimeVoidDel;
			timer.Start();
		}
		public void TimeVoidDel(object sender, EventArgs e)
		{
			CheckAndRemoveEmptyRows(); // ลบข้อมูลที่ว่างออก
		}
		private void ReaderViewL_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (ReaderViewL.IsCurrentCellDirty)
			{
				ReaderViewL.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		private void CheckAndRemoveEmptyRows()
		{
			for (int i = ReaderViewL.Rows.Count - 1; i >= 0; i--)
			{
				DataGridViewRow row = ReaderViewL.Rows[i];
				// ตรวจสอบว่าเป็นแถวใหม่หรือไม่
				if (row.IsNewRow) continue;
				// ดึงค่าจากเซลล์
				var cell2 = row.Cells[1].Value?.ToString();
				var cell3 = row.Cells[2].Value?.ToString();
				var cell4 = row.Cells[3].Value?.ToString();
				// แสดงค่าที่ตรวจสอบ
				Console.WriteLine($"Row {i}: Cell 2 = '{cell2}', Cell 3 = '{cell3}', Cell 4 = '{cell4}'");
				// เช็คว่าเซลล์ในคอลัมน์ที่ 2, 3, 4 ว่างหรือไม่
				if (string.IsNullOrWhiteSpace(cell2) &&
					string.IsNullOrWhiteSpace(cell3) &&
					string.IsNullOrWhiteSpace(cell4))
				{
					// ลบแถว
					ReaderViewL.Rows.RemoveAt(i);
				}
			}
		}
		//-----------------------Button------------------------------
		private void button1_Click(object sender, EventArgs e)
		{
			BarrierPage barrierPage = new BarrierPage(this);
			barrierPage.Show();
			//this.Hide();
		}
		private void AppSetPage_Click(object sender, EventArgs e)
		{
			ApplicationSetupPage APS = new ApplicationSetupPage(this);
			APS.Show();
			this.Hide();
		}
		private void RP_Click(object sender, EventArgs e)
		{
			CardReaderPage CRP = new CardReaderPage(this);
			CRP.Show();
			//this.Hide();
		}
		//----------------------------------Show Barrier Data--------------------------------------------------
		private void BarrierShowLog_Click(object sender, EventArgs e)
		{
			BarrierShowLog.ForeColor = Color.DodgerBlue; // เปลี่ยนเป็นสีฟ้า
			BarrierShowLog.BackColor = Color.White;
			ReaderShowLog.ForeColor = Color.DodgerBlue; // เปลี่ยนเป็นสีฟ้า
			ReaderShowLog.BackColor = Color.Gainsboro;
			ExportDataToReportLog();
			BarrierViewL.CellValueChanged += BarrierViewL_CellValueChanged;
			BarrierViewL.RowsAdded += BarrierViewL_RowsAdded;
			BarrierViewL.RowsRemoved += BarrierViewL_RowsRemoved;
			ReaderViewL.CellValueChanged -= ReaderViewL_CellValueChanged;
			ReaderViewL.RowsAdded -= ReaderViewL_RowsAdded;
			ReaderViewL.RowsRemoved -= ReaderViewL_RowsRemoved;
		}
		private void ExportDataToReportLog()
		{
			// สมมติว่า ReportLogView เป็น DataGridView
			ReportLogView.Rows.Clear();
			ReportLogView.Columns.Clear();
			// คัดลอกคอลัมน์จาก BarrierViewL
			foreach (DataGridViewColumn column in BarrierViewL.Columns)
			{
				ReportLogView.Columns.Add((DataGridViewColumn)column.Clone());
			}
			// คัดลอกข้อมูลจาก BarrierViewL ไปยัง ReportLogView
			foreach (DataGridViewRow row in BarrierViewL.Rows)
			{
				if (!row.IsNewRow)
				{
					int rowIndex = ReportLogView.Rows.Add();
					for (int i = 0; i < row.Cells.Count; i++)
					{
						ReportLogView.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
					}
				}
			}
		}
		//---------------------------กราตั้งค่า ข้อมูลในตาราง Barrier------------------------------
		private void BarrierViewL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			UpdateReportLogView();
		}
		private void BarrierViewL_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			UpdateReportLogView();
		}
		private void BarrierViewL_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdateReportLogView();
		}
		private void UpdateReportLogView()
		{
			// ตรวจสอบว่าเป็นการเรียกจาก UI thread หรือไม่
			if (ReportLogView.InvokeRequired)
			{
				// ใช้ Invoke เพื่อให้แน่ใจว่าการอัพเดตทำใน UI thread
				ReportLogView.Invoke(new Action(UpdateReportLogView));
				return;
			}
			// Clear existing rows in ReportLogView
			ReportLogView.Rows.Clear();
			// Iterate through rows in BarrierViewL
			foreach (DataGridViewRow row in BarrierViewL.Rows)
			{
				// Ensure the row is not a new row
				if (!row.IsNewRow)
				{
					// Create a new row for ReportLogView
					int rowIndex = ReportLogView.Rows.Add();
					// Loop through each cell in the row
					for (int i = 0; i < row.Cells.Count; i++)
					{
						// Copy the value from BarrierViewL to ReportLogView
						ReportLogView.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
					}
				}
			}
			//BarrierShowLog_Click(this, EventArgs.Empty);
		}
		private void ReaderShowLog_Click(object sender, EventArgs e)
		{
			ReaderShowLog.ForeColor = Color.DodgerBlue; // เปลี่ยนเป็นสีฟ้า
			ReaderShowLog.BackColor = Color.White;
			BarrierShowLog.ForeColor = Color.DodgerBlue; // เปลี่ยนเป็นสีฟ้า
			BarrierShowLog.BackColor = Color.Gainsboro;
			ExportDataToReportLogReader();
			//----------------------- ตรงนี้คือการ อัพเดทการ Edit หรือ Add ข้อมูล-------------------------------
			BarrierViewL.CellValueChanged -= BarrierViewL_CellValueChanged;
			BarrierViewL.RowsAdded -= BarrierViewL_RowsAdded;
			BarrierViewL.RowsRemoved -= BarrierViewL_RowsRemoved;
			ReaderViewL.CellValueChanged += ReaderViewL_CellValueChanged;
			ReaderViewL.RowsAdded += ReaderViewL_RowsAdded;
			ReaderViewL.RowsRemoved += ReaderViewL_RowsRemoved;
			//-----------------------------------------------------------------------------------------
		}
		private void ExportDataToReportLogReader()
		{
			// สมมติว่า ReportLogView เป็น DataGridView
			ReportLogView.Rows.Clear();
			ReportLogView.Columns.Clear();
			// คัดลอกคอลัมน์จาก BarrierViewL
			foreach (DataGridViewColumn column in ReaderViewL.Columns)
			{
				ReportLogView.Columns.Add((DataGridViewColumn)column.Clone());
			}
			// คัดลอกข้อมูลจาก BarrierViewL ไปยัง ReportLogView
			foreach (DataGridViewRow row in ReaderViewL.Rows)
			{
				if (!row.IsNewRow)
				{
					int rowIndex = ReportLogView.Rows.Add();
					for (int i = 0; i < row.Cells.Count; i++)
					{
						ReportLogView.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
					}
				}
			}
		}
		//------------------------------------------------------------------------------------
		//---------------------------กราตั้งค่า ข้อมูลในตาราง Reader------------------------------
		private void ReaderViewL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			UpdateReportReaderLogView();
			CheckAndRemoveEmptyRows();
		}
		private void ReaderViewL_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			UpdateReportReaderLogView();
		}
		private void ReaderViewL_RowValidated(object sender, DataGridViewCellCancelEventArgs e)
		{
			CheckAndRemoveEmptyRows();
		}
		private void ReaderViewL_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdateReportReaderLogView();
		}
		private void UpdateReportReaderLogView()
		{
			// Clear existing rows in ReportLogView
			ReportLogView.Rows.Clear();
			// Iterate through rows in BarrierViewL
			foreach (DataGridViewRow row in ReaderViewL.Rows)
			{
				// Ensure the row is not a new row
				if (!row.IsNewRow)
				{
					// Create a new row for ReportLogView
					int rowIndex = ReportLogView.Rows.Add();
					// Loop through each cell in the row
					for (int i = 0; i < row.Cells.Count; i++)
					{
						// Copy the value from BarrierViewL to ReportLogView
						ReportLogView.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
					}
				}
			}
			//ReaderShowLog_Click(this, EventArgs.Empty);
		}
		//---------------------------------------------------------------------------------
		//------------------------ ระบบ Save ไฟล์ ------------------------------------------
		public void StartSaveTime()
		{
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			//timer.Interval = 30000;
			timer.Tick += CheckTime;
			timer.Start();
		}
		private HashSet<string> executedTimes = new HashSet<string>();
		private void CheckTime(object sender, EventArgs e)
		{
			ShowStatusLocation();
			try
			{
				var now = DateTime.Now;
				string currentTime = $"{now.Hour}:{now.Minute}";
				Console.WriteLine($"Current Time: {now.ToString("HH:mm:ss")}");
				if ((now.Hour == 1 || now.Hour == 2 || now.Hour == 3 || now.Hour == 4 || now.Hour == 5 ||
				now.Hour == 6 || now.Hour == 7 || now.Hour == 8 || now.Hour == 9 || now.Hour == 10 ||
				now.Hour == 11 || now.Hour == 12 || now.Hour == 13 || now.Hour == 14 || now.Hour == 15 ||
				now.Hour == 16 || now.Hour == 17 || now.Hour == 18 || now.Hour == 19 || now.Hour == 20 ||
				now.Hour == 21 || now.Hour == 22 || now.Hour == 23 || now.Hour == 0) && now.Minute == 0 &&
			!executedTimes.Contains(currentTime))
				{
					Console.WriteLine($"Apply fileS at {currentTime}");
					//AddNewText();
					AddLogToFile();
					executedTimes.Add(currentTime); // บันทึกเวลาที่ทำงานแล้ว
				}
				else if ((now.Hour < 1 || now.Hour > 23) || (now.Hour == 0 && now.Minute != 0))
				{
					// รีเซ็ตเมื่อล่วงเวลาผ่านไป
					executedTimes.Clear(); // ล้างเวลาออกทั้งหมด
				}
				else if (now.Hour == 11 && now.Minute == 23)
				{
					Console.WriteLine("Delete old file");
					DeleteOldFile();
				}
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
			}
		}
		private bool isBackingUp = false; // ของ FORM1_Closing
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			// ป้องกันการปิดโปรแกรมจนกว่า BackupFile จะทำงานเสร็จ
			if (!isBackingUp)
			{
				e.Cancel = true; // ห้ามปิดโปรแกรม
				isBackingUp = true; // ตั้ง flag ว่ากำลังสำรองข้อมูลอยู่
				var now = DateTime.Now;
				var fileName = "KBD1GH01_" + now.ToString("yyyyMMdd") + ".txt";
				var filePath = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", fileName);
				//BackUpFile(filePath);
				Application.Exit(); // ใช้ Application.Exit() แทน this.Close()
			}
		}
		private void CreateNewFile()
		{
			var now = DateTime.Now;
			var fileName = "KBD1GH01_" + now.ToString("yyyyMMdd") + ".txt";
			var filePath = Path.Combine(@"C:\admin\destop\D1GH01_LOG\Barrier", fileName);
			try
			{
				// สร้างไฟล์เปล่า
				File.WriteAllText(filePath, string.Empty);
				Console.WriteLine($"File created: {filePath}");
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
			}
		}
		private void DeleteOldFile()
		{
			try
			{
				var now = DateTime.Now;
				var old_Day_FileName = "KBD1GH01_" + now.AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_Year_FileName = "KBD1GH01_" + now.AddYears(-1).ToString("yyyyMMdd") + ".txt";
				var old_Month_FileName = "KBD1GH01_" + now.AddMonths(-1).ToString("yyyyMMdd") + ".txt";
				var old_YM = "KBD1GH01_" + now.AddYears(-1).AddMonths(-1).ToString("yyyyMMdd") + ".txt";
				var old_MD = "KBD1GH01_" + now.AddMonths(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_YD = "KBD1GH01_" + now.AddYears(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_YMD = "KBD1GH01_" + now.AddYears(-1).AddMonths(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_FilePath = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Day_FileName);
				var old_FilePath2 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Year_FileName);
				var old_FilePath3 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Month_FileName);
				var old_FilePath4 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YM);
				var old_FilePath5 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_MD);
				var old_FilePath6 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YD);
				var old_FilePath7 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YMD);
				if (File.Exists(old_FilePath))
				{
					File.Delete(old_FilePath);
					Console.WriteLine($"File deleted: {old_FilePath}"); // For debugging
				}
				else if (File.Exists(old_FilePath2))
				{
					File.Delete(old_FilePath2);
					Console.WriteLine($"File deleted: {old_FilePath2}");
				}
				else if (File.Exists(old_FilePath3))
				{
					File.Delete(old_FilePath3);
					Console.WriteLine($"File deleted: {old_FilePath3}");
				}
				else if (File.Exists(old_FilePath4))
				{
					File.Delete(old_FilePath4);
					Console.WriteLine($"File deleted: {old_FilePath4}");
				}
				else if (File.Exists(old_FilePath5))
				{
					File.Delete(old_FilePath5);
					Console.WriteLine($"File deleted: {old_FilePath5}");
				}
				else if (File.Exists(old_FilePath6))
				{
					File.Delete(old_FilePath6);
					Console.WriteLine($"File deleted: {old_FilePath6}");
				}
				else if (File.Exists(old_FilePath7))
				{
					File.Delete(old_FilePath7);
					Console.WriteLine($"File deleted: {old_FilePath7}");
				}
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
			}
		}
		//--------------- บันทึก LOG ของ Barrier_LOG ---------------------//
		private string BarrierS = string.Empty;
		private string ErrorBarrierS = string.Empty;
		private string ErrorB_Code = string.Empty;
		private string ErrorSensor = string.Empty;
		private string ErrorS_Code = string.Empty;
		public string SendErrorE4 { get; set; }
		public string SendErrorE5 { get; set; }
		public string SendErrorE6 { get; set; }
		public string SendErrorE7 { get; set; }
		private void AddLogToFile()
		{
			logAttemptCount++; // เพิ่มจำนวนรอบที่เรียกใช้ฟังก์ชัน
			var now = DateTime.Now;
			var fileName = "KBD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			var filePath = Path.Combine(@"C:\admin\destop\D1GH01_LOG\Barrier", fileName);
			try
			{
				var logEntries = new List<BarrierLOG_Class>();
				var filePathS = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
				var jsonString = File.ReadAllText(filePathS);
				var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
				// วนลูปเพื่อดึงข้อมูลจาก DataGridView
				foreach (DataGridViewRow row in BarrierViewL.Rows)
				{
					// เช็คว่าแถวไม่ใช่แถวใหม่
					if (!row.IsNewRow)
					{
						//---------- แยก Discription -------------------------//
						string description = row.Cells[4].Value?.ToString();
						if (description.Contains("Barrier is Open"))
						{
							BarrierS = "BarrierIsOpen";
							ErrorBarrierS = "NORMAL";
							ErrorB_Code = "-";
						}
						else if (description.Contains("Barrier is Closed"))
						{
							BarrierS = "BarrierIsClosed";
							ErrorBarrierS = "NORMAL";
							ErrorB_Code = "";
						}
						else if (description.Contains("No object found after 10 attempts"))
						{
							BarrierS = "-";
							ErrorBarrierS = "No object found after 10 attempts. Barrier remains open..";
							ErrorB_Code = "br0001";
						}
						else if (description.Contains("No object found after 3 attempts"))
						{
							BarrierS = "-";
							ErrorBarrierS = "No object found after 3 attempts. Barrier remains open.";
							ErrorB_Code = "br0002";
						}
						else if (description.Contains("Error detected after waiting period. Barrier remains open."))
						{
							ErrorBarrierS = "Error detected after waiting period. Barrier remains open.";
							ErrorB_Code = "br0003";
						}
						var logEntry = new BarrierLOG_Class
						{
							//BarrierLogId = jsonObject?.BarrierIP ?? "",
							TerminalId = jsonObject?.TerminalNo ?? "", // เปลี่ยนตามที่ต้องการ
							GateLaneId = jsonObject?.GateLaneNo ?? "", // เปลี่ยนตามที่ต้องการ
							CommandDatetime = DateTime.TryParse(row.Cells[0].Value?.ToString(), out var parsedDate) ?
							parsedDate.ToString("yyyyMMddHHmmss") : "", // หากไม่สามารถแปลงได้ให้เป็นค่าว่าง
							IpAddress = jsonObject?.KioskIP ?? "", // แทนที่ด้วยค่า IP ที่คุณต้องการ
							CommandType = row.Cells[1].Value?.ToString() ?? "",
							ReturnedValue = row.Cells[3].Value?.ToString() ?? "",//** รอเปลี่ยนหลังจากอัพเดทโค้ด Barrier
							CommandStatus = BarrierS,
							ErrorCode = ErrorB_Code,
							ErrorDesc = ErrorBarrierS,
						};
						logEntries.Add(logEntry);
					}
				}
				var jsonOutput = new { BarrierLog = logEntries };
				File.WriteAllText(filePath, JsonConvert.SerializeObject(jsonOutput, Formatting.Indented));
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
				else if (logAttemptCount == 2)
				{
					//MessageBox.Show("Oh Yeah: ");
				}
				// คุณอาจต้องการรีเซ็ตจำนวนรอบที่นี่หรือเพิ่มเงื่อนไขเพิ่มเติมตามความต้องการ
			}
		}
		//----------------------------------------------------------------------------------//
		//---------------------------------- Card Reader ------------------------------------//
		private void CreateNewFile_Reader()
		{
			var now = DateTime.Now;
			var fileName = "KCD1GH01_" + now.ToString("yyyyMMdd") + ".txt";
			var filePath = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", fileName);
			try
			{
				// สร้างไฟล์เปล่า
				File.WriteAllText(filePath, string.Empty);
				Console.WriteLine($"File created: {filePath}");
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
			}
		}
		private void DeleteOldFile_Reader()
		{
			try
			{
				var now = DateTime.Now;
				var old_Day_FileName = "KCD1GH01_" + now.AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_Year_FileName = "KCD1GH01_" + now.AddYears(-1).ToString("yyyyMMdd") + ".txt";
				var old_Month_FileName = "KCD1GH01_" + now.AddMonths(-1).ToString("yyyyMMdd") + ".txt";
				var old_YM = "KCD1GH01_" + now.AddYears(-1).AddMonths(-1).ToString("yyyyMMdd") + ".txt";
				var old_MD = "KCD1GH01_" + now.AddMonths(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_YD = "KCD1GH01_" + now.AddYears(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_YMD = "KCD1GH01_" + now.AddYears(-1).AddMonths(-1).AddDays(-1).ToString("yyyyMMdd") + ".txt";
				var old_FilePath = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Day_FileName);
				var old_FilePath2 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Year_FileName);
				var old_FilePath3 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_Month_FileName);
				var old_FilePath4 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YM);
				var old_FilePath5 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_MD);
				var old_FilePath6 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YD);
				var old_FilePath7 = Path.Combine(@"C:\Users\nongd\Desktop\GTAxxx", old_YMD);
				if (File.Exists(old_FilePath))
				{
					File.Delete(old_FilePath);
					Console.WriteLine($"File deleted: {old_FilePath}"); // For debugging
				}
				else if (File.Exists(old_FilePath2))
				{
					File.Delete(old_FilePath2);
					Console.WriteLine($"File deleted: {old_FilePath2}");
				}
				else if (File.Exists(old_FilePath3))
				{
					File.Delete(old_FilePath3);
					Console.WriteLine($"File deleted: {old_FilePath3}");
				}
				else if (File.Exists(old_FilePath4))
				{
					File.Delete(old_FilePath4);
					Console.WriteLine($"File deleted: {old_FilePath4}");
				}
				else if (File.Exists(old_FilePath5))
				{
					File.Delete(old_FilePath5);
					Console.WriteLine($"File deleted: {old_FilePath5}");
				}
				else if (File.Exists(old_FilePath6))
				{
					File.Delete(old_FilePath6);
					Console.WriteLine($"File deleted: {old_FilePath6}");
				}
				else if (File.Exists(old_FilePath7))
				{
					File.Delete(old_FilePath7);
					Console.WriteLine($"File deleted: {old_FilePath7}");
				}
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
			}
		}
		//-----------------------------------------------------------------------------------//
		private void ShowStatusLocation()
		{
			Config gs = new Config();
			try
			{
				var PathDS = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
				if (File.Exists(PathDS))
				{
					var JRead = File.ReadAllText(PathDS);
					var jConvert = JsonConvert.DeserializeObject<ConfigClass>(JRead);
					StatusL.Text = jConvert?.GateLaneNo ?? "";
				}
				else
				{
					//MessageBox.Show("File not found.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading IP address: {ex.Message}");
			}
		}
		//-----------------------ส่ง ข้อมูล JSON ไป Server ----------------//
		private void ControlTimeSend()
		{
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += new EventHandler(SendJSONTime);
			timer.Start();
		}
		private DateTime lastOldDate = DateTime.MinValue; // ตัวแปรเพื่อเก็บวันสุดท้ายที่ทำงาน
		private void SendJSONTime(object sender, EventArgs e)
		{
			if (DateTime.Now.Hour == 16 && DateTime.Now.Minute == 36)
			{
				// เช็คว่าวันที่ปัจจุบันแตกต่างจากวันสุดท้ายที่ทำงานหรือไม่
				if (DateTime.Now.Date != lastOldDate.Date)
				{
					SendJSON_POST();
					lastOldDate = DateTime.Now;
				}
			}
		}
		private async void SendJSON_POST()
		{
			var now = DateTime.Now;
			//string filePath = @"C:\admin\destop\D1GH01_LOG\Barrier\KBD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string filePath = @"C:\admin\destop\D1GH01_LOG\BarrierStatus\KBSD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string jsonData;
			try
			{
				jsonData = File.ReadAllText(filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error reading JSON file: " + ex.Message);
				return;
			}
			// ดึงข้อมูลจาก CardReaderLog
			JsonDocument jsonDoc = JsonDocument.Parse(jsonData);
			//var cardReaderLog = jsonDoc.RootElement.GetProperty("BarrierLog").ToString();
			var cardReaderLog = jsonDoc.RootElement.GetProperty("BarrierStatus").ToString();
			using (HttpClient client = new HttpClient())
			{
				try
				{
					// สร้าง HttpContent
					var content = new StringContent(cardReaderLog, Encoding.UTF8, "application/json");
					// ส่ง POST request
					//HttpResponseMessage response = await client.PostAsync("https://hpthapi.hutchisonports.co.th:28443/hptpcs/esuat/dataops/EQMS_ID/BARRIER_LOG/", content);
					HttpResponseMessage response = await client.PostAsync("http://localhost:8081/POSTserver", content);
					if (response.IsSuccessStatusCode)
					{
						MessageBox.Show("Data sent successfully!");
					}
					else
					{
						MessageBox.Show("Error: " + response.StatusCode);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error sending JSON: " + ex.Message);
				}
			}
		}
		private async void SendJSON2_POST()
		{
			var now = DateTime.Now;
			//string filePath = @"C:\admin\destop\D1GH01_LOG\Barrier\KBD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string filePath = @"C:\admin\destop\D1GH01_LOG\CardReaderStatus\KCSD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string jsonData;
			try
			{
				jsonData = File.ReadAllText(filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error reading JSON file: " + ex.Message);
				return;
			}
			// ดึงข้อมูลจาก CardReaderLog
			JsonDocument jsonDoc = JsonDocument.Parse(jsonData);
			//var cardReaderLog = jsonDoc.RootElement.GetProperty("BarrierLog").ToString();
			var cardReaderLog = jsonDoc.RootElement.GetProperty("CardReaderStatus").ToString();
			using (HttpClient client = new HttpClient())
			{
				try
				{
					// สร้าง HttpContent
					var content = new StringContent(cardReaderLog, Encoding.UTF8, "application/json");
					// ส่ง POST request
					//HttpResponseMessage response = await client.PostAsync("https://hpthapi.hutchisonports.co.th:28443/hptpcs/esuat/dataops/EQMS_ID/BARRIER_LOG/", content);
					HttpResponseMessage response = await client.PostAsync("http://localhost:8081/POSTserver", content);
					if (response.IsSuccessStatusCode)
					{
						MessageBox.Show("Data sent successfully!");
					}
					else
					{
						MessageBox.Show("Error: " + response.StatusCode);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error sending JSON: " + ex.Message);
				}
			}
		}
		private async void SendJSON3_POST()
		{
			var now = DateTime.Now;
			//string filePath = @"C:\admin\destop\D1GH01_LOG\Barrier\KBD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string filePath = @"C:\admin\destop\D1GH01_LOG\CardReader\KCD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			string jsonData;
			try
			{
				jsonData = File.ReadAllText(filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error reading JSON file: " + ex.Message);
				return;
			}
			// ดึงข้อมูลจาก CardReaderLog
			JsonDocument jsonDoc = JsonDocument.Parse(jsonData);
			//var cardReaderLog = jsonDoc.RootElement.GetProperty("BarrierLog").ToString();
			var cardReaderLog = jsonDoc.RootElement.GetProperty("CardReaderLog").ToString();
			using (HttpClient client = new HttpClient())
			{
				try
				{
					// สร้าง HttpContent
					var content = new StringContent(cardReaderLog, Encoding.UTF8, "application/json");
					// ส่ง POST request
					//HttpResponseMessage response = await client.PostAsync("https://hpthapi.hutchisonports.co.th:28443/hptpcs/esuat/dataops/EQMS_ID/BARRIER_LOG/", content);
					HttpResponseMessage response = await client.PostAsync("http://localhost:8081/POSTserver", content);
					if (response.IsSuccessStatusCode)
					{
						MessageBox.Show("Data sent successfully!");
					}
					else
					{
						MessageBox.Show("Error: " + response.StatusCode);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error sending JSON: " + ex.Message);
				}
			}
		}
		private void TestSave_Click(object sender, EventArgs e)
		{
			SendJSON_POST();  //barrier Status
			SendJSON2_POST(); //CR status
							  //SendJSON3_POST(); //CR
			//AddLogToFile();
			//AddReaderLogToFile();
			//MessageBox.Show(GetErrorL);
		}
		//---------------- บันทึก LOG ของ ReaderLoG ---------------------//
		public string ErrorDESC;
		public string ErrorC_Code;
		public string GetErrorL;
		private void AddReaderLogToFile()
		{
			logAttemptCount++; // เพิ่มจำนวนรอบที่เรียกใช้ฟังก์ชัน
			var now = DateTime.Now;
			var RfileName = "KCD1GH01_" + now.ToString("yyyyMMdd") + ".json";
			var RfilePath = Path.Combine(@"C:\admin\destop\D1GH01_LOG\CardReader", RfileName);
			try
			{
				var ReaderlogEntries = new List<ReaderClass>();
				var RfilePathS = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
				var jsonString = File.ReadAllText(RfilePathS);
				var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
				foreach (DataGridViewRow row in ReaderViewL.Rows)
				{
					// เช็คว่าแถวไม่ใช่แถวใหม่
					if (!row.IsNewRow)
					{
						//---------- แยก Discription -------------------------//
						string description = GetErrorL ?? "";
						if (description.Contains("An internal consistency check failed"))
						{
							ErrorC_Code = "E1";
						}
						else if (description.Contains("The action was canceled by a SCardCancel request"))
						{
							ErrorC_Code = "E2";
						}
						else if (description.Contains("The supplied handle was invalid"))
						{
							ErrorC_Code = "E3";
						}
						else if (description.Contains("One or more of the supplied parameters could not be properly interpreted"))
						{
							ErrorC_Code = "E4";
						}
						else if (description.Contains("Registry startup information is missing or invalid"))
						{
							ErrorC_Code = "E5";
						}
						else if (description.Contains("Not enough memory available to complete this command"))
						{
							ErrorC_Code = "E6";
						}
						else if (description.Contains("An internal consistency timer has expired"))
						{
							ErrorC_Code = "E7";
						}
						else if (description.Contains("The data buffer to receive returned data is too small for the returned data"))
						{
							ErrorC_Code = "E8";
						}
						else if (description.Contains("The specified reader name is not recognized"))
						{
							ErrorC_Code = "E9";
						}
						else if (description.Contains("The user-specified timeout value has expired"))
						{
							ErrorC_Code = "E10";
						}
						else if (description.Contains("The smart card cannot be accessed because of other connections outstanding"))
						{
							ErrorC_Code = "E11";
						}
						else if (description.Contains("The operation requires a smart card, but no smart card is currently in the device"))
						{
							ErrorC_Code = "E12";
						}
						else if (description.Contains("The specified smart card name is not recognized"))
						{
							ErrorC_Code = "E13";
						}
						else if (description.Contains("The system could not dispose of the media in the requested manner"))
						{
							ErrorC_Code = "E14";
						}
						else if (description.Contains("The requested protocols are incompatible with the protocol currently in use with the smart card"))
						{
							ErrorC_Code = "E15";
						}
						else if (description.Contains("The reader or smart card is not ready to accept commands"))
						{
							ErrorC_Code = "E16";
						}
						else if (description.Contains("One or more of the supplied parameter values could not be properly interpreted"))
						{
							ErrorC_Code = "E17";
						}
						else if (description.Contains("The action was canceled by the system, presumably to log off or shut down"))
						{
							ErrorC_Code = "E18";
						}
						else if (description.Contains("An internal communications error has been detected"))
						{
							ErrorC_Code = "E19";
						}
						else if (description.Contains("An internal error has been detected, but the source is unknown"))
						{
							ErrorC_Code = "E20";
						}
						else if (description.Contains("An ATR obtained from the registry is not a valid ATR string"))
						{
							ErrorC_Code = "E21";
						}
						else if (description.Contains("An attempt was made to end a non-existent transaction"))
						{
							ErrorC_Code = "E22";
						}
						else if (description.Contains("The specified reader is not currently available for use"))
						{
							ErrorC_Code = "E23";
						}
						else if (description.Contains("The operation has been aborted to allow the server application to exit"))
						{
							ErrorC_Code = "E24";
						}
						else if (description.Contains("The PCI Receive buffer was too small"))
						{
							ErrorC_Code = "E25";
						}
						else if (description.Contains("The reader driver does not meet minimal requirements for support"))
						{
							ErrorC_Code = "E26";
						}
						else if (description.Contains("The reader driver did not produce a unique reader name"))
						{
							ErrorC_Code = "E27";
						}
						else if (description.Contains("The smart card does not meet minimal requirements for support"))
						{
							ErrorC_Code = "E28";
						}
						else if (description.Contains("The Smart Card Resource Manager is not running"))
						{
							ErrorC_Code = "E29";
						}
						else if (description.Contains("The Smart Card Resource Manager has shut down"))
						{
							ErrorC_Code = "E30";
						}
						else if (description.Contains("An unexpected card error has occurred"))
						{
							ErrorC_Code = "E31";
						}
						else if (description.Contains("No primary provider can be found for the smart card"))
						{
							ErrorC_Code = "E32";
						}
						else if (description.Contains("The requested order of object creation is not supported"))
						{
							ErrorC_Code = "E33";
						}
						else if (description.Contains("This smart card does not support the requested feature"))
						{
							ErrorC_Code = "E34";
						}
						else if (description.Contains("The identified directory does not exist in the smart card"))
						{
							ErrorC_Code = "E35";
						}
						else if (description.Contains("The identified file does not exist in the smart card"))
						{
							ErrorC_Code = "E36";
						}
						else if (description.Contains("The supplied path does not represent a smart card directory"))
						{
							ErrorC_Code = "E37";
						}
						else if (description.Contains("The supplied path does not represent a smart card file"))
						{
							ErrorC_Code = "E38";
						}
						else if (description.Contains("Access is denied to this file"))
						{
							ErrorC_Code = "E39";
						}
						else if (description.Contains("The smart card does not have enough memory to store the information"))
						{
							ErrorC_Code = "E40";
						}
						else if (description.Contains("There was an error trying to set the smart card file object pointer"))
						{
							ErrorC_Code = "E41";
						}
						else if (description.Contains("The supplied PIN is incorrect"))
						{
							ErrorC_Code = "E42";
						}
						else if (description.Contains("An unrecognized error code was returned from a layered component"))
						{
							ErrorC_Code = "E43";
						}
						else if (description.Contains("The requested certificate does not exist"))
						{
							ErrorC_Code = "E44";
						}
						else if (description.Contains("The requested certificate could not be obtained"))
						{
							ErrorC_Code = "E45";
						}
						else if (description.Contains("Cannot find a smart card reader"))
						{
							ErrorC_Code = "E46";
						}
						else if (description.Contains("A communications error with the smart card has been detected. Retry the operation"))
						{
							ErrorC_Code = "E47";
						}
						else if (description.Contains("The requested key container does not exist on the smart card"))
						{
							ErrorC_Code = "E48";
						}
						else if (description.Contains("The Smart Card Resource Manager is too busy to complete this operation"))
						{
							ErrorC_Code = "E49";
						}
						else if (description.Contains("The reader cannot communicate with the card"))
						{
							ErrorC_Code = "E50";
						}
						else if (description.Contains("due to ATR string configuration conflicts"))
						{
							ErrorC_Code = "E50_2";
						}
						else if (description.Contains("The smart card is not responding to a reset"))
						{
							ErrorC_Code = "E51";
						}
						else if (description.Contains("Power has been removed from the smart card"))
						{
							ErrorC_Code = "E52";
						}
						else if (description.Contains("so that further communication is not possible"))
						{
							ErrorC_Code = "E52_2";
						}
						else if (description.Contains("The smart card has been reset"))
						{
							ErrorC_Code = "E53";
						}
						else if (description.Contains("so any shared state information is invalid"))
						{
							ErrorDESC = "so any shared state information is invalid";
							ErrorC_Code = "E53_2";
						}
						else if (description.Contains("The smart card has been removed"))
						{
							ErrorC_Code = "E54";
						}
						else if (description.Contains("so further communication is not possible"))
						{
							ErrorC_Code = "E54_2";
						}
						else if (description.Contains("Access was denied because of a security violation"))
						{
							ErrorC_Code = "E55";
						}
						else if (description.Contains("The card cannot be accessed because the wrong PIN was presented"))
						{
							ErrorC_Code = "E56";
						}
						else if (description.Contains("The card cannot be accessed because the maximum number of PIN entry attempts has been reached"))
						{
							ErrorC_Code = "E57";
						}
						else if (description.Contains("The end of the smart card file has been reached"))
						{
							ErrorC_Code = "E58";
						}
						else if (description.Contains("The action was canceled by the user"))
						{
							ErrorC_Code = "E59";
						}
						else if (description.Contains("No PIN was presented to the smart card"))
						{
							ErrorC_Code = "E60";
						}
						else if (description.Contains("main error"))
						{
							//ErrorDESC = "No PIN was presented to the smart card";
							ErrorC_Code = "E61";
						}
						else if (description.Contains("final error"))
						{
							ErrorC_Code = "E62";
						}
						else if (description.Contains("old card capture"))
						{
							ErrorC_Code = "E63";
						}
						else if (description.Contains("error") && description.Contains("removed"))
						{
							ErrorC_Code = "E99";
						}
						var ReaderlogEntry = new ReaderClass
						{
							//BarrierLogId = jsonObject?.BarrierIP ?? "",
							TerminalId = jsonObject?.TerminalNo ?? "", // เปลี่ยนตามที่ต้องการ
							GateLaneId = jsonObject?.GateLaneNo ?? "", // เปลี่ยนตามที่ต้องการ
							ReadDateTime = DateTime.TryParse(row.Cells[0].Value?.ToString(), out var parsedDate) ?
							parsedDate.ToString("yyyyMMddHHmmss") : "", // หากไม่สามารถแปลงได้ให้เป็นค่าว่าง
							ReadInformation = row.Cells[3].Value?.ToString(),
							CitizenId = row.Cells[1].Value?.ToString() ?? "",
							ErrorCode = ErrorC_Code,
							ErrorDesc = row.Cells[2].Value?.ToString() ?? "",
						};
						ReaderlogEntries.Add(ReaderlogEntry);
					}
				}
				var jsonOutputR = new { CardReaderLog = ReaderlogEntries };
				File.WriteAllText(RfilePath, JsonConvert.SerializeObject(jsonOutputR, Formatting.Indented));
			}
			catch (Exception ex)
			{
				if (logAttemptCount == 1)
				{
					MessageBox.Show($"An error occurred while adding text: {ex.Message}");
				}
				else if (logAttemptCount == 2)
				{
				}
			}
		}
		private void Barrier_Setup_Menu_Click(object sender, EventArgs e)
		{
			BarrierPage barrierPage = new BarrierPage(this);
			barrierPage.Show();
			this.Hide();
		}
		private void ID_Card_Reader_Setup_Menu_Click(object sender, EventArgs e)
		{
			CardReaderPage CRP = new CardReaderPage(this);
			CRP.Show();
			this.Hide();
		}
		private void Application_Setup_Menu_Click(object sender, EventArgs e)
		{
			ApplicationSetupPage APS = new ApplicationSetupPage(this);
			APS.Show();
			this.Hide();
		}
		private void Monitoring_Menu_Click(object sender, EventArgs e)
		{
			this.Show();
		}
	}
}
