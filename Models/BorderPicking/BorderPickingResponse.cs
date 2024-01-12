using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.BorderPicking
{
    public class BorderPickingResponse
    {
        [JsonProperty("divert_code")]
        public int DivertCode { get; set; }

        [JsonProperty("tracking_id")]
        public int TrackingId { get; set; }
    }
}
