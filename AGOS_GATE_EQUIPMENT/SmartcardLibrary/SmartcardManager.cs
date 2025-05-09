using PcscDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsInput;


namespace SmartcardLibrary
{
    internal enum SmartcardState
    {
        None = 0,
        Inserted = 1,
        Ejected = 2
    }

    public class SmartcardManager : IDisposable
    {
        #region Member Fields

        //Shared members are lazily initialized.
        //.NET guarantees thread safety for shared initialization.
        private static readonly SmartcardManager _instance = new SmartcardManager();

        private SmartcardContextSafeHandle _context;
        private PcscContext pContext;
        private PcscConnection pConnect;
        string[] _readers;
        static string[] args;
        static bool singleTypeFlag;
        static int counter = 0;
        public static string message = "";

        private SmartcardErrorCode _lastErrorCode;
        private bool _disposed = false;
        private ReaderState[] _states;
        //A thread that watches for new smart cards.
        private BackgroundWorker _worker;

        #endregion

        #region Methods

        //Make the constructor private to hide it. This class adheres to the singleton pattern.
        private SmartcardManager()
        {
            //Create a new SafeHandle to store the smartcard context.
            //this._context = new SmartcardContextSafeHandle();
            this.pContext = new PcscContext();


            //Establish a context with the PC/SC resource manager.
            //this.EstablishContext();
            this.PEstablishContext();

            //Compose a list of the card readers which are connected to the
            //system and which will be monitored.
            //ArrayList availableReaders = this.ListReaders();
            ArrayList availableReaders = this.PListReaders();
            _readers = (string[])availableReaders.ToArray(typeof(string));


            this._states = new ReaderState[availableReaders.Count];
            for (int i = 0; i <= availableReaders.Count - 1; i++)
            {
                this._states[i].Reader = availableReaders[i].ToString();
            }

            //Start a background worker thread which monitors the specified
            //card readers.
            if ((availableReaders.Count > 0))
            {
                this._worker = new BackgroundWorker();
                this._worker.WorkerSupportsCancellation = true;
                //this._worker.DoWork += WaitChangeStatus;
                this._worker.DoWork += PWaitChangeStatus;

                this._worker.RunWorkerAsync();
            }

        }

        public static SmartcardManager GetManager()
        {
            return _instance;
        }


        public static int getCounter()
        {
            return counter;

        }

        public static void SetArgs(string[] argsP)
        {
            args = argsP;
        }

        public static void SetSingleType(bool singleFlag)
        {
            singleTypeFlag = singleFlag;
        }


        private bool EstablishContext()
        {
            if ((this.HasContext))
            {
                return true;
            }
            this._lastErrorCode =
                (SmartcardErrorCode)UnsafeNativeMethods.EstablishContext(ScopeOption.System,
                IntPtr.Zero, IntPtr.Zero, ref this._context);
            return (this._lastErrorCode == SmartcardErrorCode.None);
        }

        private bool PEstablishContext()
        {
            if ((this.HasPContext))
            {
                return true;
            }

            try
            {
                pContext = Pcsc<WinSCard>.EstablishContext(SCardScope.User);
            }
            catch (Exception ex)
            {
                Console.Write("Establised context error:" + ex.StackTrace);
                message = "Establised context error:" + ex.StackTrace;
            }

            Console.WriteLine(pContext.IsEstablished);

            try
            {
                pContext.Validate();
            }
            catch (PcscException ex)
            {
                Console.WriteLine($"0x{ex.NativeErrorCode:X8}: {ex.Message}");
                message = $"0x{ex.NativeErrorCode:X8}: {ex.Message}";
                return false;
            }
            return true;

        }

        private byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private bool GetUID(ref byte[] UID)
        {
            byte[] receivedUID = new byte[10];
            UnsafeNativeMethods.SCARD_IO_REQUEST request = new UnsafeNativeMethods.SCARD_IO_REQUEST();
            request.dwProtocol = 1; //SCARD_PROTOCOL_T1);
            request.cbPciLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(UnsafeNativeMethods.SCARD_IO_REQUEST));
            byte[] SELECT = new byte[] { 0x00, 0xA4, 0x04, 0x00, 0x08 };
            byte[] THAI_ID_CARD = new byte[] { 0xA0, 0x00, 0x00, 0x00, 0x54, 0x48, 0x00, 0x01 };
            byte[] m1 = Combine(SELECT, THAI_ID_CARD);
            //byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command for iClass cards
            byte[] sendBytes = m1;

            uint outBytes = (uint)receivedUID.Length;
            this._lastErrorCode = (SmartcardErrorCode)UnsafeNativeMethods.SCardTransmit(this._context, ref request, ref sendBytes[0], (uint)sendBytes.Length, ref request, out receivedUID[0], ref outBytes);

            UID = receivedUID;
            return (this._lastErrorCode == SmartcardErrorCode.None);
        }

        private DateTime Expire(string _issue_expire)
        {

            var year = Convert.ToInt32(_issue_expire.Substring(8, 4)) - 543;
            var month = Convert.ToInt32(_issue_expire.Substring(12, 2));
            var day = Convert.ToInt32(_issue_expire.Substring(14, 2));

            return new DateTime(year, month > 12 ? 12 : month, day > 31 ? 31 : day);

        }

        private string ExpireString(string _issue_expire)
        {
            return Expire(_issue_expire).ToString("dd/MM/yyyy");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PWaitChangeStatus(object sender, DoWorkEventArgs e)
        {
            SCardReaderStates prev1 = PcscDotNet.SCardReaderStates.Unknown;
            SCardReaderStates prev2 = PcscDotNet.SCardReaderStates.Unknown;
            string reader = "";
            int delay = 1000;
            while (!e.Cancel)
            {
                //try and catch error to log console
                try
                {
                    counter++;
                    if (counter > 6000)
                    {
                        counter = 0;
                    }
                    //Obtain a lock when we use the context pointer, 
                    //which may be modified in the Dispose() method.
                    lock (this)
                    {
                        if (!this.HasPContext)
                        {
                            return;
                        }
                        PcscReaderStatus p;
                        if (args == null || args.Length == 0)
                        {
                            args = new string[] { "ID", "R" };
                        }
                        try
                        {
                            p = pContext.GetStatus(_readers);

                        }
                        catch (Exception ex)
                        {
                            message = ex.Message;
                            pContext.Release();
                            this.PEstablishContext();
                            p = pContext.GetStatus(_readers);
                        }


                        PcscReaderState pcState;
#pragma warning disable CS0219 // Variable is assigned but its value is never used
                        int readerNo = 0;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
                        if (singleTypeFlag)
                        {
                            reader = _readers[0];
                            pcState = p[0];
                        }
                        else
                        {
                            reader = _readers[1];
                            pcState = p[1];
                        }
                        var a = pcState.State.GetTypeCode();
                        var b = pcState.State;

                        var current = pcState.State;
                        var atrs = pcState.Atr;


                        foreach (string ss in args)
                        {
                            if (ss.StartsWith("P,"))
                            {
                                string[] delayS = ss.Split(',');
                                if (delayS.Length == 2 && delayS[1].Length > 0)
                                {
                                    try
                                    {
                                        delay = int.Parse("" + float.Parse(delayS[1]) * 1000);
                                    }
                                    catch (Exception ex)
                                    {
                                        message = ex.Message;

                                        //parse error
                                    }
                                }
                            }
                        }

                        if (prev1 != current && pcState.State == (PcscDotNet.SCardReaderStates.Changed | PcscDotNet.SCardReaderStates.Empty))
                        {
                            prev1 = current;
                            prev2 = PcscDotNet.SCardReaderStates.Unknown;
                            Console.WriteLine("changed empty");
                            pContext.Cancel();

                        }
                        else

                    if (prev2 != current && pcState.State == (PcscDotNet.SCardReaderStates.Changed | PcscDotNet.SCardReaderStates.Present))
                        {
                            prev2 = current;
                            prev1 = PcscDotNet.SCardReaderStates.Unknown;
                            Console.WriteLine("changed present");

                            try
                            {
                                System.Threading.Thread.Sleep(delay);
                                pConnect = pContext.Connect(reader, SCardShare.Shared, SCardProtocols.Tx);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.StackTrace);
                                message = ex.Message;
                                pContext.Cancel();
                                pContext.Release();
                                pContext.Dispose();
                                this.PEstablishContext();
                                System.Threading.Thread.Sleep(delay);
                                pConnect = pContext.Connect(reader, SCardShare.Shared, SCardProtocols.Tx);

                            }

                            byte[] REQ = new byte[] { 0x00, 0xC0, 0x00, 0x00 };

                            if (atrs != null && atrs.Length >= 2 && atrs[0] == 0x3B && atrs[1] == 0x67)
                            {
                                //support very old id card
                                REQ = new byte[] { 0x00, 0xC0, 0x00, 0x01 };
                            }


                            byte[] SELECT = new byte[] { 0x00, 0xA4, 0x04, 0x00, 0x08 };
                            byte[] THAI_ID_CARD = new byte[] { 0xA0, 0x00, 0x00, 0x00, 0x54, 0x48, 0x00, 0x01 };
                            byte[] REQ_CID = new byte[] { 0x80, 0xb0, 0x00, 0x04, 0x02, 0x00, 0x0d };
                            byte[] REQ_THAI_NAME = new byte[] { 0x80, 0xb0, 0x00, 0x11, 0x02, 0x00, 0x64 };
                            byte[] REQ_ENG_NAME = new byte[] { 0x80, 0xb0, 0x00, 0x75, 0x02, 0x00, 0x64 };
                            byte[] REQ_ISSUE_EXPIRE = new byte[] { 0x80, 0xb0, 0x01, 0x67, 0x02, 0x00, 0x12 };

                            byte[] REQ_PERSONAL_INFO = new byte[] { 0x80, 0xb0, 0x00, 0x11, 0x02, 0x00, 0xd1 };
                            byte[] m1 = Combine(SELECT, THAI_ID_CARD);
                            //byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command for iClass cards
                            byte[] sendBytes = m1;


                            byte[] outBytes = pConnect.Transmit(sendBytes);
                            byte[] cidOut = pConnect.Transmit(REQ_CID);
                            byte[] cidOut2 = { cidOut[1] };
                            byte[] cid = pConnect.Transmit(Combine(REQ, cidOut2));
                            string s = string.Join(" ", cid.Select(b1 => Convert.ToChar(b1).ToString()));
                            s = s.Replace(" ", "");
                            s = s.Replace("\u0090", "");
                            s = s.Replace("\0", "");
                            string cidS = s;


                            byte[] ieOut = pConnect.Transmit(REQ_ISSUE_EXPIRE);
                            byte[] ieOut2 = { ieOut[1] };
                            byte[] ie = pConnect.Transmit(Combine(REQ, ieOut2));
                            s = string.Join(" ", ie.Select(b1 => Convert.ToChar(b1).ToString()));
                            s = s.Replace(" ", "");
                            s = s.Replace("\u0090", "");
                            s = s.Replace("\0", "");
                            string ieS = s;

                            string enameS = "";
                            string tnameS = "";
                            try
                            {
                                byte[] personOut = pConnect.Transmit(REQ_PERSONAL_INFO);
                                byte[] person2 = { personOut[1] };
                                byte[] person = pConnect.Transmit(Combine(REQ, person2));
                                s = string.Join("", person.Select(b1 => Convert.ToChar(b1).ToString()));
                                string[] eInfo = s.Substring(100, 100).Split('#');
                                //prefix + first name + last name
                                enameS = eInfo[0] + eInfo[1] + " " + eInfo[3];
                                enameS = enameS.Trim();
                                string[] tInfo = s.Substring(0, 100).Split('#');
                                //prefix + first name + last name
                                tnameS = tInfo[0] + " " + tInfo[1] + " " + tInfo[3];

                                tnameS = tnameS.Trim();
                            }
                            catch (Exception ex)
                            {
                                message = "old card capture:"+ex.Message;
                                System.Threading.Thread.Sleep(delay);
                                //if exception then try the old Eng name getting data
                                byte[] enameOut = pConnect.Transmit(REQ_ENG_NAME);
                                byte[] enameOut2 = { enameOut[1] };
                                byte[] ename = pConnect.Transmit(Combine(REQ, enameOut2));
                                s = string.Join("", ename.Select(b1 => Convert.ToChar(b1).ToString()));
                                s = s.Replace(" ", "");
                                s = s.Replace("#", " ");
                                s = s.Replace("\u0090", "");
                                s = s.Replace("\0", "");
                                enameS = s;


                                byte[] tnameOut = pConnect.Transmit(REQ_THAI_NAME);
                                byte[] tnameOut2 = { tnameOut[1] };
                                byte[] tname = pConnect.Transmit(Combine(REQ, tnameOut2));
                                s = string.Join("", tname.Select(b1 => Convert.ToChar(b1).ToString()));
                                s = s.Replace(" ", "");
                                s = s.Replace("#", " ");
                                s = s.Replace("\u0090", "");
                                s = s.Replace("\0", "");
                                tnameS = s;
                            }

                            /*
                            byte[] expOut = pConnect.Transmit(REQ_ISSUE_EXPIRE);
                            byte[] expOut2 = { expOut[1] };
                            byte[] exp = pConnect.Transmit(Combine(REQ, expOut2));
                            s = string.Join(" ", exp.Select(b1 => Convert.ToChar(b1).ToString()));
                            s = s.Replace(" ", "");
                            s = s.Replace("#", "");
                            s = s.Replace("\u0090", "");
                            s = s.Replace("\0", "");
                            */

                            InputSimulator sim = new InputSimulator();


                            foreach (string ss in args)
                            {
                                if (ss.Equals("ID"))
                                {
                                    sim.Keyboard.TextEntry(cidS);
                                }

                                if (ss.Equals("T"))
                                {
                                    sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                                }

                                if (ss.Equals("NAME"))
                                {
                                    sim.Keyboard.TextEntry(enameS);
                                }

                                if (ss.Equals("TNAME"))
                                {
                                    sim.Keyboard.TextEntry(tnameS);
                                }

                                if (ss.Equals("EXPIRE"))
                                {
                                    sim.Keyboard.TextEntry(ExpireString(ieS));
                                }

                                if (ss.Equals("R"))
                                {
                                    sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                                }

                                if (ss.Equals("S"))
                                {
                                    sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
                                }

                                if (ss.Equals("ST"))
                                {
                                    sim.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.SHIFT, WindowsInput.Native.VirtualKeyCode.TAB);
                                }
                            }
                            Console.WriteLine("ID=" + cidS.ToString());
                            message = cidS.ToString();
                            //sim.Keyboard.TextEntry(cidS);
                            //sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                            //sim.Keyboard.TextEntry(enameS);
                            //sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

                            pConnect.Disconnect();
                            pConnect.Dispose();
                            pConnect = null;
                            pContext.Cancel();

                        }
                    }
                }
                //main exception catch
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    message = "main errror:"+ex.Message;
                    try {
                        pContext.Cancel();
                        pContext.Release();
                        pContext.Dispose();
                        this.PEstablishContext();
                        System.Threading.Thread.Sleep(delay);
                        pConnect = pContext.Connect(reader, SCardShare.Shared, SCardProtocols.Tx);
                    }
                    catch (Exception ex2)
                    {
                        message = "final errror :" + ex2.Message;
                        System.Threading.Thread.Sleep(delay);
                    }
                    
                }
            }
        }

        private void WaitChangeStatus(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                SmartcardErrorCode result;

                //Obtain a lock when we use the context pointer, 
                //which may be modified in the Dispose() method.
                lock (this)
                {
                    if (!this.HasPContext)
                    {
                        return;
                    }

                    //This thread will be executed every 1000ms. 
                    //The thread also blocks for 1000ms, meaning 
                    //that the application may keep on running for 
                    //one extra second after the user has closed 
                    //the Main Form.
                    result =
                        (SmartcardErrorCode)UnsafeNativeMethods.GetStatusChange(
                        this._context, 1000, this._states, this._states.Length);
                }

                if ((result == SmartcardErrorCode.Timeout))
                {
                    // Time out has passed, but there is no new info. Just go on with the loop
                    continue;
                }

                for (int i = 0; i <= this._states.Length - 1; i++)
                {
                    //Check if the state changed from the last time.
                    if ((this._states[i].EventState & CardState.Changed) == CardState.Changed)
                    {
                        //Check what changed.
                        SmartcardState state = SmartcardState.None;
                        if ((this._states[i].EventState & CardState.Present) == CardState.Present
                            && (this._states[i].CurrentState & CardState.Present) != CardState.Present)
                        {
                            //The card was inserted.                            
                            state = SmartcardState.Inserted;
                        }
                        else if ((this._states[i].EventState & CardState.Empty) == CardState.Empty
                            && (this._states[i].CurrentState & CardState.Empty) != CardState.Empty)
                        {
                            //The card was ejected.
                            state = SmartcardState.Ejected;
                        }
                        if (state != SmartcardState.None && this._states[i].CurrentState != CardState.None)
                        {
                            switch (state)
                            {
                                case SmartcardState.Inserted:
                                    {
                                        //MessageBox.Show("Card inserted");
                                        byte[] data = new byte[100];
                                        bool resutl = GetUID(ref data);
                                        break;
                                    }
                                case SmartcardState.Ejected:
                                    {
                                        //MessageBox.Show("Card ejected");
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Some other state...");
                                        break;
                                    }
                            }
                        }
                        //Update the current state for the next time they are checked.
                        this._states[i].CurrentState = this._states[i].EventState;
                    }
                }
            }
        }

        private int GetReaderListBufferSize()
        {
            if ((this._context.IsInvalid))
            {
                return 0;
            }
            int result = 0;
            this._lastErrorCode =
                (SmartcardErrorCode)UnsafeNativeMethods.ListReaders(
                this._context, null, null, ref result);
            return result;
        }

        public ArrayList ListReaders()
        {
            ArrayList result = new ArrayList();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            if (this.EstablishContext())
            {
                //Ask for the size of the buffer first.
                int size = this.GetReaderListBufferSize();

                //Allocate a string of the proper size in which 
                //to store the list of smartcard readers.
                string readerList = new string('\0', size);
                //Retrieve the list of smartcard readers.
                this._lastErrorCode =
                    (SmartcardErrorCode)UnsafeNativeMethods.ListReaders(this._context,
                    null, readerList, ref size);
                if ((this._lastErrorCode == SmartcardErrorCode.None))
                {
                    //Extract each reader from the returned list.
                    //The readerList string will contain a multi-string of 
                    //the reader names, i.e. they are seperated by 0x00 
                    //characters.
                    string readerName = string.Empty;
                    for (int i = 0; i <= readerList.Length - 1; i++)
                    {
                        if ((readerList[i] == '\0'))
                        {
                            if ((readerName.Length > 0))
                            {
                                //We have a smartcard reader's name.
                                result.Add(readerName);
                                readerName = string.Empty;
                            }
                        }
                        else
                        {
                            //Append the found character.
                            readerName += new string(readerList[i], 1);
                        }
                    }
                }
            }
            return result;
        }

        public ArrayList PListReaders()
        {
            ArrayList result = new ArrayList();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            if (this.PEstablishContext())
            {

                //Retrieve the list of smartcard readers.
                IEnumerable<string> group = pContext.GetReaderGroupNames();
                foreach (var g in group)
                {
                    Console.WriteLine(g);
                }
                IEnumerable<string> data = pContext.GetReaderNames(SCardReaderGroup.NotSpecified);
                if (true)
                {

                    foreach (var reader in data)
                    {
                        result.Add(reader);
                    }
                }
            }
            return result;
        }

        #endregion

        #region IDisposable Support

        //IDisposable
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).            
                }

                //Free your own state (unmanaged objects).
                //Set large fields to null.
                this._states = null;
                if (this._worker != null)
                {
                    this._worker.CancelAsync();
                    this._worker.Dispose();
                }

                //this._context.Dispose();
                if (this.pConnect != null && this.pConnect.IsConnect) { this.pConnect.Dispose(); };
                this.pContext.Release();
            }
            this._disposed = true;
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Properties

        private bool HasContext
        {
            get { return (!this._context.IsInvalid); }
        }

        private bool HasPContext
        {
            get { return (this.pContext.IsEstablished); }
        }

        #endregion
    }
}
