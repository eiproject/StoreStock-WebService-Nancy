using Nancy;
using Nancy.ModelBinding;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    internal Response UpdateStoreName(IResponseFormatter response, Request request, StoreModule module) {
      try {
        RequestStore model = module.Bind<RequestStore>();
        _store = _repository.UpdateStoreNameUsingState(model.Name);
        if (_store == null) ChangeStatusToNotFound("Store Not Found");
      }
      catch (Exception updateStoreNameError) {
        ChangeStatusToInternalServerError(updateStoreNameError.Message);
      }
      var responseObject = new { Data = _store, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
