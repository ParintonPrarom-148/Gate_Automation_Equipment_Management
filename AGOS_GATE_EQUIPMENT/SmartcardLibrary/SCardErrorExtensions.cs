using System;
using System.Windows.Forms;

namespace PcscDotNet
{
    /// <summary>
    /// Extension methods for SCardError.
    /// </summary>
    public static class SCardErrorExtensions
    {
        public static void Throw(this SCardError error, PcscExceptionHandler onException = null)
        {
            var exception = new PcscException(error);
            if (onException != null)
            {
                onException(exception);

                if (!exception.ThrowIt) return;
            }

            try
            {
                // ทำสิ่งที่ต้องการที่อาจเกิดข้อผิดพลาดที่นี่
                // หากมีการทำงานที่อาจเกิดข้อผิดพลาด ควรจะอยู่ใน try block
            }
            catch (PcscException ex)
            {
                // แสดง MessageBox เมื่อเกิดข้อผิดพลาด
                MessageBox.Show("ErrorXXX: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // คุณสามารถจัดการกับ exception ที่นี่เพิ่มเติมได้
            }
        }

        /*
        public static void Throw(this SCardError error, PcscExceptionHandler onException = null)
        {
            var exception = new PcscException(error);
            if (onException != null)
            {
                    onException(exception);

                if (!exception.ThrowIt) return;
            }
                throw exception;
        }
        */

        public static void ThrowIfNotSuccess(this SCardError error, PcscExceptionHandler onException = null)
        {
            if (error != SCardError.Successs)
            {
                Throw(error, onException);
            }
        }
    }
}
