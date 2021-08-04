using Nancy;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    private Stock _stock = null;
    private IStockRepository _repository;
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private string _message;

    public StockAPI(IStockRepository repository) {
      _repository = repository;
    }

    private int? ParseStringToNullableInteger(string input) {
      int? nullableInteger = int.TryParse(input, out var temp) ? int.Parse(input) : (int?)null;
      return nullableInteger;
    }
  }
}
