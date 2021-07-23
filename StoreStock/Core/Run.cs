using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock {
  class Run {
    private Store _store;
    private IFactory _factory;
    internal Store Store { get { return _store; } }
    internal Run(IFactory factory) {
      _factory = factory;
    }
    internal void Start(Store bookStore) {
      // Store bookStore = new Store("Nano Store");
      _store = bookStore;
    }
    internal void UseDummyData(IStockRepository repo) {
      // IStockRepository repo = new SStockRepository(_factory);
      GenerateDummyData dummy = new GenerateDummyData(repo);
      dummy.Generate();
    }
  }
}