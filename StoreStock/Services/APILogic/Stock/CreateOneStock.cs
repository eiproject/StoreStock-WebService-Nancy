using Nancy;
using Nancy.ModelBinding; 
using System;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response CreateOneStock(IResponseFormatter response, Request request, StockModule module) {
      try {
        dynamic model = module.Bind<RequestStock>();
        _stock = _repository.CreateOneStockUsingState(model.Type, model.Amount, model.Title, model.Price, model.Category, model.SubCategory, model.Size);
        if (_stock == null) ChangeStatusToBadRequest("Create Stock Bad Request");
      }
      catch (Exception createError) {
        ChangeStatusToInternalServerError(createError.Message);
      }

      var responseObject = new { Data = _stock, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
