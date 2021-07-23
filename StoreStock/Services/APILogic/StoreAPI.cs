using Nancy;
using Nancy.Helpers;
using Nancy.IO;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class StoreAPI {
    private Store _store;
    private IStoreRepository _repository;
    private HttpStatusCode _statusCode;
    public StoreAPI(Store store, IStoreRepository repository) {
      _store = store;
      _repository = repository;
    }
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
        Console.WriteLine(e);
        store = null;
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return response.AsJson(store, _statusCode);
    }
    internal Response UpdateStore(IResponseFormatter response, Request request, StoreModule module) {
      try {
        RequestStore model = module.Bind<RequestStore>();
        if (model.Name != null) {
          _store = _repository.UpdateStore(model.Name);
          if (_store != null) {
            _statusCode = HttpStatusCode.OK;
          }
          _statusCode = HttpStatusCode.NotFound;
        }
        else {
          _statusCode = HttpStatusCode.BadRequest;
          _store = null;
        }
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
        _store = null;
      }

      return response.AsJson(_store, _statusCode);
    }
  }
}
