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
        storeData.SetStoreName(_store.GetStoreName());
        storeData.SetStoreData(repository.ReadStoreStock());

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
          RequestStream id = this.Request.Body;
          long length = this.Request.Body.Length;
          byte[] data = new byte[length];
          id.Read(data, 0, (int)length);
          string body = Encoding.Default.GetString(data);

          Dictionary<string , string> StringToArray = body.Split('&')
        .Select(s => s.Split('='))
        .ToDictionary(k => k.ElementAt(0), v => HttpUtility.UrlDecode(v.ElementAt(1)));

          string type = StringToArray["type"];
          int amount = int.Parse(StringToArray["amount"]);
          string title = StringToArray["title"];
          decimal price = decimal.Parse(StringToArray["price"]);
          string category = StringToArray["category"];
          string subCategory = StringToArray["sub-category"];
          string size = StringToArray["size"];

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
        catch (Exception e) {
          Console.WriteLine(e);
          response.SetCode(500);
        }
        return Response.AsJson(stockModel.SerializedStock);
      };

      Put["/"] = parameters => {
        try {
          // Parsing query
          int id = this.Request.Query["id"];
          int amount = this.Request.Query["amount"];
          List<IStock> listStock = repository.ReadStocksById(id);
          if (listStock.Count > 0) {
            IStock stock = repository.UpdateStockAmount(id, amount);
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
        try {
          // Parsing query
          int id = this.Request.Query["id"];
          bool res = repository.DeleteStoreStock(id);
          if (res) {
            response.SetCode(200);
          }
          else {
            response.SetCode(404);
          }
        }
        catch {
          response.SetCode(500);
        }
        return Response.AsJson(stockModel.SerializedStock);
      };
    }
  }
}