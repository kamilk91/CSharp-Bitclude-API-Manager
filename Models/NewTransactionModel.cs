using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public enum TransactionType { BUY, SELL }
    public enum FiatCurrency { USD, PLN }
    public enum CryptoCurrency { BTC, LTC}
    public class LimitTransactionModel
    {
        //public string method { get; set; }
        public TransactionType action { get; set; }
        public CryptoCurrency market1 { get; set; }
        public FiatCurrency market2 { get; set; }
        public string amount { get; set; }
        public string rate { get; set; }
        //public int id { get; set; }
        //public string key { get; set; }
    }
}
