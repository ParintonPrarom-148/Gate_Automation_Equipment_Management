using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Formatting = Newtonsoft.Json.Formatting;
namespace AGOS_GATE_EQUIPMENT
{
    public partial class BarrierPage : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private Form1 f1;
        public event Action<bool> IconStatusChanged;
        private int logAttemptCount = 0;
        public string SendS;
        public string SendS2;
        public string Date1;
        public string Date2;
        public string PickError;
        public string AnotherError99;
        public BarrierPage(Form1 F1)
        {
            InitializeComponent();
            this.Load += new EventHandler(BarrierPage_Load);
            random = new Random();
            InitializeTimer();
            this.f1 = F1; // เก็บ Reference ของ Form1
        }
        private void BarrierPage_Load(object sender, EventArgs e) // Load function
        {
            ThreadsAllCenter();
        }
        private (string username, string password) GetCredentials()
        {
            return ("root", "08700hPt");
        }
        public void ThreadsAllCenter()
        {
            Thread loadThreadsIP = new Thread(LoadBarrierIP);
            loadThreadsIP.Start();
            Thread timerThreadB = new Thread(() =>
            {
                Thread.Sleep(1000);
                if (this.IsHandleCreated && !this.Disposing && !this.IsDisposed)
                {
                    this.Invoke((Action)(() => GET_Barrier()));
                }
            });
            timerThreadB.Start();
            Thread timerThread = new Thread(() =>
            {
                Thread.Sleep(1000);
                if (this.IsHandleCreated && !this.Disposing && !this.IsDisposed)
                {
                    this.Invoke((Action)(() => GET_Sensor_Click(null, EventArgs.Empty)));
                }
            });
            timerThread.Start();
        }
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer
            {
                Interval = 15000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                await Task.Run(() => GET_Barrier());
                await GET_Sensor_Click(null, EventArgs.Empty);
                ConvertStatusToLog(SendS2, SendS, Date1, Date2);
            }
        }
        public void UpdateIconStatus(bool isOnline)
        {
            string path = Path.Combine(Application.StartupPath, "Images");
            if (isOnline)
            {
                BarrierIcon.Image = Image.FromFile(Path.Combine(path, "online_icon.png"));
            }
            else
            {
                BarrierIcon.Image = Image.FromFile(Path.Combine(path, "offline_icon.png"));
            }
            IconStatusChanged?.Invoke(isOnline);
        }
        private async Task system_barrier()
        {
            // 1. เปิด Barrier และ รอ 10 วินาที
            OpenB_Click(null, EventArgs.Empty);
            UpdateCheckThreadTime("Barrier is opening...");
            await Task.Delay(10000).ConfigureAwait(false); // รอ 10 วินาทีโดยไม่บล็อก UI Thread
            UpdateCheckThreadTime("Barrier opened for 10 seconds.");
            // 2. ตรวจสอบสถานะของ Sensor
            await CheckSensorStatus().ConfigureAwait(false);
            UpdateCheckThreadTime("Checked sensor status.");
            // 3. เช็ควัตถุที่พบใน Sensor
            bool foundObject = await CheckForObjectAsync("Found Object", 10, 5000).ConfigureAwait(false);
            if (foundObject)
            {
                UpdateCheckThreadTime("Object detected. Proceeding to next step.");
                await Task.Delay(10000).ConfigureAwait(false);
                PickError = "-";
            }
            else
            {
                await ShowMessageAndLog("No object found after 10 attempts. Barrier remains open."); // ใช้ await ที่นี่
                //CloseB_Click(null, EventArgs.Empty);
                return;
            }
            UpdateCheckThreadTime("Checked sensor and object detection.");
            // รอ 10 วินาทีอีกครั้ง
            await Task.Delay(10000).ConfigureAwait(false);
            await GET_Sensor_ClickAsync().ConfigureAwait(false);
            // ตรวจสอบสถานะ Sensor อีกครั้ง
            await CheckSensorStatus().ConfigureAwait(false);
            UpdateCheckThreadTime("Rechecked sensor status after detection.");
            // 5. เช็ควัตถุอีกครั้ง
            bool foundObject2 = await CheckForObjectAsync("Found Object", 3, 5000).ConfigureAwait(false);
            if (foundObject2 == true)
            {
                UpdateCheckThreadTime("Object detected again. Closing barrier.");
                CloseBarrier();
                PickError = "-";
            }
            else
            {
                await ShowMessageAndLog("No object found after 3 attempts. Barrier remains open."); // ใช้ await ที่นี่
                return;
            }
            UpdateCheckThreadTime("Process completed. All checks done.");
        }
        // ฟังก์ชันเพิ่มเติมสำหรับตรวจสอบสถานะข้อผิดพลาด
        private async Task<bool> CheckSensorErrorAsync()
        {
            // ตัวอย่างการเช็ค Sensor Error (คุณสามารถปรับแต่งได้ตามสถานการณ์จริง)
            await Task.Delay(500); // จำลองการดีเลย์สำหรับการตรวจสอบ Sensor
            bool hasError = false; // สมมติว่าไม่มีข้อผิดพลาด (เปลี่ยนได้ตามการตรวจสอบจริง)
            return hasError;
        }
        private async Task<bool> CheckForObjectAsync(string expectedStatus, int maxAttempts, int delayBetweenAttempts)
        {
            string SendErrorE6 = null;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                // Update the UI with the current attempt number
                UpdateCheckThreadTime($"Attempt {attempt}/{maxAttempts}: Checking for object...");
                await Task.Delay(1000).ConfigureAwait(false); // ดีเลย์การอัปเดต UI 1 วินาที
                string sensorStatus = await GetSensorStatusAsync().ConfigureAwait(false);
                // Debug: แสดงค่า sensorStatus ที่ได้
                UpdateCheckThreadTime($"Sensor status received: {sensorStatus}");
                // ตรวจสอบว่ามี Error หรือไม่
                if (sensorStatus.Contains("Error: An error occurred while sending the request."))
                {
                    MessageBox.Show("An error occurred while trying to communicate with the sensor. Please check your connection.");
                    AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "Connection Error", "Open", "An error occurred while trying to communicate with the sensor. Please check your connection.", "View");
                    PickError = "An error occurred while trying to communicate with the sensor. Please check your connection.";
                    ConvertStatusToLog(SendS2, SendS, Date1, Date2);//เก็บ log เมื่อ Error
                    return false; // คืนค่า false ถ้ามีข้อผิดพลาดในการเชื่อมต่อ
                }
                // แปลง JSON string เป็นวัตถุ ReplyMessage
                ReplyMessage reply;
                try
                {
                    reply = JsonConvert.DeserializeObject<ReplyMessage>(sensorStatus);
                    PickError = "-";
                }
                catch (JsonReaderException ex)
                {
                    SendErrorE6 = ex.Message;
                    MessageBox.Show($"Failed to parse sensor Object status: {ex.Message}");
                    AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "JSON Parse Error", "Open", $"Failed to parse sensor Object status: {ex.Message}", "View");
                    PickError = $"Failed to parse sensor Object status: {ex.Message}";
                    ConvertStatusToLog(SendS2, SendS, Date1, Date2); // เก็บ log เมื่อ Error
                    return false; // คืนค่า false ถ้าไม่สามารถแปลง JSON ได้
                }
                // ตรวจสอบสถานะที่ต้องการ
                if (reply != null && reply.Val == 1) // ใช้การตรวจสอบ Val แทน
                {
                    UpdateCheckThreadTime($"Attempt {attempt}: Object found.");
                    await Task.Delay(1000).ConfigureAwait(false); // ดีเลย์การอัปเดต UI 1 วินาที
                    return true;
                }
                UpdateCheckThreadTime($"Attempt {attempt}: Object not found. Waiting {delayBetweenAttempts / 1000} seconds before next attempt.");
                await Task.Delay(delayBetweenAttempts).ConfigureAwait(false); // ดีเลย์ระหว่างการพยายาม
            }
            UpdateCheckThreadTime($"Object not found after {maxAttempts} attempts.");
            return false;
        }
        private async Task GET_Sensor_ClickAsync()
        {
            await Task.Run(() => GET_Sensor_Click(null, EventArgs.Empty)).ConfigureAwait(false);
        }
        public async void GET_Barrier()
        {
            string url = $"http://{IPbox.Text}/di_value/slot_0/ch_0"; // ปรับให้ถูกต้องตาม API ของคุณ
            var (username, password) = GetCredentials();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);
                        // อัปเดต UI
                        UpdateResponseBarrierBox(formattedJson);
                        Status_BarrierB(formattedJson);
                        // แสดงไอคอน online
                        UpdateIconStatus(true);
                        IconStatusChanged?.Invoke(true); // เรียก event เพื่อส่งข้อมูลไป Form1
                    }
                    else
                    {
                        HandleErrorResponse(response);
                        // แสดงไอคอน offline
                        UpdateIconStatus(false);
                        IconStatusChanged?.Invoke(false); // เรียก event
                    }
                }
            }
            catch (Exception ex)
            {
                //UpdateCheckThreadTime($"Exception occurred: {ex.Message}");
                // แสดงไอคอน offline
                UpdateIconStatus(false);
                IconStatusChanged?.Invoke(false); // เรียก event
            }
        }
        private string ErrorSensor = string.Empty;
        private string ErrorS_Code = string.Empty;
        // ฟังก์ชันสำหรับอัปเดต ResponseBarrierBox
        private void UpdateResponseBarrierBox(string formattedJson)
        {
            if (ResponseBarrierBox.InvokeRequired)
            {
                ResponseBarrierBox.Invoke(new Action(() => UpdateResponseBarrierBox(formattedJson)));
            }
            else
            {
                ResponseBarrierBox.Text = formattedJson;
            }
        }
        private void UpdateCheckThreadTime(string text)
        {
            if (CheckThreadTime.InvokeRequired)
            {
                // เรียกใช้งาน UpdateCheckThreadTime ใน UI Thread
                CheckThreadTime.Invoke(new Action<string>(UpdateCheckThreadTime), text);
            }
            else
            {
                // อัปเดตข้อความใน Control
                CheckThreadTime.Text = text;
            }
        }
        private async Task ShowMessageAndLog(string message)
        {
            // แสดงข้อความใน MessageBox
            MessageBox.Show(message);
            string Tes = string.Empty;
            if (message == "No object found after 10 attempts. Barrier remains open.")
            {
                Tes = "AlwaysOpen";
            }
            else if (message == "No object found after 3 attempts. Barrier remains open.")
            {
                Tes = "AlwaysOpen";
            }
            // บันทึกลงใน BarrierViewL
            AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "Not Found", Tes, message, "View");
            // ดีเลย์ 5 วินาทีก่อนที่จะปิดการแจ้งเตือน
            await Task.Delay(5000).ConfigureAwait(false);
            // หากต้องการเคลียร์ข้อความหรือทำอย่างอื่นหลังจากดีเลย์
            // สามารถเพิ่มโค้ดที่นี่
        }
        private void UpdateStatusLabel(Label label, string statusText, Color statusColor)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    label.Text = statusText;
                    label.ForeColor = statusColor;
                });
            }
            else
            {
                label.Text = statusText;
                label.ForeColor = statusColor;
            }
        }
        private void Status_BarrierB(string formattedJson)
        {
            var reply = JsonConvert.DeserializeObject<ReplyMessage>(formattedJson);
            if (reply != null)
            {
                string statusText;
                Color statusColor;
                if (reply.Val == 1)
                {
                    statusText = "Barrier is Open";
                    statusColor = Color.Green;
                    SendS2 = "BarrierISOpen";
                    Date1 = DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {
                    statusText = "Barrier is Close";
                    statusColor = Color.Red;
                    SendS2 = "BarrierISClose";
                    Date1 = DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                UpdateStatusLabel(BarrierStatus, statusText, statusColor);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void ConvertStatusToLog(string SendS2, string SendS, string Date1, string Date2)
        {
            //Date2 = SensorD    Date 1 = BarrierD
            //SendS2 = Barrier  SendS = Sensor
            logAttemptCount++; // เพิ่มจำนวนรอบที่เรียกใช้ฟังก์ชัน
            var now = DateTime.Now;
            //---------- Sensor --------//
            var fileName2 = "KBSD1GH01_" + now.ToString("yyyyMMdd") + ".json";
            var filePath2 = Path.Combine(@"C:\admin\destop\D1GH01_LOG\BarrierStatus", fileName2);
            //---------------------
            try
            {
                var logBStatus = new List<BarrierStatusClass>();
                var filePathS = @"D:\AGOST_GATE\Gate_101_Dew.git\AGOS_GATE_EQUIPMENT\AGOS_GATE_EQUIPMENT\bin\Debug\Config.json";
                var jsonString = File.ReadAllText(filePathS);
                var jsonObject = JsonConvert.DeserializeObject<ConfigClass>(jsonString);
                // วนลูปเพื่อดึงข้อมูลจาก DataGridView
                //---------- แยก Discription -------------------------//
                //string description = "row.Cells[4].Value?.ToString()";
                string description = PickError ?? "";
                //--------------------------  ของ Sensor  ------------------------------//
                if (description.Contains("-"))
                {
                    /*
                    BarrierS = "-";
                    ErrorBarrierS = $"Failed to parse sensor status: {SendErrorE4}";
                    ErrorB_Code = "E4";
                    */
                    ErrorSensor = "Normal";
                }
                if (description.Contains("Sensor Failed to parse sensor status"))
                {
                    ErrorSensor = "Sensor Failed to parse sensor status";
                }
                else if (description.Contains("An error occurred while checking sensor status"))
                {
                    /*
                    BarrierS = "-";
                    ErrorBarrierS = $"An error occurred while checking sensor status: {SendErrorE5}";
                    ErrorB_Code = "E5";
                    */
                    ErrorSensor = PickError;
                    //ErrorSensor = $"An error occurred while checking sensor status: {SendErrorE5}";
                }
                else if (description.Contains("Failed to parse sensor Object status"))
                {
                    /*
                    BarrierS = "-";
                    ErrorBarrierS = $"Failed to parse sensor status: {SendErrorE6}";
                    ErrorB_Code = "E6";
                    */
                    ErrorSensor = PickError;
                    //ErrorSensor = $"Failed to parse sensor status: {SendErrorE6.ToString()}";
                }
                else if (description.Contains("An error occurred while trying to communicate with the sensor. Please check your connection"))
                {
                    /*
                    BarrierS = "-";
                    ErrorBarrierS = "An error occurred while trying to communicate with the sensor. Please check your connection.";
                    ErrorB_Code = "E7";
                    */
                    ErrorSensor = "An error occurred while trying to communicate with the sensor. Please check your connection.";
                }
                else if (description.Contains("Error detected after waiting period"))
                {
                    /*
                    BarrierS = "-";
                    ErrorBarrierS = "An error occurred while trying to communicate with the sensor. Please check your connection.";
                    ErrorB_Code = "E7";
                    */
                    ErrorSensor = "Error detected after waiting period. Barrier remains open.";
                }
                else
                {
                    ErrorSensor = "NORMAL";
                }
                //---------------------------------------------------//
                var logBarrierStatus = new BarrierStatusClass
                {
                    TerminalId = jsonObject?.TerminalNo ?? "",
                    GateLaneId = jsonObject?.GateLaneNo ?? "",
                    BarrierStatus = SendS2,
                    BarrierStatusDateTime = Date1,
                    SensorStatus = SendS,
                    SensorStatusDateTime = Date2,
                    ErrorStatus = ErrorSensor,
                };
                logBStatus.Add(logBarrierStatus);
                var jsonOutput2 = new { BarrierStatus = logBStatus };
                //File.AppendAllText(filePath2, JsonConvert.SerializeObject(jsonOutput2, Formatting.Indented));
                string fileContent = File.Exists(filePath2) ? File.ReadAllText(filePath2) : string.Empty;
                // ตรวจสอบว่ามี SensorLog อยู่ในไฟล์หรือไม่
                if (string.IsNullOrEmpty(fileContent) || !JObject.Parse(fileContent).ContainsKey("BarrierStatus"))
                {
                    // ถ้าไม่มี SensorLog ในไฟล์ ให้ทำการ append
                    File.WriteAllText(filePath2, JsonConvert.SerializeObject(jsonOutput2, Formatting.Indented));
                    Console.WriteLine("ข้อมูล SensorLog ถูกเพิ่มเข้าไปในไฟล์เรียบร้อยแล้ว");
                }
                else
                {
                    var existingData = JObject.Parse(fileContent);
                    var sensorLogArray = existingData["BarrierStatus"] as JArray;
                    // สร้าง logSensor ใหม่สำหรับการเพิ่มในกรณีที่มี SensorLog อยู่แล้ว
                    var newLogSensor = new JObject
                    {
                        ["TerminalId"] = jsonObject?.TerminalNo ?? "",
                        ["GateLaneId"] = jsonObject?.GateLaneNo ?? "",
                        ["BarrierStatus"] = SendS2,
                        ["BarrierStatusDateTime"] = Date1,
                        ["SensorStatus"] = SendS,
                        ["SensorStatusDateTime"] = Date2,
                        ["ErrorStatus"] = ErrorSensor,
                    };
                    // เพิ่ม newLogSensor เข้าไปในอาเรย์
                    sensorLogArray.Add(newLogSensor);
                    // เขียนข้อมูลกลับไปที่ไฟล์
                    File.WriteAllText(filePath2, existingData.ToString(Formatting.Indented));
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
                    //MessageBox.Show("Oh Yeah: ");
                }
                // คุณอาจต้องการรีเซ็ตจำนวนรอบที่นี่หรือเพิ่มเงื่อนไขเพิ่มเติมตามความต้องการ
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private async Task<string> GET_Sensor_Click(object sender, EventArgs e)
        {
            string url = $"http://{IPbox.Text}/di_value/slot_0/ch_2";
            var (username, password) = GetCredentials();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);
                        // เรียก UpdateAutoRestTextBox ที่นี่
                        UpdateAutoRestTextBox(formattedJson);
                        Status_Sensor(formattedJson);
                        return formattedJson;
                    }
                    else
                    {
                        HandleErrorResponse(response);
                        return $"Error Code: {(int)response.StatusCode} - {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateAutoRestTextBox($"Exception occurred: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }
        private void UpdateAutoRestTextBox(string text)
        {
            // ตรวจสอบว่าเรากำลังอยู่ในเทรดหลักของ UI หรือไม่
            if (AutoRestTextBox.InvokeRequired)
            {
                // ใช้ Invoke เพื่อรันการอัปเดตในเทรดหลักของ UI
                AutoRestTextBox.Invoke(new Action(() => AutoRestTextBox.Text = text));
            }
            else
            {
                // ถ้าอยู่ในเทรดหลักของ UI แล้ว ให้เซ็ตข้อความได้โดยตรง
                AutoRestTextBox.Text = text;
            }
        }
        private async Task<string> GetSensorStatusAsync()
        {
            return await GET_Sensor_Click(null, EventArgs.Empty).ConfigureAwait(false);
        }
        public string SendErrorE4 { get; set; }
        public string SendErrorE5 { get; set; }
        public string SendErrorE6 { get; set; }
        private async Task CheckSensorStatus()
        {
            string SendErrorE4 = null;
            string SendErrorE5 = null;
            try
            {
                string sensorStatus = await GetSensorStatusAsync();
                // ตรวจสอบว่า sensorStatus เป็น JSON ที่ถูกต้องหรือไม่
                if (string.IsNullOrWhiteSpace(sensorStatus))
                {
                    MessageBox.Show("Received empty response from the API.");
                    return;
                }
                // ตรวจสอบถ้ามี Error
                if (sensorStatus.Contains("Error"))
                {
                    MessageBox.Show("Error detected after waiting period. Barrier remains open.");
                    AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "Error CheckStatus", "Open", "Error detected after waiting period. Barrier remains open.", "View");
                    PickError = "Error detected after waiting period. Barrier remains open.";
                    ConvertStatusToLog(SendS2, SendS, Date1, Date2);
                    return;
                }
                // ลอง Deserialize JSON
                try
                {
                    var reply = JsonConvert.DeserializeObject<ReplyMessage>(sensorStatus);
                    // ดำเนินการกับ reply ที่ได้
                    PickError = "-";
                }
                catch (JsonReaderException ex)
                {
                    SendErrorE4 = ex.Message;
                    MessageBox.Show($"Sensor Failed to parse sensor status: {ex.Message}");
                    AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "JSON Parse Error", "Open", $"Sensor Failed to parse sensor status: {ex.Message}", "View");
                    f1.SendErrorE4 = SendErrorE4;
                    PickError = $"Sensor Failed to parse sensor status: {ex.Message}";
                    ConvertStatusToLog(SendS2, SendS, Date1, Date2);
                }
            }
            catch (Exception ex)
            {
                SendErrorE5 = ex.Message;
                MessageBox.Show($"An error occurred while checking sensor status: {ex.Message}");
                AddRowToGrid(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "-", "Error CheckStatus", "Open", $"An error occurred while checking sensor status: {ex.Message}", "View");
                f1.SendErrorE5 = SendErrorE5;
                PickError = $"An error occurred while checking sensor status: {ex.Message}";
                ConvertStatusToLog(SendS2, SendS, Date1, Date2);//เก็บ log 
            }
        }
        // ฟังก์ชันเพื่ออัปเดต UI ใน thread หลัก
        private void AddRowToGrid(string time, string id, string status, string state, string message, string view)
        {
            if (f1.BarrierViewL.InvokeRequired)
            {
                // ใช้ Invoke เพื่อให้แน่ใจว่าทำงานบน UI thread
                f1.BarrierViewL.Invoke(new Action(() =>
                {
                    f1.BarrierViewL.Rows.Add(time, id, status, state, message, view);
                }));
            }
            else
            {
                f1.BarrierViewL.Rows.Add(time, id, status, state, message, view);
            }
        }
        private void Status_Sensor(string formattedJson)
        {
            try
            {
                // พยายามแปลงข้อมูล JSON
                var reply = JsonConvert.DeserializeObject<ReplyMessage>(formattedJson);
                if (reply != null)
                {
                    string statusText;
                    Color statusColor;
                    // ตรวจสอบค่าว่าพบวัตถุหรือไม่
                    if (reply.Val == 1)
                    {
                        statusText = "Found Object";
                        statusColor = Color.Green;
                        SendS = "FoundObject";
                        Date2 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                    else
                    {
                        statusText = "Not Found Object";
                        statusColor = Color.Red;
                        SendS = "NotFoundObject";
                        Date2 = DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                    // อัปเดต UI ด้วยข้อความและสี
                    UpdateStatusLabel(SensorStatus, statusText, statusColor);
                    ConvertStatusToLog(SendS2, SendS, Date1, Date2);
                }
            }
            catch (JsonException jsonEx) // จัดการข้อผิดพลาดที่เกี่ยวกับการแปลง JSON
            {
                UpdateCheckThreadTime($"JSON error: {jsonEx.Message}");
            }
            catch (Exception ex) // จัดการข้อผิดพลาดทั่วไปอื่นๆ
            {
                UpdateCheckThreadTime($"An error occurred: {ex.Message}");
            }
        }
        private void HandleErrorResponse(HttpResponseMessage response)
        {
            string errorMessage = $"Error Code: {(int)response.StatusCode} - {response.ReasonPhrase}";
            AutoRestTextBox.Text = "You Can not Auth";
            RestStatus.Text = errorMessage;
            Status_Sensor(errorMessage);
        }
        // เมธอดช่วยในการจัดรูปแบบ JSON
        private string FormatJson(HttpContent content)
        {
            string requestBody = content.ReadAsStringAsync().Result; // อ่านเนื้อหาแบบ synchronous
            try
            {
                var jsonObject = JObject.Parse(requestBody);
                return jsonObject.ToString(Newtonsoft.Json.Formatting.Indented);
            }
            catch (JsonException ex)
            {
                return $"Invalid JSON format: {ex.Message}";
            }
        }
        private async void OpenB_Click(object sender, EventArgs e)
        {
            await OpenCloseBarrierAsync(true);
        }
        private async void CloseB_Click(object sender, EventArgs e)
        {
            await OpenCloseBarrierAsync(false);
        }
        private void CloseBarrier()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(CloseBarrier));
                return;
            }
            CloseB_Click(null, EventArgs.Empty);
        }
        private async Task OpenCloseBarrierAsync(bool open)
        {
            string SendRequest = string.Empty;
            string json = open
                ? "{\"DOVal\":[{\"Ch\":0,\"Md\":0,\"Stat\":1,\"Val\":1,\"PsCtn\":0,\"PsStop\":0,\"PsIV\":0}]}"
                : "{\"DOVal\":[{\"Ch\":1,\"Md\":0,\"Stat\":1,\"Val\":1,\"PsCtn\":0,\"PsStop\":0,\"PsIV\":0}]}";
            string url = $"http://{IPbox.Text}/do_value/slot_0";
            var (username, password) = GetCredentials();
            string S1 = "{\"DOVal\":[{\"Ch\":0,\"Md\":0,\"Stat\":1,\"Val\":1,\"PsCtn\":0,\"PsStop\":0,\"PsIV\":0}]}";
            string S2 = "{\"DOVal\":[{\"Ch\":1,\"Md\":0,\"Stat\":1,\"Val\":1,\"PsCtn\":0,\"PsStop\":0,\"PsIV\":0}]}";
            try
            {
                using (var client = new HttpClient())
                {
                    var authHeader = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    RequestOP.Text = FormatJson(content);
                    if (JToken.DeepEquals(JToken.Parse(RequestOP.Text), JToken.Parse(S1)))
                    {
                        //MessageBox.Show("Open");
                        SendRequest = "OPEN";
                    }
                    else if (JToken.DeepEquals(JToken.Parse(RequestOP.Text), JToken.Parse(S2)))
                    {
                        //MessageBox.Show("Close");
                        SendRequest = "CLOSE";
                    }
                    // ส่ง request และรับ response
                    HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
                    var statusCode = response.StatusCode;
                    // อ่านและแสดง response body
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    // อัปเดต UI ในนี้
                    this.Invoke((MethodInvoker)delegate
                    {
                        ResponseOC.Text = $"Status Code: {statusCode}";
                        if (!response.IsSuccessStatusCode)
                        {
                            ResponseOC.Text += $"\nError: {statusCode}";
                            return;
                        }
                        ResOriginal.Text = string.IsNullOrWhiteSpace(responseBody)
                            ? "Response body is empty."
                            : $"Response: {responseBody}"; //
                        ProcessResponse(responseBody, open, SendRequest);
                        // เรียกใช้ GET เพื่อตรวจสอบสถานะไม้กั้นหลังจากการเปิด/ปิด
                        GET_Barrier();
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ResponseOC.Text = $"Exception occurred: {ex.Message}";
                });
            }
        }
        private string ExtractJsonFromResponse(string responseBody)
        {
            // ค้นหาจุดเริ่มต้นของ JSON
            int jsonStartIndex = responseBody.IndexOf('{');
            return jsonStartIndex == -1 ? string.Empty : responseBody.Substring(jsonStartIndex);
        }
        private void ProcessResponse(string responseBody, bool isOpen, string SendRequest)
        {
            string action = isOpen ? "OPEN" : "CLOSE";
            string message = isOpen ? "Barrier is Open" : "Barrier is Closed";
            f1.BarrierViewL.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), SendRequest, "-", action, message, "View");
        }
        private bool IsJsonValid(string json)
        {
            // ตรวจสอบว่า JSON มีรูปแบบถูกต้อง
            json = json.Trim();
            return json.StartsWith("{") && json.EndsWith("}");
        }
        private void ToggleVisibility(Control[] controls)
        {
            bool isVisible = !controls[0].Visible; // ใช้ค่าจาก Control แรกเป็นตัวกำหนด
            foreach (var control in controls)
            {
                control.Visible = isVisible;
            }
        }
        private void ShowRealy_Click(object sender, EventArgs e)
        {
            ToggleVisibility(new Control[]
            {
        AutoRestTextBox, RestStatus, Test, ResOriginTxt,
        ResOriginal, CheckThreadTime, ResponseOC,
        ResponseOC2, RequestOP, RequestOPtxt,
        ResponseBarrierBox, ResponseBarrierBoxtxt,
        RsensorTxt, StatusTxt
            });
        }
        private void SaveIP_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\ipAddress.json";
            var ipAddress = IPbox.Text;
            try
            {
                // สร้างวัตถุที่ต้องการเขียนลงไฟล์ JSON
                var jsonObject = new { IP = ipAddress };
                var jsonString = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("IP address saved to JSON file successfully.");
                //ConvertStatusToLog(SendS2, SendS, Date1, Date2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving IP address: {ex.Message}");
            }
        }
        private void LoadBarrierIP()
        {
            string filePath = @"D:\ipAddress.json";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return;
            }
            try
            {
                var jsonString = File.ReadAllText(filePath);
                var jsonObject = JsonConvert.DeserializeObject<IPAddressObject>(jsonString);
                string ip = jsonObject?.IP ?? "No IP address found";
                // ใช้ Invoke เพื่ออัปเดต UI
                if (IPbox.InvokeRequired)
                {
                    IPbox.Invoke(new Action(() => IPbox.Text = ip));
                }
                else
                {
                    IPbox.Text = ip;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading IP address: {ex.Message}");
            }
        }
        public class IPAddressObject
        {
            public string IP { get; set; }
        }
        private void BackPage_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private async void FB_Test_Click(object sender, EventArgs e)
        {
            await system_barrier();
        }
        private void CheckThreadTime_TextChanged(object sender, EventArgs e)
        {
            // สามารถเพิ่มการดำเนินการที่เกี่ยวข้องได้ที่นี่
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
            this.Show();
        }
        private void Application_Setup_Menu_Click(object sender, EventArgs e)
        {
            ApplicationSetupPage APS = new ApplicationSetupPage(f1);
            APS.Show();
            this.Hide();
        }
    }
}