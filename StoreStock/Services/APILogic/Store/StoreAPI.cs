using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;

namespace StoreStockWeb.Services {
  public partial class StoreAPI {
    private Store _store;
    private IStoreRepository _repository;
    private HttpStatusCode _statusCode;
    public StoreAPI(Store store, IStoreRepository repository) {
      _store = store;
      _repository = repository;
    }
  }
}
