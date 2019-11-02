using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public class Offer
    {
        public string nr { get; set; }
        public string currency1 { get; set; }
        public string currency2 { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string id_user_open { get; set; }
        public string time_open { get; set; }
        public string offertype { get; set; }
    }

    public class TransactionModel
    {
        public bool success { get; set; }
        public IList<Offer> offers { get; set; }
    }

    public class Actions
    {
        public IList<object> sell { get; set; }
        public string order { get; set; }
    }

    public class CancelTransactionResponse
    {
        public bool success { get; set; }
        public string code { get; set; }
        public Actions actions { get; set; }
        public string message { get; set; }
    }
}
