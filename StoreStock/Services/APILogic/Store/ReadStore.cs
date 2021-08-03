using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    internal Response ReadStore(IResponseFormatter response, Request request) {
      Store store;
      try {
        store = _repository.ReadStore();
        if (store != null) {
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.NotFound;
        }

      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return response.AsJson(store, _statusCode);
    }
  }
}
