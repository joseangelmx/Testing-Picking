using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.Confirm
{
    public class ConfirmRequest
    {
        [JsonProperty("camId")]
        public string CamId { get; set; }

        [JsonProperty("trakingId")]
        public int TrackingId { get; set; }

        [JsonProperty("divertCode")]
        public int DivertCode { get; set; }
    }
}
