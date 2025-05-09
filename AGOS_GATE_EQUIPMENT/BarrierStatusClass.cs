using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGOS_GATE_EQUIPMENT
{
    internal class BarrierStatusClass
    {
        //public string BarrierStatusID { get; set; }
        public string TerminalId { get; set; } 

        public string GateLaneId { get; set; }

        public string BarrierStatus {  get; set; } 
        public string BarrierStatusDateTime {  get; set; }

        public string SensorStatus { get; set; }    

        public string SensorStatusDateTime { get; set; }
        public string ErrorStatus {  get; set; }
    }
}
