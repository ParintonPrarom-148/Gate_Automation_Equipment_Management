using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PcscDotNet;
using SmartcardLibrary;
using static AGOS_GATE_EQUIPMENT.Config;
namespace AGOS_GATE_EQUIPMENT
{
    public partial class CardReaderPage : Form
    {
        private System.Windows.Forms.Timer timer;
        private SmartcardManager manager = SmartcardManager.GetManager();
        private Timer statusTimer;
        Form1 f1;
        private BarrierPage BP;
        public string PickReaderError;
        private int logAttemptCount = 0;
        public string SendFormat;
        public string SendStatusDate;
        public CardReaderPage(Form1 F1)
        {
            InitializeComponent();
            BP = new BarrierPage(f1);
            StartSaveTime();
            this.Load += new EventHandler(CardReaderPage_Load);
            this.f1 = F1; // เก็บ Reference ของ Form1
            StartSaveTime();
            ReaderStatusTime();
            SaveLogStatusReaderTime();
        }
        //-------------------- Status -----------------------//
        private void SaveLogStatusReaderTime()
        {
            statusTimer = new Timer();
            statusTimer.Interval = 5000;
            statusTimer.Tick += StatusSave_Tick;
            statusTimer.Start();
        }
        private void StatusSave_Tick(object sender, EventArgs e)
        {
            ConvertReaderStatusToLog();
        }
        ///-----
        private void ReaderStatusTime()
        {
            statusTimer = new Timer();
            statusTimer.Interval = 1000; // Interval in milliseconds (e.g., 1000 = 1 second)
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start(); // Start the timer
        }
        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            bool isOnline = CheckCardReaderConnection(); // Check if the card reader is online
            UpdateIconStatus(isOnline); // Update card reader status on each tick
        }
        private bool CheckCardReaderConnection()
        {
            bool isOnline = false;
            // Query to check if any card reader is connected
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Description LIKE '%Card Reader%'"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    isOnline = true; // Set to true if at least one card reader is found
                    break;
                }
            }
            return isOnline;
        }
        private void UpdateIconStatus(bool isOnline)
        {
            string path = Path.Combine(Application.StartupPath, "Images");
            if (isOnline)
            {
                ReaderIcon.Image = Image.FromFile(Path.Combine(path, "online_icon.png"));
                SendStatusDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                ReaderIcon.Image = Image.FromFile(Path.Combine(path, "offline_icon.png"));
                SendStatusDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
        //------------------------
        //-----------------------
        private void CardReaderPage_Load(object sender, EventArgs e)
        {
        }
        private int clickCount = 0;
        private void Single_Type_BTN_Click(object sender, EventArgs e)
        {
        }
        private void Dual_Type_BTN_Click(object sender, EventArgs e)
        {
            if (clickCount == 1)
            {
                MessageBox.Show("A");
            }
            else if (clickCount == 2)
            {
                MessageBox.Show("B");
                clickCount = 0; // รีเซ็ตนับจำนวนคลิกหลังจากกดครั้งที่ 2
            }
        }
        //----------------
        public void StartSaveTime()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += ReaderReadingValue;
            timer.Start();
        }
        //---------------------------------
        public string E1 = "An internal consistency check failed";
        public string E2 = "The action was canceled by a SCardCancel request";
        public string E3 = "The supplied handle was invalid";
        public string E4 = "One or more of the supplied parameters could not be properly interpreted";
        public string E5 = "Registry startup information is missing or invalid";
        public string E6 = "Not enough memory available to complete this command";
        public string E7 = "An internal consistency timer has expired";
        public string E8 = "The data buffer to receive returned data is too small for the returned data";
        public string E9 = "The specified reader name is not recognized";
        public string E10 = "The user-specified timeout value has expired";
        public string E11 = "The smart card cannot be accessed because of other connections outstanding";
        public string E12 = "The operation requires a smart card, but no smart card is currently in the device";
        public string E13 = "The specified smart card name is not recognized";
        public string E14 = "The system could not dispose of the media in the requested manner";
        public string E15 = "The requested protocols are incompatible with the protocol currently in use with the smart card";
        public string E16 = "The reader or smart card is not ready to accept commands";
        public string E17 = "One or more of the supplied parameter values could not be properly interpreted";
        public string E18 = "The action was canceled by the system, presumably to log off or shut down";
        public string E19 = "An internal communications error has been detected";
        public string E20 = "An internal error has been detected, but the source is unknown";
        public string E21 = "An ATR obtained from the registry is not a valid ATR string";
        public string E22 = "An attempt was made to end a non-existent transaction";
        public string E23 = "The specified reader is not currently available for use";
        public string E23_2 = "The specified reader is not currently available ";
        public string E24 = "The operation has been aborted to allow the server application to exit";
        public string E25 = "The PCI Receive buffer was too small";
        public string E26 = "The reader driver does not meet minimal requirements for support";
        public string E27 = "The reader driver did not produce a unique reader name";
        public string E28 = "The smart card does not meet minimal requirements for support";
        public string E29 = "The Smart Card Resource Manager is not running";
        public string E30 = "The Smart Card Resource Manager has shut down";
        public string E31 = "An unexpected card error has occurred";
        public string E32 = "No primary provider can be found for the smart card";
        public string E33 = "The requested order of object creation is not supported";
        public string E34 = "This smart card does not support the requested feature";
        public string E35 = "The identified directory does not exist in the smart card";
        public string E36 = "The identified file does not exist in the smart card";
        public string E37 = "The supplied path does not represent a smart card directory";
        public string E38 = "The supplied path does not represent a smart card file";
        public string E39 = "Access is denied to this file";
        public string E40 = "The smart card does not have enough memory to store the information";
        public string E41 = "There was an error trying to set the smart card file object pointer";
        public string E42 = "The supplied PIN is incorrect";
        public string E43 = "An unrecognized error code was returned from a layered component";
        public string E44 = "The requested certificate does not exist";
        public string E45 = "The requested certificate could not be obtained";
        public string E46 = "Cannot find a smart card reader";
        public string E47 = "A communications error with the smart card has been detected. Retry the operation";
        public string E48 = "The requested key container does not exist on the smart card";
        public string E49 = "The Smart Card Resource Manager is too busy to complete this operation";
        public string E50 = "The reader cannot communicate with the card";
        public string E50_2 = "due to ATR string configuration conflicts";
        public string E51 = "The smart card is not responding to a reset";
        public string E52 = "Power has been removed from the smart card";
        public string E52_2 = "so that further communication is not possible";
        public string E53 = "The smart card has been reset";
        public string E53_2 = "so any shared state information is invalid";
        public string E54 = "The smart card has been removed";
        public string E54_2 = "so further communication is not possible";
        public string E55 = "Access was denied because of a security violation";
        public string E56 = "The card cannot be accessed because the wrong PIN was presented";
        public string E57 = "The card cannot be accessed because the maximum number of PIN entry attempts has been reached";
        public string E58 = "The end of the smart card file has been reached";
        public string E59 = "The action was canceled by the user";
        public string E60 = "No PIN was presented to the smart card";
        public string E63 = "old card capture";
        public void ReaderReadingValue(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCardReaderConnection())
                {
                    //MessageBox.Show("NOT_RESPOND_COMMAND");
                    PickReaderError = "Offline";
                    return; 
                }
                if (SmartcardManager.message.Length > 0)
                {
                    // ตัวแปรสำหรับเก็บค่าที่อ่านได้และข้อผิดพลาด
                    string ErrorL = "";
                    string Reading = "";
                    string Format = "";
                    SendFormat = "";
                    var FileP = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
                    var jsonString = File.ReadAllText(FileP);
                    var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
                    // แยกข้อมูลจาก SmartcardManager.message
                    string[] messages = SmartcardManager.message.Split(',');
                    foreach (string msg in messages)
                    {
                        // เช็คว่าข้อความเป็นข้อผิดพลาดหรือข้อมูลที่อ่านได้
                        if (msg.ToLower().Contains(E1) ||
                            msg.ToLower().Contains(E2) ||
                            msg.ToLower().Contains(E3) ||
                            msg.ToLower().Contains(E4) ||
                            msg.ToLower().Contains(E5) ||
                            msg.ToLower().Contains(E6) ||
                            msg.ToLower().Contains(E7) ||
                            msg.ToLower().Contains(E8) ||
                            msg.ToLower().Contains(E9) ||
                            msg.ToLower().Contains(E10) ||
                            msg.ToLower().Contains(E11) ||
                            msg.ToLower().Contains(E12) ||
                            msg.ToLower().Contains(E13) ||
                            msg.ToLower().Contains(E14) ||
                            msg.ToLower().Contains(E15) ||
                            msg.ToLower().Contains(E16) ||
                            msg.ToLower().Contains(E17) ||
                            msg.ToLower().Contains(E18) ||
                            msg.ToLower().Contains(E19) ||
                            msg.ToLower().Contains(E20) ||
                            msg.ToLower().Contains(E21) ||
                            msg.ToLower().Contains(E22) ||
                            //
                            msg.ToLower().Contains(E23) ||
                            msg.ToLower().Contains(E23_2) ||
                            //
                            msg.ToLower().Contains(E24) ||
                            msg.ToLower().Contains(E25) ||
                            msg.ToLower().Contains(E26) ||
                            msg.ToLower().Contains(E27) ||
                            msg.ToLower().Contains(E28) ||
                            msg.ToLower().Contains(E29) ||
                            msg.ToLower().Contains(E30) ||
                            msg.ToLower().Contains(E31) ||
                            msg.ToLower().Contains(E32) ||
                            msg.ToLower().Contains(E33) ||
                            msg.ToLower().Contains(E34) ||
                            msg.ToLower().Contains(E35) ||
                            msg.ToLower().Contains(E36) ||
                            msg.ToLower().Contains(E37) ||
                            msg.ToLower().Contains(E38) ||
                            msg.ToLower().Contains(E39) ||
                            msg.ToLower().Contains(E40) ||
                            msg.ToLower().Contains(E41) ||
                            msg.ToLower().Contains(E42) ||
                            msg.ToLower().Contains(E43) ||
                            msg.ToLower().Contains(E44) ||
                            msg.ToLower().Contains(E45) ||
                            msg.ToLower().Contains(E46) ||
                            msg.ToLower().Contains(E47) ||
                            msg.ToLower().Contains(E48) ||
                            msg.ToLower().Contains(E49) ||
                            //
                            msg.ToLower().Contains(E50) ||
                            msg.ToLower().Contains(E50_2) ||
                            //
                            msg.ToLower().Contains(E51) ||
                            //
                            msg.ToLower().Contains(E52) ||
                            msg.ToLower().Contains(E52_2) ||
                            msg.ToLower().Contains(E53) ||
                            msg.ToLower().Contains(E53_2) ||
                            msg.ToLower().Contains(E54) ||
                            msg.ToLower().Contains(E54_2) ||
                            //
                            msg.ToLower().Contains(E55) ||
                            msg.ToLower().Contains(E56) ||
                            msg.ToLower().Contains(E57) ||
                            msg.ToLower().Contains(E58) ||
                            msg.ToLower().Contains(E59) ||
                            msg.ToLower().Contains(E60) ||
                            msg.ToLower().Contains("main errror |") ||
                            msg.ToLower().Contains("final error |") ||
                            msg.ToLower().Contains("main errror") ||
                            msg.ToLower().Contains("final error") ||
                            msg.ToLower().Contains("error") ||
                            msg.ToLower().Contains("removed") ||
                            msg.ToLower().Contains(E63))
                        {
                            //ErrorL += msg + Environment.NewLine;
                            ErrorL = msg;
                            f1.GetErrorL = ErrorL;
                        }
                        else
                        {
                            if (msg.Length > 1)
                            {
                                Reading = msg;
                            }
                            // เช็คว่าเป็นเลขบัตรประชาชน 13 หลักหรือไม่
                            if (msg.Length == 13 && long.TryParse(msg, out _))
                            {
                                Format = msg; // เก็บเลขบัตรประชาชน
                                SendFormat = msg;
                                //MessageBox.Show(SendFormat);
                                ConvertReaderStatusToLog();
                            }
                        }
                    }
                    this.ReaderReturnValueBox.Text = Reading;
                    f1.ReaderViewL.Rows.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Format, ErrorL, Reading, "View");
                    SmartcardManager.message = "";
                    if (!string.IsNullOrEmpty(ErrorL))
                    {
                        Console.WriteLine("Errors detected: " + Environment.NewLine + ErrorL);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}");
            }
        }
        private void BackBTN_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void SaveBTN_Click(object sender, EventArgs e)
        {
            ConvertReaderStatusToLog();
        }
        private void ReaderReturnValueBox_TextChanged(object sender, EventArgs e)
        {
        }
        public string ErrorS_DESC;
        public string ErrorCS_Code;
        private void ConvertReaderStatusToLog()
        {
            logAttemptCount++; // เพิ่มจำนวนรอบที่เรียกใช้ฟังก์ชัน
            var now = DateTime.Now;
            //---------- Sensor --------//
            var fileName2 = "KCSD1GH01_" + now.ToString("yyyyMMdd") + ".json";
            var RSfilePath2 = Path.Combine(@"C:\admin\destop\D1GH01_LOG\CardReaderStatus", fileName2);
            //---------------------
            try
            {
                var logCR = new List<ReaderStatusClass>();
                var filePathS = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
                var jsonString = File.ReadAllText(filePathS);
                var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
                // วนลูปเพื่อดึงข้อมูลจาก DataGridView
                //---------- แยก Discription -------------------------//
                //string description = "row.Cells[4].Value?.ToString()";
                string description = PickReaderError ?? "";
                //--------------------------  ของ Sensor  ------------------------------//
                if (description.Contains("NOT_RESPOND_COMMAND"))
                {
                    ErrorS_DESC = "Not respond command";
                    //ErrorCS_Code = "E101";
                }
                else if (description.Contains("Offline"))
                {
                    ErrorS_DESC = "Offline";
                    //ErrorCS_Code = "E102";
                }
                else if (description.Contains("Online"))
                {
                    ErrorS_DESC = "Normal";
                    //ErrorCS_Code = "-";
                }
                else
                {
                    ErrorS_DESC = "Others";
                    //ErrorCS_Code = "E199";
                }
                //---------------------------------------------------//
                var logR = new ReaderStatusClass
                {
                    TerminalId = jsonObject?.TerminalNo ?? "",
                    GateLaneId = jsonObject?.GateLaneNo ?? "",
                    ReaderFormat = SendFormat,
                    StatusDatetime = SendStatusDate,
                    ErrorStatus = ErrorS_DESC,
                };
                logCR.Add(logR);
                var jsonOutput4 = new { CardReaderStatus = logCR };
                //File.AppendAllText(filePath2, JsonConvert.SerializeObject(jsonOutput2, Formatting.Indented));
                string fileContent = File.Exists(RSfilePath2) ? File.ReadAllText(RSfilePath2) : string.Empty;
                // ตรวจสอบว่ามี SensorLog อยู่ในไฟล์หรือไม่
                if (string.IsNullOrEmpty(fileContent) || !JObject.Parse(fileContent).ContainsKey("CardReaderStatus"))
                {
                    // ถ้าไม่มี SensorLog ในไฟล์ ให้ทำการ append
                    File.WriteAllText(RSfilePath2, JsonConvert.SerializeObject(jsonOutput4, Formatting.Indented));
                    Console.WriteLine("ข้อมูล SensorLog ถูกเพิ่มเข้าไปในไฟล์เรียบร้อยแล้ว");
                }
                else
                {
                    var existingData = JObject.Parse(fileContent);
                    var sensorLogArray = existingData["CardReaderStatus"] as JArray;
                    // สร้าง logSensor ใหม่สำหรับการเพิ่มในกรณีที่มี SensorLog อยู่แล้ว
                    var newLogSensor = new JObject
                    {
                        ["TerminalId"] = jsonObject?.TerminalNo ?? "",
                        ["GateLaneId"] = jsonObject?.GateLaneNo ?? "",
                        ["ReaderFormat"] = SendFormat,
                        ["StatusDatetime"] = SendStatusDate,
                        ["ErrorStatus"] = ErrorS_DESC,
                    };
                    // เพิ่ม newLogSensor เข้าไปในอาเรย์
                    sensorLogArray.Add(newLogSensor);
                    // เขียนข้อมูลกลับไปที่ไฟล์
                    File.WriteAllText(RSfilePath2, existingData.ToString(Formatting.Indented));
                    Console.WriteLine("ข้อมูล SensorLog ใหม่ถูกเพิ่มเข้าไปในไฟล์เรียบร้อยแล้ว");
                }
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
        private void Monitoring_Menu_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void ID_Card_Reader_Setup_Menu_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        private void Barrier_Setup_Menu_Click(object sender, EventArgs e)
        {
            BarrierPage barrierPage = new BarrierPage(f1);
            barrierPage.Show();
            this.Hide();
        }
        private void Application_Setup_Menu_Click(object sender, EventArgs e)
        {
            ApplicationSetupPage APS = new ApplicationSetupPage(f1);
            APS.Show();
            this.Hide();
        }
    }
}
