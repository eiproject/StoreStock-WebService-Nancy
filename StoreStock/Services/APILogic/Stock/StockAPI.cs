using Nancy;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    private Stock _stock = null;
    private IStockRepository _repository;
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private string _message = "OK";

    public StockAPI(IStockRepository repository) {
      _repository = repository;
    }

    private int? ParseStringToNullableInteger(string input) {
      int? nullableInteger = int.TryParse(input, out var temp) ? int.Parse(input) : (int?)null;
      return nullableInteger;
    }
    private void ChangeStatusToNotFound(string message) {
      _message = message;
      _statusCode = HttpStatusCode.NotFound;
    }

    private void ChangeStatusToBadRequest(string message) {
      _message = message;
      _statusCode = HttpStatusCode.NotFound;
    }

    private void ChangeStatusToInternalServerError(string message) {
      _message = message;
      _statusCode = HttpStatusCode.InternalServerError;
    }
  }
}
