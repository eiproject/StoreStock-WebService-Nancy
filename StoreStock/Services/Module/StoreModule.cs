using Nancy;
using Nancy.ModelBinding;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using StoreStock.BusinessLogic;
using System.Text;
using System.Linq;
using Nancy.Helpers;
using Nancy.IO;

namespace StoreStockWeb.Services {
  public class StoreModule : NancyModule {
    private IStore _store; // lock store
    public StoreModule(IStore store) : base("/stores") {
      _store = store;

      SerializableStoreStock storeData = new SerializableStoreStock();
      ModelStoreStock storeModel = new ModelStoreStock(storeData);
      IFactory factory = new Factory(_store);
      IStoreRepository repository = new StoreRepository(_store, factory);

      SerializableStock stockData = new SerializableStock();
      ModelStock stockModel = new ModelStock(stockData);

      // Basic constrcutor end here
      Get["/"] = parameters => {
        HttpStatusCode _statusCode;
        try {
          storeData.SetStoreName(_store.GetStoreName());
          storeData.SetStoreData(repository.ReadStoreStock());
          _statusCode = HttpStatusCode.OK;
        }
        catch (Exception e) {
          Console.WriteLine(e);
          _statusCode = HttpStatusCode.InternalServerError;
        }

        return Response.AsJson(storeModel.StoreStockData);
      };
    }
  }
}