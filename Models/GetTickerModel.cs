using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public class BtcPln
    {
        public string bind { get; set; }
        public string last { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string volumen { get; set; }
        public string max24H { get; set; }
        public string min24H { get; set; }
        public string change { get; set; }
    }

    public class LtcBtc
    {
        public string bind { get; set; }
        public string last { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string volumen { get; set; }
        public string max24H { get; set; }
        public string min24H { get; set; }
        public string change { get; set; }
    }

    public class GetTickerModel
    {
        public BtcPln btc_pln { get; set; }
        public LtcBtc ltc_btc { get; set; }
    }

}
