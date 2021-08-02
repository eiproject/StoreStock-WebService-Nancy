using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

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
      catch (Exception readError) {
        Console.WriteLine(readError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }

    internal Response CreateStock(IResponseFormatter response, Request request, StockModule module) {
      try {
        RequestStock model = module.Bind<RequestStock>();
        if (model != null && model.Type != null) {
          string type = model.Type;
          int amount = model.Amount;
          string title = model.Title;
          decimal price = model.Price;
          string category = model.Category;
          string subCategory = model.SubCategory;
          string size = model.Size;

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
      catch (Exception createError) {
        Console.WriteLine(createError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }

    internal Response UpdateStockAmount(IResponseFormatter response, Request request, StockModule module) {
      try {
        RequestStockAmount model = module.Bind<RequestStockAmount>();
        // Parsing query
        string strId = model.Id;
        int? nullableId = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;

        if (nullableId != null || model.Amount != 0) {
          int id = (int)nullableId;
          int amount = model.Amount;
          Stock stockToUpdate = _repository.UpdateStockAmount(id, amount);
          if (stockToUpdate != null) {
            _stock = stockToUpdate;
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.NotFound;
          }
        }
        else {
          _statusCode = HttpStatusCode.BadRequest;
        }
      }
      catch (Exception updateError){
        Console.WriteLine(updateError.Message);
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
      catch (Exception deleteError) {
        Console.WriteLine(deleteError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }
  }
}
