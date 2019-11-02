using BuyCheap.Methods;
using BuyCheap.Models;
using System;
using System.Collections;
using System.Threading;

namespace BuyCheap
{
    class Program
    {
        static void Main(string[] args)
        {

            BCRestClient bcClient = new BCRestClient();
            bcClient.CancelOffer(new Offer());


            OrderBookModel ob = bcClient.OrderBook(CryptoCurrency.BTC, FiatCurrency.PLN);
            Console.WriteLine($"Asks:");

            foreach (IList ask in ob.asks)
            {

                Console.WriteLine($"  {ask[0]} | {ask[1]}");
            }

            Console.WriteLine("Bids:");
            foreach (IList bid in ob.bids)
            {
                Console.WriteLine($"  {bid[0]} | {bid[1]}");
            }

            Console.ReadLine();
        }
    }
}
