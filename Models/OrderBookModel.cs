using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public class Data
    {
        public string market1 { get; set; }
        public string market2 { get; set; }
        public int timestamp { get; set; }
    }

    public class OrderBookModel
    {
        public Data data { get; set; }
        public IList<IList<string>> bids { get; set; }
        public IList<IList<string>> asks { get; set; }
    }
}
