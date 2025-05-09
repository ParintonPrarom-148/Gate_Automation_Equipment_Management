using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGOS_GATE_EQUIPMENT
{
    internal class BarrierLOG_Class
    {

        //public string BarrierLogId { get; set; }
        public string TerminalId { get; set; }
        public string GateLaneId { get; set; }
        public string CommandDatetime { get; set; }
        public string IpAddress { get; set; }
        public string CommandType { get; set; }
        public string ReturnedValue { get; set; }
        public string CommandStatus { get; set; }
        public string ErrorCode {  get; set; }
        public string ErrorDesc { get; set; }
    }
}
