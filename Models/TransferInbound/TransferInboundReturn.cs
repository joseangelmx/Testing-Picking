using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.TransferInbound
{
    public class TransferInboundReturn
    {
        [JsonProperty("divert_code")]
        public int DivertCode { get; set; }
    }
}
