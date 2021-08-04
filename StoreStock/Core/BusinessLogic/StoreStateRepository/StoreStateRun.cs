using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreStateRun : IStoreState {
    private Store _store;
    internal StoreStateRun(Store store) {
      _store = store ?? throw new NullReferenceException("Store run - Store reference null");
    }

    Store IStoreState.ReadStoreObject() {
      return _store;
    }

    void IStoreState.UpdateStoreName(string name) {
      _store.UpdateStoreName(name);
    }
  }
}
