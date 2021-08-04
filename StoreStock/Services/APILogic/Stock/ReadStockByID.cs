using Nancy;
using System;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response ReadStockById(IResponseFormatter response, Request request) {
      try {
        int? nullableId = ParseStringToNullableInteger(request.Query["id"]) ?? throw new NullReferenceException("Invalid ID");
        _stock = _repository.ReadOneStockByIdUsingState((int)nullableId);
        if (_stock == null) ChangeStatusToNotFound("Stock Not Found");
      }
      catch (Exception readError) {
        ChangeStatusToInternalServerError(readError.Message);
      }
      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
