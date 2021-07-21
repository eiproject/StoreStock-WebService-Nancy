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
    private Stock _stock = null;
    private Store _store;
    private IFactory _factory;
    private IStockRepository _repository;
    private HttpStatusCode _statusCode;

    public StockAPI(
        Store store, IFactory factory, IStockRepository repository) {
      _store = store;
      _factory = factory;
      _repository = repository;
    }
    internal Response ReadStockByID(IResponseFormatter response, Request request) {
      try {
        string strId = request.Query["id"];
        int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
        if (id == null) {
          _statusCode = HttpStatusCode.NotFound;
        }
        else {
          if (_repository.ReadStock((int)id) != null) {
            _stock = _repository.ReadStock((int)id);
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
      return response.AsJson(_stock, _statusCode);
    }

    internal Response CreateStock(IResponseFormatter response, Request request) {
      try {
        RequestStream id = request.Body;
        long length = request.Body.Length;
        byte[] data = new byte[length];
        id.Read(data, 0, (int)length);
        string body = Encoding.Default.GetString(data);

        Dictionary<string, string> requestDict = body.Split('&')
      .Select(s => s.Split('='))
      .ToDictionary(k => k.ElementAt(0).ToLower(), v => HttpUtility.UrlDecode(v.ElementAt(1)));

        if (requestDict.ContainsKey("type") && 
          requestDict.ContainsKey("amount") &&
          requestDict.ContainsKey("title") &&
          requestDict.ContainsKey("price") &&
          requestDict.ContainsKey("category") &&
          requestDict.ContainsKey("sub-category") &&
          requestDict.ContainsKey("size")) {
          string type = requestDict["type"];
          int amount = int.Parse(requestDict["amount"]);
          string title = requestDict["title"];
          decimal price = decimal.Parse(requestDict["price"]);
          string category = requestDict["category"];
          string subCategory = requestDict["sub-category"];
          string size = requestDict["size"];

          Stock newStock = _repository.CreateStock(
            type, amount, title, price, category, subCategory, size
            );
          if (newStock != null) {
            _stock = newStock;
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.BadRequest;
          }
        }
        else {
          _statusCode = HttpStatusCode.BadRequest;
        }
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }

    internal Response UpdateStockAmount(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        string strId = request.Query["id"];
        int? nullableId = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;

        if (nullableId == null) {
          _statusCode = HttpStatusCode.BadRequest;
        }
        else {
          int id = (int)nullableId;
          int amount = request.Query["amount"];
          Stock stock = _repository.ReadStock(id);
          if (stock != null) {
            Stock stockToUpdate = _repository.UpdateStock_Amount(id, amount);
            if (stockToUpdate != null) {
              _stock = stockToUpdate;
              _statusCode = HttpStatusCode.OK;
            }
            else {
              _statusCode = HttpStatusCode.BadRequest;
            }
          }
          else { // Not Found
            _statusCode = HttpStatusCode.NotFound;
          }
        }

      }
      catch {
        _statusCode = HttpStatusCode.InternalServerError;
      }
      // save information
      return response.AsJson(_stock, _statusCode);
    }
    internal Response DeleteStockByID(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        Stock stock = _repository.DeleteStock(id);
        if (stock != null) {
          _stock = stock;
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.NotFound;
        }
      }
      catch {
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }
  }
}
