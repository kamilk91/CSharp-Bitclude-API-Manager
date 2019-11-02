using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public class History
    {
        public string currency1 { get; set; }
        public string currency2 { get; set; }
        public string amount { get; set; }
        public long time_close { get; set; }
        public string price { get; set; }
        public string fee_taker { get; set; }
        public string fee_maker { get; set; }
        public string type { get; set; }
        public string action { get; set; }
    }

    public class GetHistoryModel
    {
        public bool success { get; set; }
        public IList<History> history { get; set; }
    }
}
