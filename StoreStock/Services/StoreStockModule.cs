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
    private IStore _store; // just init, edit this to works
    public StoreStockModule()
      : base("/store-stock") {
      // Basic constrcutor start here
      IStore store = TinyIoC.TinyIoCContainer.Current.Resolve<IStore>();
      _store = store;

      HTTPResponse response = new HTTPResponse();
      SerializableStoreStock storeData = new SerializableStoreStock(response);
      ModelStoreStock storeModel = new ModelStoreStock(storeData);
      IFactory factory = new Factory(_store);
      IRepository repository = new Repository(_store, factory);

      SerializableStock stockData = new SerializableStock(response);
      ModelStock stockModel = new ModelStock(stockData);

      // Basic constrcutor end here
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
            response.SetCode(200);
          }
          else {
            storeData.SetStoreName(_store.GetStoreName());
            if (repository.ReadStocksById((int)id).Count > 0) {
              storeData.SetStoreData(repository.ReadStocksById((int)id));
              response.SetCode(200);
            }
            else {
              response.SetCode(404);
            }
          }
        }
        catch (Exception e) {
          Console.WriteLine(e);
          response.SetCode(500);
        }

        return Response.AsJson(storeModel.StoreStockData);
      };

      Post["/"] = parameters => {
        try {
          string type = this.Request.Query["type"];
          int amount = this.Request.Query["amount"];
          string title = this.Request.Query["title"];
          decimal price = this.Request.Query["price"];
          string category = this.Request.Query["category"];
          string subCategory = this.Request.Query["sub-cateegory"];
          string size = this.Request.Query["size"];

          IStock newStock = repository.CreateStoreStock(
            type, amount, title, price, category, subCategory, size
            );
          if (newStock != null) {
            stockData.SetStock(newStock);
            response.SetCode(201);
          }
          else {
            response.SetCode(409);
          }
        }
        catch {
          response.SetCode(500);
        }
        return Response.AsJson(stockModel.SerializedStock);
      };

      Patch["/"] = parameters => {
        try {
          // Parsing query
          int id = this.Request.Query["id"];
          int amount = this.Request.Query["amount"];
          List<IStock> listStock = repository.ReadStocksById(id);
          if (listStock.Count > 0) {
            IStock stock = repository.UpdateStoreStock(id, amount);
            if (stock != null) {
              stockData.SetStock(stock);
              response.SetCode(200);
            }
            else {
              response.SetCode(409);
            }
          }
          else { // Not Found
            response.SetCode(404);
          }
        }
        catch {
          response.SetCode(500);
        }
        // save information
        return Response.AsJson(stockModel.SerializedStock);
      };

      Delete["/"] = parameters => {
        /*        try {*/
        // Parsing query
        int id = this.Request.Query["id"];
        repository.DeleteStoreStock(id);
        List<IStock> listStock = repository.ReadStocksById(id);
        if (listStock.Count == 0) {
          response.SetCode(200);
        }
        else {
          response.SetCode(409);
        }
        /*}
        catch {
          response.SetCode(500);
        }*/
        return Response.AsJson(stockModel.SerializedStock);
      };
    }
  }
}