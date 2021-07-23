using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Run : IStoreState {
    private Store _store;
    private bool _isSuccess;
    bool IStoreState.IsSuccess { get { return _isSuccess; } }
    internal StoreRepository_Run(IFactory factory, IStockRepository repository) { 
      _isSuccess = LoadStore(factory.GetStore()); 
    }
    bool LoadStore(Store store) {
      Console.WriteLine("... Loading store");
      Thread.Sleep(1500);
      if (store != null) {
        _store = store;
        Console.WriteLine("+++ Store, OK");
        return true;
      }
      else {
        Console.WriteLine("--- Store, FAILED");
        return false;
      }
    }

    Store IStoreState.ReadStore() {
      return _store;
    }

    void IStoreState.UpdateStore(string name) {
      _store.UpdateName(name);
    }
  }
}
