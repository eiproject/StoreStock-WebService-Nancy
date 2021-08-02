using StoreStock.Models;
using System;
using System.Collections.Generic;

namespace StoreStock.BusinessLogic {
  class StockStateStop : IStockState {
    private Store _store;
    private IFactory _factory;
    internal StockStateStop(IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("--- Stock stop - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Stock stop - Store reference null");
      CleanAllStocks(_store);
      if (_store.StoreData.Count == 0) { } else { throw new InvalidOperationException("Store Data is still exist after deletion."); }
    }
    void CleanAllStocks(Store store) {
      store.CleanStock();
    }
    // Method of the repository start here
    Stock IStockState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      throw new NotImplementedException("Create not implemented in stop state");
    }

    Stock IStockState.ReadStock(int id) {
      throw new NotImplementedException("Read not implemented in stop state");
    }
    Stock IStockState.UpdateStockAmount(int stockID, int amountDifference) {
      throw new NotImplementedException("Update not implemented in stop state");
    }
    Stock IStockState.DeleteStock(int stockID) {
      throw new NotImplementedException("Delete not implemented in stop state");
    }
  }
}
