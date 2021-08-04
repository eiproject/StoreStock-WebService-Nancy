using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {

    internal Response UpdateStockAmountById(IResponseFormatter response, Request request, StockModule module) {
      try {
        RequestStockAmount model = module.Bind<RequestStockAmount>();
        int? nullableId = ParseStringToNullableInteger(model.Id) ?? throw new NullReferenceException("Invalid ID");
        _stock = _repository.UpdateStockAmountByIdUsingState((int)nullableId, model.Amount);
        if (_stock == null) _statusCode = HttpStatusCode.NotFound;
      }
      catch (Exception updateError) {
        _message = updateError.Message;
        _statusCode = HttpStatusCode.InternalServerError;
      }
      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
