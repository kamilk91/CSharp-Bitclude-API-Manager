﻿using BuyCheap.Methods;
using BuyCheap.Models;
using System;
using System.Threading;

namespace BuyCheap
{
    class Program
    {
        static void Main(string[] args)
        {
    
            BCRestClient bcClient = new BCRestClient("key", "id");
            
            
            NewTransactionResponseModel newTrans  = bcClient.PlaceOrder(new LimitTransactionModel
            {
                action = TransactionType.BUY,
                amount = "10",
                rate = "1",
                market1 = CryptoCurrency.BTC,
                market2 = FiatCurrency.PLN,
                
            });

            if(newTrans.success)
            {
                Console.WriteLine($"Offer {newTrans.code} placed with message {newTrans.message}");
        

                TransactionModel transactions = bcClient.GetActiveTransactions();
                foreach(Offer trans in transactions.offers)
                {

                    Console.WriteLine($"Canceling {trans.nr} {trans.price} {trans.offertype}");
                    bcClient.CancelOffer(trans);
                }
            }



        }
    }
}
