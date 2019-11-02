using BuyCheap.Methods;
using BuyCheap.Models;
using System;
using System.Threading;

namespace BuyCheap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BCRestClient bcClient = new BCRestClient("a1bf9170e49bf603d4faf500c768908927ad2e3254e6e6a3cd7dfeeace2b01a5", "554934414");
            
            
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
                    Thread.Sleep(1000);
                    bcClient.CancelOffer(trans);
                }
            }



        }
    }
}
