using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockStateInit : IStockState {
    private Store _store;
    private IFactory _factory;

    internal StockStateInit(IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("--- Stock init - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Stock init - Store reference null");
    }

    Stock IStockState.CreateOneStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      throw new NotImplementedException("Create not implemented in init state");
    }

    Stock IStockState.ReadStock(int id) {
      throw new NotImplementedException("Read not implemented in init state");
    }
    Stock IStockState.UpdateStockAmount(int stockID, int amountDifference) {
      throw new NotImplementedException("Update not implemented in init state");
    }
    Stock IStockState.DeleteStock(int stockID) {
      throw new NotImplementedException("Delete not implemented in init state");
    }
  }
}
