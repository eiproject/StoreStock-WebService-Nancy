using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockStateRun : IStockState {
    Stock _stock;
    private Store _store;
    private IFactory _factory; 
    internal StockStateRun(Store store, IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("Stock run - Factory reference null");
      _store = store ?? throw new NullReferenceException("Stock run - Store reference null");
    }
    // Method of the repository start here
    Stock IStockState.CreateOneStock(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subCategory,
      string size) {
      int id = _store.LastIdInStocks + 1;
      _stock = _factory.FactoryStock(type, id, amount, title, price, category, subCategory, size);
      _store.AppendStocksByStock(_stock);
      return _stock;
    }

    Stock IStockState.ReadOneStockById(int id) {
      _stock = _store.Stocks.Find(data => data.ID == id);
      return _stock;
    }
    Stock IStockState.UpdateStockAmountById(int id, int amount) {
      _stock = _store.Stocks.Find(data => data.ID == id);
      if (_stock != null) {
        if (_stock.Amount != 0 || _stock.Amount + amount >= 0) {
          _stock += amount;
        }
      }

      return _stock;
    }
    Stock IStockState.DeleteOneStockById(int stockID) {
      _stock = _store.Stocks.Find(data => data.ID == stockID);
      if (_stock != null) {
        _store.RemoveStockInStocks(_stock);
      }
      return _stock;
    }
  }
}
