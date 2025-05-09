using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGOS_GATE_EQUIPMENT
{
    internal class ReaderClass
    {
        public string ReadDateTime {  get; set; }
        public string TerminalId { get; set; }
        public string GateLaneId { get; set; }

        public string ReadInformation { get; set; }

        public string CitizenId { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorDesc { get; set; }
    }
}
