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
    Store IStoreState.ReadStoreObject() {
      throw new NotImplementedException("Read Store not implemented in init state");
    }

    void IStoreState.UpdateStoreName(string name) {
      throw new NotImplementedException("Update Store not implemented in init state");
    }
  }
}
