using Nancy;
using Nancy.Helpers;
using Nancy.IO;
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
      try {
        _statusCode = HttpStatusCode.OK;
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return response.AsJson(_store, _statusCode);
    }
  }
}
