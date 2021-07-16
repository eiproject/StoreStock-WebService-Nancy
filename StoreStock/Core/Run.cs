using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock {
  class Run {
    private IStore _store;
    private IFactory _factory;
    internal IStore Store { get { return _store; } }
    internal Run(IFactory factory) {
      _factory = factory;
    }
    internal void Start(IStore bookStore) {
      // IStore bookStore = new Store("Nano Store");
      _store = bookStore;
    }
    internal void UseDummyData() {
      IRepository repo = new Repository(_store, _factory);
      GenerateDummyData dummy = new GenerateDummyData(repo);
      dummy.Generate();
    }
  }
}