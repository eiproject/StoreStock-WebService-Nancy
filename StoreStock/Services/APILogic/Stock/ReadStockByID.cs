using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response ReadStockByID(IResponseFormatter response, Request request) {
      try {
        string strId = request.Query["id"];
        int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
        if (id == null) {
          _statusCode = HttpStatusCode.NotFound;
        }
        else {
          if (_repository.ReadStock((int)id) != null) {
            _stock = _repository.ReadStock((int)id);
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.NotFound;
          }
        }
      }
      catch (Exception readError) {
        Console.WriteLine(readError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }
  }
}
