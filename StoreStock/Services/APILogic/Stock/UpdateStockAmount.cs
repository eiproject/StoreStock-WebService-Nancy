using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response UpdateStockAmount(IResponseFormatter response, Request request, StockModule module) {
      try {
        RequestStockAmount model = module.Bind<RequestStockAmount>();
        // Parsing query
        string strId = model.Id;
        int? nullableId = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;

        if (nullableId != null || model.Amount != 0) {
          int id = (int)nullableId;
          int amount = model.Amount;
          Stock stockToUpdate = _repository.UpdateStockAmount(id, amount);
          if (stockToUpdate != null) {
            _stock = stockToUpdate;
            _statusCode = HttpStatusCode.OK;
          }
          else {
            _statusCode = HttpStatusCode.NotFound;
          }
        }
        else {
          _statusCode = HttpStatusCode.BadRequest;
        }
      }
      catch (Exception updateError) {
        Console.WriteLine(updateError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      // save information
      return response.AsJson(_stock, _statusCode);
    }
  }
}
