using BuyCheap.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace BuyCheap.Methods
{
    class BCRestClient
    {

        private string key { get; set; }
        private string secret { get; set; }

        RestClient client;

        /// <summary>
        /// Returns instance of client to use with Bitclude market. 
        /// </summary>
        /// <param name="key">
        /// Key value generated on market
        /// </param>
        /// <param name="secret">
        /// ID you can get in Settings.
        /// </param>
        public BCRestClient(string key, string secret)
        {
            this.key = key;
            this.secret = secret;
            this.client = new RestClient("https://api.bitclude.com/");
        }

        public BCRestClient()
        {
            this.client = new RestClient("https://api.bitclude.com/");
        }

        /// <summary>
        /// Get orderbook for specify markets.
        /// </summary>
        /// <param name="crypto"></param>
        /// <param name="fiat"></param>
        /// <returns></returns>
        public OrderBookModel OrderBook(CryptoCurrency crypto, FiatCurrency fiat)
        {
            IRestRequest req = new RestRequest($"/stats/orderbook_{crypto.ToString().ToLower()}{fiat.ToString().ToLower()}.json");
            string response = client.Execute(req).Content;
            OrderBookModel orderbook = JsonConvert.DeserializeObject<OrderBookModel>(response);
            return orderbook;
        }
        /// <summary>
        /// Get info about account. Returns model object of Getinfo method. 
        /// </summary>
        /// <returns>
        /// GetInfoModel
        /// </returns>
        public GetInfoModel GetInfo()
        {
            if (key == null || secret == null)
                throw new ArgumentException("This method need key and secret (key and id)");
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "account", "info");
            string resp = client.Execute(req).Content;
            GetInfoModel getinfo = JsonConvert.DeserializeObject<GetInfoModel>(resp);
            return getinfo;

        }




        /// <summary>
        /// Get orders which are on market.
        /// </summary>
        /// <returns></returns>

        public TransactionModel GetActiveTransactions()
        {
            if (key == null || secret == null)
                throw new ArgumentException("This method need key and secret (key and id)");
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "account", "activeoffers");
            string response = client.Execute(req).Content;
            TransactionModel transaction = JsonConvert.DeserializeObject<TransactionModel>(response);
            return transaction;
        }

        /// <summary>
        /// Cancel opened transaction, mandatory fields are order and typ
        /// </summary>
        /// <param name="transaction">
        /// Offer type transaction, from Models namespace.
        /// </param>
        /// <returns></returns>
        public CancelTransactionResponse CancelOffer(Offer transaction)
        {
            if (key == null || secret == null)
                throw new ArgumentException("This method need key and secret (key and id)");
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "transactions", "cancel");
            req.AddParameter("order", transaction.nr);
            req.AddParameter("typ", transaction.offertype);
            string response = client.Execute(req).Content;
            CancelTransactionResponse resp = JsonConvert.DeserializeObject<CancelTransactionResponse>(response);
            return resp;
        }

        /// <summary>
        /// Get History of account. Returns model object of GetHistory method. 
        /// </summary>
        /// <returns></returns>
        public GetHistoryModel GetHistory()
        {
            if (key == null || secret == null)
                throw new ArgumentException("This method need key and secret (key and id)");
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "account", "history");
            string resp = client.Execute(req).Content;
            return JsonConvert.DeserializeObject<GetHistoryModel>(resp);
        }


        /// <summary>
        /// Place new transaction on specify market. Use new LimitTransactionModel to create new transaction object.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>

        public NewTransactionResponseModel PlaceOrder(LimitTransactionModel transaction)
        {
            if (key == null || secret == null)
                throw new ArgumentException("This method need key and secret (key and id)");
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "transactions", transaction.action);
            req.AddParameter("market1", transaction.market1);
            req.AddParameter("market2", transaction.market2);
            req.AddParameter("amount", transaction.amount);
            req.AddParameter("rate", transaction.rate);
            string responsestring = client.Execute(req).Content;
            NewTransactionResponseModel response = JsonConvert.DeserializeObject<NewTransactionResponseModel>(responsestring);
            return response;

        }



        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                             //
        ///                                  HELPERS                                                    //
        ///                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////



        private IRestRequest addMandatoryParameters(IRestRequest req, string method, object action)
        {
            req.AddParameter("id", this.secret);
            req.AddParameter("key", this.key);
            req.AddParameter("method", method);
            req.AddParameter("action", action);

            return req;
        }


    }


    
}
