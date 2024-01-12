using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_picking.Models.ToteHdr
{
    public class ToteHdrAdd
    {
        public string ToteLpn { get; set; }
        public string WaveNr { get; set; }
        public int WavePriority { get; set; }
        public int NrOfTotesInWave { get; set; }
        public int ToteTotalQty { get; set; }
        public string WCSDestinationArea { get; set; }
        public string Timestamp { get; set; }
        public int PutStationNr { get; set; }
        public int? Status { get; set; }
        public int? Release { get; set; }
        public int? Processed { get; set; }
    }
}
