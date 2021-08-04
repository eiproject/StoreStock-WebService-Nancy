using Nancy;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    private Store _store;
    private IStoreRepository _repository;
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private string _message = "OK";
    public StoreAPI(IStoreRepository repository) {
      _repository = repository;
    }

    private void ChangeStatusToNotFound(string message) {
      _message = message;
      _statusCode = HttpStatusCode.NotFound;
    }
    
    private void ChangeStatusToInternalServerError(string message) {
      _message = message;
      _statusCode = HttpStatusCode.InternalServerError;
    }
  }
}
