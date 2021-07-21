using Nancy;
using Nancy.Helpers;
using Nancy.IO;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class StockModule : NancyModule {
    private IStore _store; // lock store
    public StockModule(StocksAPI stockAPI) : base("/stocks") {
      /*      _store = store;
            HTTPResponse response = new HTTPResponse();
            SerializableStoreStock storeData = new SerializableStoreStock(response);
            ModelStoreStock storeModel = new ModelStoreStock(storeData);
            IFactory factory = new Factory(_store);
            IRepository repository = new Repository(_store, factory);

            SerializableStock stockData = new SerializableStock(response);
            ModelStock stockModel = new ModelStock(stockData);*/

      // Get["/"] = _ => Response.AsJson(stockAPI.ReadStockByID(this.Request));
      Get["/"] = _ => stockAPI.ReadStockByID(Response, Request);

      Post["/"] = _ => Response.AsJson(stockAPI.CreateStock(this.Request));

      Put["/"] = _ => Response.AsJson(stockAPI.UpdateStockAmount(this.Request));

      Delete["/"] = _ => Response.AsJson(stockAPI.DeleteStockByID(this.Request));
    }
  }
}
