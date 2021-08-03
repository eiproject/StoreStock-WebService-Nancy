using Nancy;
using Nancy.ModelBinding;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Net.Http;

namespace StoreStockWeb.Services {
  public partial class StockAPI {
    private Stock _stock = null;
    private Store _store;
    private IFactory _factory;
    private IStockRepository _repository;
    private HttpStatusCode _statusCode;

    public StockAPI(
        Store store, IFactory factory, IStockRepository repository) {
      _store = store;
      _factory = factory;
      _repository = repository;
    }
  }
}
