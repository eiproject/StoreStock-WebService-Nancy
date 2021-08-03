using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    internal Response ReadStoreObject(IResponseFormatter response, Request request) {
      Store store = null;
      try {
        store = _repository.ReadStoreObjectUsingState();
        if (store != null) {
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.NotFound;
        }

      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
        store = null;
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return response.AsJson(store, _statusCode);
    }
  }
}
