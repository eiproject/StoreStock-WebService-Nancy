using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockStateInit : IStockState {
    private IFactory _factory;
    internal StockStateInit(IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("Stock init - Factory reference null");
    }

    Stock IStockState.CreateOneStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      throw new NotImplementedException("Create Stock not implemented in init state");
    }

    Stock IStockState.ReadOneStockById(int id) {
      throw new NotImplementedException("Read Stock not implemented in init state");
    }
    Stock IStockState.UpdateStockAmountById(int stockID, int amountDifference) {
      throw new NotImplementedException("Update Stock not implemented in init state");
    }
    Stock IStockState.DeleteOneStockById(int stockID) {
      throw new NotImplementedException("Delete Stock not implemented in init state");
    }
  }
}
