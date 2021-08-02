using StoreStock.Models;
using System;

namespace StoreStock.BusinessLogic {
  class StoreStateStop : IStoreState {
    private IFactory _factory;
    private IStockRepository _repository;
    private Store _store;
    internal StoreStateStop(IFactory factory, IStockRepository repository) {
      _factory = factory ?? throw new NullReferenceException("--- Store stop - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Store stop - Store reference null");
      _repository = repository ?? throw new NullReferenceException("--- Store stop - Repository reference null");

      _store = null;
    }
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {

    }
  }
}
