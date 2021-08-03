using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    internal Response DeleteStockByID(IResponseFormatter response, Request request) {
      try {
        // Parsing query
        int id = request.Query["id"];
        Stock stock = _repository.DeleteStock(id);
        if (stock != null) {
          _stock = stock;
          _statusCode = HttpStatusCode.OK;
        }
        else {
          _statusCode = HttpStatusCode.NotFound;
        }
      }
      catch (Exception deleteError) {
        Console.WriteLine(deleteError.Message);
        _statusCode = HttpStatusCode.InternalServerError;
      }
      return response.AsJson(_stock, _statusCode);
    }
  }
}
