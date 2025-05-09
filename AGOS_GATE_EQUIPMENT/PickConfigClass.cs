using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGOS_GATE_EQUIPMENT
{
    internal class PickConfigClass
    {
        public string TerminalId { get; set; }
        public string GateLaneId { get; set; }
        public string KioskAddress {  get; set; }
        public string InftLogAddress { get; set; }
        public string InftLogService { get; set; }
        public string FlieLogLocation { get; set; }
        public string FlieNameReader { get; set; }
        public string FlieNameBarrier { get; set; }
        public string FlieNameBarrierStatus { get; set; }
    }
}
