using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Stop : IStoreState {
    private Store _store;
    internal StoreRepository_Stop(IFactory factory, IStockRepository repository) {
      _store = factory.GetStore();
    }
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {

    }
  }
}
