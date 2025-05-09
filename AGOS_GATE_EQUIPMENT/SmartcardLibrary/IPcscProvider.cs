namespace PcscDotNet
{
    public interface IPcscProvider
    {
        byte[] AllocateIORequest(int informationLength);

        byte[] AllocateReaderStates(int count);

#pragma warning disable CS3002 // Return type is not CLS-compliant
        unsafe void* AllocateString(string value);
#pragma warning restore CS3002 // Return type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe string AllocateString(void* ptr, int length);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void FreeString(void* ptr);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void ReadIORequest(void* pIORequest, out SCardProtocols protocol, out byte[] information);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void ReadReaderState(void* pReaderStates, int index, out void* pReaderName, out SCardReaderStates currentState, out SCardReaderStates eventState, out byte[] atr);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        SCardError SCardBeginTransaction(SCardHandle hCard);

        SCardError SCardCancel(SCardContext hContext);

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardConnect(SCardContext hContext, string szReader, SCardShare dwShareMode, SCardProtocols dwPreferredProtocols, SCardHandle* phCard, SCardProtocols* pdwActiveProtocol);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardControl(SCardHandle hCard, int dwControlCode, void* lpInBuffer, int nInBufferSize, void* lpOutBuffer, int nOutBufferSize, int* lpBytesReturned);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        int SCardCtlCode(SCardControlFunction function);

        SCardError SCardDisconnect(SCardHandle hCard, SCardDisposition dwDisposition);

        SCardError SCardEndTransaction(SCardHandle hCard, SCardDisposition dwDisposition);

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardEstablishContext(SCardScope dwScope, void* pvReserved1, void* pvReserved2, SCardContext* phContext);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardFreeMemory(SCardContext hContext, void* pvMem);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardGetStatusChange(SCardContext hContext, int dwTimeout, void* rgReaderStates, int cReaders);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        SCardError SCardIsValidContext(SCardContext hContext);

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardListReaderGroups(SCardContext hContext, void* mszGroups, int* pcchGroups);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardListReaders(SCardContext hContext, string mszGroups, void* mszReaders, int* pcchReaders);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardReconnect(SCardHandle hCard, SCardShare dwShareMode, SCardProtocols dwPreferredProtocols, SCardDisposition dwInitialization, SCardProtocols* pdwActiveProtocol);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

        SCardError SCardReleaseContext(SCardContext hContext);

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe SCardError SCardTransmit(SCardHandle hCard, void* pioSendPci, byte* pbSendBuffer, int cbSendLength, void* pioRecvPci, byte* pbRecvBuffer, int* pcbRecvLength);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void WriteIORequest(void* pIORequest, SCardProtocols protocol, int totalLength, byte[] information);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void WriteReaderState(void* pReaderStates, int index, SCardReaderStates currentState);
#pragma warning restore CS3001 // Argument type is not CLS-compliant

#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3001 // Argument type is not CLS-compliant
        unsafe void WriteReaderState(void* pReaderStates, int index, void* pReaderName);
#pragma warning restore CS3001 // Argument type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
    }
}
