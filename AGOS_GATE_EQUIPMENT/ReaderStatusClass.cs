using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGOS_GATE_EQUIPMENT
{
    internal class ReaderStatusClass
    {
        public string TerminalId { get; set; }
        public string GateLaneId { get; set; }
        public string ReaderFormat { get; set; }
        public string StatusDatetime { get; set; }

        public string ErrorStatus { get; set; }
    }
}
