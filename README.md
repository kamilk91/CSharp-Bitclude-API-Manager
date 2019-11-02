# Info

Bitclude.com market: [Bitclude.com](https://bitclude.com/r/554934414)

C# API connector to market bitclude, allows you placing, seeing, and managing offers.

Library is PLUGandPLAY. Just provice your data, and go!
## Requirements

* Newtonsoft.JSON
* RestSharp
* WebSocketSharp (optional)
## Methods

Methods are described in summary. 

This package is not unit tested.

## Example

```
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
```

