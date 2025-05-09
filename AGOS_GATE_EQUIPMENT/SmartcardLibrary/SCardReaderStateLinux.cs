using System;

namespace PcscDotNet
{
    /// <summary>
    /// This structure is used by functions for tracking smart cards within readers.
    /// (For pcsc-lite in Linux.)
    /// </summary>
    public struct SCardReaderStateLinux
    {
        /// <summary>
        /// A pointer to the name of the reader being monitored.
        /// Set the value of this member to "\\\\?PnP?\\Notification" and the values of all other members to zero to be notified of the arrival of a new smart card reader.
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public unsafe void* Reader;
#pragma warning restore CS3003 // Type is not CLS-compliant

        /// <summary>
        /// Not used by the smart card subsystem.
        /// This member is used by the application.
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public unsafe void* UserData;
#pragma warning restore CS3003 // Type is not CLS-compliant

        /// <summary>
        /// Current state of the reader, as seen by the application, combination, as a bitmask. 
        /// </summary>
        public IntPtr CurrentState;

        /// <summary>
        /// Current state of the reader, as known by the smart card resource manager, combination, as a bitmask. 
        /// </summary>
        public IntPtr EventState;

        /// <summary>
        /// Number of bytes in the returned `ATR`.
        /// </summary>
        public IntPtr AtrLength;

        /// <summary>
        /// ATR of the inserted card.
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public unsafe fixed byte Atr[33];
#pragma warning restore CS3003 // Type is not CLS-compliant
    }
}
