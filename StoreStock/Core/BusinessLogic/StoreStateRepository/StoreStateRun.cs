using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreStateRun : IStoreState {
    private IFactory _factory;
    private IStockRepository _repository;
    private Store _store;
    internal StoreStateRun(IFactory factory, IStockRepository repository) {
      _factory = factory ?? throw new NullReferenceException("--- Store run - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Store run - Store reference null");
      _repository = repository ?? throw new NullReferenceException("--- Store run - Repository reference null");
    }

    Store IStoreState.ReadStore() {
      return _store;
    }

    void IStoreState.UpdateStore(string name) {
      _store.UpdateName(name);
    }
  }
}
