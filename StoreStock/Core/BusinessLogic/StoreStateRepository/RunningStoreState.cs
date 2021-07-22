using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class RunningStoreState : IStoreState {
    private Store _store;
    internal RunningStoreState(IFactory factory) {
      _store = factory.GetStore();
    }

    List<Stock> IStoreState.ReadStoreStock() {
      return _store.StoreData;
    }

    void IStoreState.UpdateStore(string name) {
      _store.UpdateName(name);
    }
  }
}
