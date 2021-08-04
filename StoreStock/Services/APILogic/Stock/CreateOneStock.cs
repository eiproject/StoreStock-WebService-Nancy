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
        RequestStock model = module.Bind<RequestStock>();
        _stock = _repository.CreateOneStockUsingState(model.Type, model.Amount, model.Title, model.Price, model.Category, model.SubCategory, model.Size);
        if (_stock == null) _statusCode = HttpStatusCode.BadRequest;
      }
      catch (Exception createError) {
        _message = createError.Message;
        _statusCode = HttpStatusCode.InternalServerError;
      }

      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
