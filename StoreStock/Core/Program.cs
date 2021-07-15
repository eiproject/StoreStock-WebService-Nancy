using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock {
  class Run {
    private Werehouse _store;
    internal Run() {
    }
    internal void Start() {
      Werehouse formulatrixStore = Werehouse.GetInstance();
      _store = formulatrixStore;
    }
    internal void UseDummyData() {
      GenerateDummyData dummy = new GenerateDummyData(_store);
      dummy.Generate();
    }
  }
}