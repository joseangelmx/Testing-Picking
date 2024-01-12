using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.TransferInbound
{
    public class TransferRequest
    {
        public string CamId { get; set; }
        public string ToteLPN { get; set; }
        public int TrackingId { get; set; }
        public int ScannerNLaneWStatus { get; set; }
        public int ScannerNLaneWFull { get; set; }
    }
}
