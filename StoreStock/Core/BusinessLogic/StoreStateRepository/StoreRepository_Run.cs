using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Run : IStoreState {
    private Store _store;
    internal StoreRepository_Run(IFactory factory, IStockRepository repository) {
      _store = factory.GetStore();
    }

    Store IStoreState.ReadStore() {
      return _store;
    }

    void IStoreState.UpdateStore(string name) {
      _store.UpdateName(name);
    }
  }
}
