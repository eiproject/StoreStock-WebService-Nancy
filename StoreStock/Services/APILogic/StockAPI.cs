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
  public class StockAPI {
    private Store _store;
    private IFactory _factory;
    private IStockRepository _repository;
    private SerializableStock _stockData;
    private HttpStatusCode _statusCode;

    public StockAPI(
        Store store, IFactory factory, IStockRepository repository,
        SerializableStock stockData) {
      _store = store;
      _factory = factory;
      _repository = repository;
      _stockData = stockData;

      // _stockData.SetStock(null);
    }
    internal Response ReadStockByID(IResponseFormatter response,Request request) {
      try {
        string strId = request.Query["id"];
        int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
        if (id == null) {
          _statusCode = HttpStatusCode.NotFound;
        }
        else {
          if (_repository.ReadStock((int)id) != null) {
            _stockData.SetStock(_repository.ReadStock((int)id));
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

      return response.AsJson(_stockData, _statusCode);
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

        Stock newStock = _repository.CreateStock(
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
      return response.AsJson(_stockData, _statusCode);
    }

    internal Response UpdateStockAmount(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        int amount = request.Query["amount"];
        Stock stock = _repository.ReadStock(id);
        if (stock != null) {
          Stock stockToUpdate = _repository.UpdateStock_Amount(id, amount);
          if (stockToUpdate != null) {
            _stockData.SetStock(stockToUpdate);
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
      return response.AsJson(_stockData, _statusCode);
    }
    internal Response DeleteStockByID(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        bool res = _repository.DeleteStock(id);
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
      return response.AsJson(_stockData, _statusCode);
    }
  }
}
