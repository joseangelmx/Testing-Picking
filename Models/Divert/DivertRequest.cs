using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.Divert
{
    public class DivertRequest
    {
            [JsonProperty("camId")]
            public string CamId { get; set; }

            [JsonProperty("trakingId")]
            public int TrackingId { get; set; }

            [JsonProperty("toteLpn")]
            public string ToteLpn { get; set; }

            [JsonProperty("scannerNLaneWStatus")]
            public int ScannerNLaneWStatus { get; set; }

            [JsonProperty("scannerNLaneWFull")]
            public int ScannerNLaneWFull { get; set; }
    }
}
