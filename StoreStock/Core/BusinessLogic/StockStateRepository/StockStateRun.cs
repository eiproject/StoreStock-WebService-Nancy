using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockStateRun : IStockState {
    private Store _store;
    private IFactory _factory; 
    internal StockStateRun(IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("--- Stock run - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Stock run - Store reference null");
    }
    // Method of the repository start here
    Stock IStockState.CreateOneStock(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subCategory,
      string size) {
      int id = _store.LastID + 1;
      Stock stock = _factory.StockFactory(type, id, amount, title, price, category, subCategory, size);
      _store.AddStock(stock);
      return stock;
    }

    Stock IStockState.ReadOneStock(int id) {
      IEnumerable<Stock> filteredData = _store.StoreData.Where(
        data => data.ID == id);
      if (filteredData.Count() > 0) {
        return filteredData.First();
      }
      else {
        return null;
      }
    }
    Stock IStockState.UpdateStockAmount(int stockID, int amountDifference) {
      Stock stock = _store.StoreData.Find(data => data.ID == stockID);
      if (stock != null) {
        if (stock.Amount == 0 || stock.Amount + amountDifference < 0) {
          Console.WriteLine("Input amount INVALID | UpdateStoreStock");
          return null;
        }
        else {
          stock += amountDifference;
        }
      }
      else {
        Console.WriteLine("Input ID INVALID | UpdateStoreStock");
      }

      return stock;
    }
    Stock IStockState.DeleteStock(int stockID) {
      Stock stock = _store.StoreData.Find(data => data.ID == stockID);
      if (stock != null) {
        _store.RemoveStock(stock);
        return stock;
      }
      else {
        Console.WriteLine("Input ID INVALID | DeleteStoreStock");
        return null;
      }
    }
  }
}
