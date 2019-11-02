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

        /// <summary>
        /// Get info about account. Returns model object of Getinfo method. 
        /// </summary>
        /// <returns>
        /// GetInfoModel
        /// </returns>
        public GetInfoModel GetInfo()
        {
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "account", "info");
            string resp = client.Execute(req).Content;
            GetInfoModel getinfo = JsonConvert.DeserializeObject<GetInfoModel>(resp);
            return getinfo;

        }


        public OrderBookModel OrderBook()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get orders which are on market.
        /// </summary>
        /// <returns></returns>

        public TransactionModel GetActiveTransactions()
        {
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
            IRestRequest req = new RestRequest();
            req = addMandatoryParameters(req, "account", "history");
            string resp = client.Execute(req).Content;
            return JsonConvert.DeserializeObject<GetHistoryModel>(resp);
        }


        public NewTransactionResponseModel PlaceOrder(LimitTransactionModel transaction)
        {
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
