using Nancy;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    private Store _store;
    private IStoreRepository _repository;
    private HttpStatusCode _statusCode;
    private string _message;
    public StoreAPI(IStoreRepository repository) {
      _repository = repository;
    }
  }
}
