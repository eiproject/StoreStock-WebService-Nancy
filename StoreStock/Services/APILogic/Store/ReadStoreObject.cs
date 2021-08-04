using Nancy;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    internal Response ReadStoreObject(IResponseFormatter response, Request request) {
      try {
        _store = _repository.ReadStoreObjectUsingState();
        if (_store == null) ChangeStatusToNotFound("Store Not Found");
      }
      catch (Exception readStoreError) {
        ChangeStatusToInternalServerError(readStoreError.Message);
      }
      var responseObject = new { Data = _store, StatusCode = _statusCode, Message = _message };
      return response.AsJson(responseObject, _statusCode);
    }
  }
}
