using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class ShuttingDownStoreState : IStoreState {
    private Store _store;
    internal ShuttingDownStoreState(IFactory factory) {
      _store = factory.GetStore();
    }
    List<Stock> IStoreState.ReadStoreStock() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {

    }
  }
}
