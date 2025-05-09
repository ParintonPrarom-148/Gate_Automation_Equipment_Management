using PcscDotNet;
using System;
using System.Runtime.InteropServices;

namespace SmartcardLibrary
{
    internal enum ScopeOption
    {
        //User
        None = 0,
        Terminal = 1,
        System = 2
    }     

    internal sealed partial class UnsafeNativeMethods
    {
        public const string DllName = "WinSCard.dll";

        #region WinScard.DLL Imports
        [StructLayout(LayoutKind.Sequential)]
        public struct SCARD_IO_REQUEST
        {
            public UInt32 dwProtocol;
            public UInt32 cbPciLength;
        }

        [DllImport("WINSCARD.DLL", EntryPoint = "SCardTransmit", CharSet = CharSet.Unicode,
            SetLastError = true)]
        static internal extern uint SCardTransmit(
             SmartcardContextSafeHandle context,
             ref SCARD_IO_REQUEST pioSendRequest,
             ref byte SendBuff,
             UInt32 SendBuffLen,
             ref SCARD_IO_REQUEST pioRecvRequest,
             out byte RecvBuff,
             ref UInt32 RecvBuffLen
        );

        [DllImport(DllName, CharSet = CharSet.Unicode)]
        public unsafe static extern SCardError SCardConnect(SCardContext hContext, string szReader, SCardShare dwShareMode, SCardProtocols dwPreferredProtocols, SCardHandle* phCard, SCardProtocols* pdwActiveProtocol);


        [DllImport("WINSCARD.DLL", EntryPoint = "SCardEstablishContext", CharSet = CharSet.Unicode, 
             SetLastError = true)]
         static internal extern uint EstablishContext(ScopeOption scope, IntPtr reserved1, 
             IntPtr reserved2, ref SmartcardContextSafeHandle context);
        
         [DllImport("WINSCARD.DLL", EntryPoint = "SCardReleaseContext", CharSet = CharSet.Unicode, 
             SetLastError = true)]
         static internal extern uint ReleaseContext(IntPtr context);
        
         [DllImport("WINSCARD.DLL", EntryPoint = "SCardListReaders", CharSet = CharSet.Unicode, 
             SetLastError = true)]
         static internal extern uint ListReaders(SmartcardContextSafeHandle context, string groups, 
             string readers, ref int size);
        
         [DllImport("WINSCARD.DLL", EntryPoint = "SCardGetStatusChange", CharSet = CharSet.Unicode, 
             SetLastError = true)]
         static internal extern uint GetStatusChange([In(), Out()] SmartcardContextSafeHandle context,
             [In(), Out()] int timeout, [In(), Out()] ReaderState[] states, [In(), Out()] int count);
        
         #endregion
    }
}