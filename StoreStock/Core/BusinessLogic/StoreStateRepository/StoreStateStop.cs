using StoreStock.Models;
using System;

namespace StoreStock.BusinessLogic {
  class StoreStateStop : IStoreState {
    private Store _store;
    internal StoreStateStop(Store store) {
      _store = store ?? throw new NullReferenceException("Store stop - Store reference null");
    }
    Store IStoreState.ReadStoreObject() {
      throw new NotImplementedException("Read Store not implemented in init state");
    }

    void IStoreState.UpdateStoreName(string name) {
      throw new NotImplementedException("Update Store not implemented in init state");
    }
  }
}
