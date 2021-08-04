using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response DeleteStockById(IResponseFormatter response, Request request) {
      try {
        int? nullableId = ParseStringToNullableInteger(request.Query["id"]) ?? throw new NullReferenceException("Invalid ID");
        _stock = _repository.DeleteOneStockByIdUsingState((int)nullableId);
        if (_stock == null) _statusCode = HttpStatusCode.NotFound;
      }
      catch (Exception deleteError) {
        _message = deleteError.Message;
        _statusCode = HttpStatusCode.InternalServerError;
      }
      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
