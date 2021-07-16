using Nancy;
using Nancy.ModelBinding;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using StoreStock.BusinessLogic;
using System.Text;

namespace StoreStockWeb.Services {
  public class StoreStockModule : NancyModule {
    private const string MessageKey = "message";
    private const string ConfigInfoKey = "ci";
    IStore _store; // just init, edit this to works
    public StoreStockModule()
      : base("/store-stock") {
      // Basic command start here
      SerializableStoreStock storeData = new SerializableStoreStock();
      ModelStoreStock storeModel = new ModelStoreStock(storeData);
      IRepository repository = new Repository(_store);


      SerializableStock stockData = new SerializableStock();
      ModelStock stockModel = new ModelStock(stockData);
      // init command end here
      Get["/view"] = parameters => {
        return View["StockViewerIndex.html", storeModel];
      };

      Get["/"] = parameters => {
        try {
          string strId = this.Request.Query["id"];
          int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
          if (id == null) {
            storeData.SetStoreName(_store.GetStoreName());
            storeData.SetStoreData(repository.ReadStoreStock());
            storeData.SetCode(200);
            storeData.SetMessage("Success");
          }
          else {
            storeData.SetStoreName(_store.GetStoreName());
            storeData.SetStoreData(repository.ReadStocksById((int)id));
            storeData.SetCode(200);
            storeData.SetMessage("Success");
          }
        }
        catch {
          storeData.SetStoreName(_store.GetStoreName());
          storeData.SetCode(200);
          storeData.SetMessage("error");
        }
        return Response.AsJson(storeModel.StoreStockData);
      };

      Post["/"] = parameters => {
        string type = this.Request.Query["type"];
        int amount = this.Request.Query["amount"];
        string title = this.Request.Query["title"];
        decimal price = this.Request.Query["price"];
        string category = this.Request.Query["category"];
        string subCategory = this.Request.Query["sub-cateegory"];
        string size = this.Request.Query["size"];
        try {
          IStock newStock = repository.CreateStoreStock(
            type, amount, title, price, category, subCategory, size
            );
          stockData.SetStock(newStock);
          stockData.SetMessage("success");
        }
        catch {
          stockData.SetMessage("error");
        }
        return Response.AsJson(stockModel.SerializedStock);
      };

      Patch["/"] = parameters => {
        var config = this.Bind<ConfigInfo>();
        // Parsing query
        string type = this.Request.Query["id"];
        int amount = this.Request.Query["amount"]; ;

        // save information
        return Response.AsRedirect("/config");
      };
    }
  }

  public class ModelStoreStock {
    private SerializableStoreStock _storeStockData;
    public SerializableStoreStock StoreStockData { get { return _storeStockData; } }
    internal ModelStoreStock(SerializableStoreStock serializedStoreStock) {
      _storeStockData = serializedStoreStock;
    }
  }
  public class ModelStock {
    private SerializableStock _serializedStock;
    public SerializableStock SerializedStock { get { return _serializedStock; } }
    internal ModelStock(SerializableStock serializedStock) {
      _serializedStock = serializedStock;
    }
  }
}


