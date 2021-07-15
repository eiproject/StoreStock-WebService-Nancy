using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock {
  class Run {
    private Store _store;
    internal Store Store { get { return _store; } }
    internal Run() {
    }
    internal void Start() {
      Store bookStore = new Store();
      bookStore.SetStoreName("Nano Store");
      _store = bookStore;
    }
    internal void UseDummyData() {
      GenerateDummyData dummy = new GenerateDummyData(_store);
      dummy.Generate();
    }
  }
}