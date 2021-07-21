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
    internal Response UpdateStore(IResponseFormatter response, Request request) {
      try {
        _statusCode = HttpStatusCode.OK;

        RequestStream id = request.Body;
        long length = request.Body.Length;
        if (length != 0) {
          byte[] data = new byte[length];
          id.Read(data, 0, (int)length);
          string body = Encoding.Default.GetString(data);

          Dictionary<string, string> requestDict = body.Split('&')
        .Select(s => s.Split('='))
        .ToDictionary(k => k.ElementAt(0).ToLower(), v => HttpUtility.UrlDecode(v.ElementAt(1)));
          if (requestDict.ContainsKey("store-name")) {
            _repository.UpdateStore(requestDict["store-name"]);
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.BadRequest;
            _store = null;
          }
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
