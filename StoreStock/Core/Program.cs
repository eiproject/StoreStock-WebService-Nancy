using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock {
  class Run {
    private Werehouse _store;
    internal Werehouse Store { get { return _store; } }
    internal Run() {
    }
    internal void Start() {
      Werehouse bookStore = new Werehouse();
      bookStore.SetStoreName("Nano Store");
      _store = bookStore;
    }
    internal void UseDummyData() {
      GenerateDummyData dummy = new GenerateDummyData(_store);
      dummy.Generate();
    }
  }
}