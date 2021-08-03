using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    internal Response UpdateStore(IResponseFormatter response, Request request, StoreModule module) {
      try {
        RequestStore model = module.Bind<RequestStore>();
        if (model.Name != null) {
          _store = _repository.UpdateStoreNameUsingState(model.Name);
          if (_store != null) {
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.NotFound;
          }
        }
        else {
          _statusCode = HttpStatusCode.BadRequest;
          _store = null;
        }
      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_store, _statusCode);
    }
  }
}
