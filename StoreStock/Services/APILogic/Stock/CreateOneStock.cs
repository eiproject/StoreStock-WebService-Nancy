using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response CreateOneStock(IResponseFormatter response, Request request, StockModule module) {
      try {
        dynamic model = module.Bind<RequestStock>();
        if (model != null && model.Type != null) {
          string type = model.Type;
          int amount = model.Amount;
          string title = model.Title;
          decimal price = model.Price;
          string category = model.Category;
          string subCategory = model.SubCategory;
          string size = model.Size;

          Stock newStock = _repository.CreateOneStockUsingState(
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
  }
}
