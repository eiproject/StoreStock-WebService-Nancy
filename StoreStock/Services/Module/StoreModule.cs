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
    private const string MessageKey = "message";
    private const string ConfigInfoKey = "ci";
    private IStore _store; // lock store
    public StoreModule(IStore store) : base("/stores") {
      // Basic constrcutor start here
      /*      IStore store = TinyIoC.TinyIoCContainer.Current.Resolve<IStore>();*/
      _store = store;

      HTTPResponse response = new HTTPResponse();
      SerializableStoreStock storeData = new SerializableStoreStock(response);
      ModelStoreStock storeModel = new ModelStoreStock(storeData);
      IFactory factory = new Factory(_store);
      IRepository repository = new Repository(_store, factory);

      SerializableStock stockData = new SerializableStock(response);
      ModelStock stockModel = new ModelStock(stockData);

      // Basic constrcutor end here
      Get["/"] = parameters => {
        try {
          storeData.SetStoreName(_store.GetStoreName());
          storeData.SetStoreData(repository.ReadStoreStock());
          response.SetCode(200);
        }
        catch (Exception e) {
          Console.WriteLine(e);
          response.SetCode(500);
        }

        return Response.AsJson(storeModel.StoreStockData);
      };


    }
  }
}