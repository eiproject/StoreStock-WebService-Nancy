using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class InitStoreState : IStoreState {
    private Store _store;
    private IFactory _factory;
    private IStockRepository _repository;
    internal InitStoreState(IFactory factory, IStockRepository repository) {
      _factory = factory;
      _store = factory.GetStore();

      GenerateDummyData();
    }
    void GenerateDummyData() {
      Run storeStock = new Run(_factory);
      storeStock.Start(_store);
      storeStock.UseDummyData(_repository);
    }
    // Method of the repository start here
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {
     
    }
  }
}
