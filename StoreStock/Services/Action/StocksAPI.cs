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
  public class StocksAPI {
    IStore _store;
    SerializableStoreStock _storeData;
    ModelStoreStock _storeModel;
    IFactory _factory;
    IRepository _repository;
    SerializableStock _stockData;
    ModelStock _stockModel;
    HttpStatusCode _statusCode;

    public StocksAPI(
        IStore store, SerializableStoreStock storeData,
        ModelStoreStock storeModel, IFactory factory, IRepository repository,
        SerializableStock stockData, ModelStock stockModel) {
      _store = store;
      _storeData = storeData;
      _storeModel = storeModel;
      _factory = factory;
      _repository = repository;
      _stockData = stockData;
      _stockModel = stockModel;
    }
    internal Response ReadStockByID(IResponseFormatter response,Request request) {
      try {
        string strId = request.Query["id"];
        int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
        if (id == null) {
          _statusCode = HttpStatusCode.NotFound;
        }
        else {
          _storeData.SetStoreName(_store.GetStoreName());
          if (_repository.ReadStocksById((int)id).Count > 0) {
            _storeData.SetStoreData(_repository.ReadStocksById((int)id));
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.NotFound;
          }
        }
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return  response.AsJson(_storeModel.StoreStockData, _statusCode);
    }

    internal Response CreateStock(IResponseFormatter response, Request request) {
      try {
        RequestStream id = request.Body;
        long length = request.Body.Length;
        byte[] data = new byte[length];
        id.Read(data, 0, (int)length);
        string body = Encoding.Default.GetString(data);

        Dictionary<string, string> StringToArray = body.Split('&')
      .Select(s => s.Split('='))
      .ToDictionary(k => k.ElementAt(0), v => HttpUtility.UrlDecode(v.ElementAt(1)));

        string type = StringToArray["type"];
        int amount = int.Parse(StringToArray["amount"]);
        string title = StringToArray["title"];
        decimal price = decimal.Parse(StringToArray["price"]);
        string category = StringToArray["category"];
        string subCategory = StringToArray["sub-category"];
        string size = StringToArray["size"];

        IStock newStock = _repository.CreateStoreStock(
          type, amount, title, price, category, subCategory, size
          );
        if (newStock != null) {
          _stockData.SetStock(newStock);
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.Conflict;
        }
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stockModel.SerializedStock, _statusCode);
    }

    internal Response UpdateStockAmount(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        int amount = request.Query["amount"];
        List<IStock> listStock = _repository.ReadStocksById(id);
        if (listStock.Count > 0) {
          IStock stock = _repository.UpdateStockAmount(id, amount);
          if (stock != null) {
            _stockData.SetStock(stock);
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.Conflict;
          }
        }
        else { // Not Found
          _statusCode = HttpStatusCode.NotFound;
        }
      }
      catch {
        _statusCode = HttpStatusCode.InternalServerError;
      }
      // save information
      return response.AsJson(_stockModel.SerializedStock, _statusCode);
    }
    internal Response DeleteStockByID(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        bool res = _repository.DeleteStoreStock(id);
        if (res) {
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.NotFound;
        }
      }
      catch {
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stockModel.SerializedStock, _statusCode);
    }
  }
}
