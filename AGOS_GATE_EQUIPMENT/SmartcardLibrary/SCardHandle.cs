namespace PcscDotNet
{
    /// <summary>
    /// A handle that identifies the connection to the smart card in the designated reader.
    /// </summary>
    public struct SCardHandle
    {
        /// <summary>
        /// Default value.
        /// </summary>
        public static readonly SCardHandle Default = default(SCardHandle);

        /// <summary>
        /// Returns true if `Value` is not null; otherwise, false.
        /// </summary>
        public unsafe bool HasValue => Value != null;

        /// <summary>
        /// Handle value.
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public unsafe void* Value;
#pragma warning restore CS3003 // Type is not CLS-compliant
    }
}
