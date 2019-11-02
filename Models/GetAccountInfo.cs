using System;
using System.Collections.Generic;
using System.Text;

namespace BuyCheap.Models
{
    public class PersonalData
    {
        public string name { get; set; }
        public string surname { get; set; }
    }

    public class Fee
    {
        public string maker { get; set; }
        public string taker { get; set; }
    }

    public class Account
    {
        public string nick { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string key_default { get; set; }
        public string last_ip { get; set; }
        public string state { get; set; }
        public PersonalData data { get; set; }
        public Fee fee { get; set; }
    }

    public class USD
    {
        public string active { get; set; }
        public string inactive { get; set; }
    }

    public class BTC
    {
        public string active { get; set; }
        public string inactive { get; set; }
    }

    public class PLN
    {
        public string active { get; set; }
        public string inactive { get; set; }
    }

    public class Deposit
    {
        public bool BTC { get; set; }
        public bool PLN { get; set; }
        public bool BCH { get; set; }
        public bool LTC { get; set; }
    }

    public class Balances
    {
        public USD USD { get; set; }
        public BTC BTC { get; set; }
        public PLN PLN { get; set; }
        public Deposit deposit { get; set; }
        public bool has_address { get; set; }
        public string debit_fee { get; set; }
    }

    public class GetInfoModel
    {
        public bool success { get; set; }
        public Account account { get; set; }
        public Balances balances { get; set; }
    }


}
