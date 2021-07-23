using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class ShuttingDownStoreState : IStoreState {
    private Store _store;
    internal ShuttingDownStoreState(IFactory factory, IStockRepository repository) {
      _store = factory.GetStore();
    }
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {

    }
  }
}
