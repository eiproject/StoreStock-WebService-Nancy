using Nancy;
using Nancy.ModelBinding;
using System;

namespace StoreStockWeb.Services {
  public partial class StockAPI {

    internal Response UpdateStockAmountById(IResponseFormatter response, Request request, StockModule module) {
      try {
        dynamic model = module.Bind<RequestStockAmount>();
        int? nullableId = ParseStringToNullableInteger(model.Id) ?? throw new NullReferenceException("Invalid ID");
        _stock = _repository.UpdateStockAmountByIdUsingState((int)nullableId, model.Amount);
        if (_stock == null) ChangeStatusToNotFound("Stock Not Found");
      }
      catch (Exception updateError) {
        ChangeStatusToInternalServerError(updateError.Message);
      }
      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
