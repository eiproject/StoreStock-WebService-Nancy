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
      int id = _store.LastIdInStocks + 1;
      Stock stock = _factory.FactoryStock(type, id, amount, title, price, category, subCategory, size);
      _store.AppendStocksByStock(stock);
      return stock;
    }

    Stock IStockState.ReadOneStockById(int id) {
      IEnumerable<Stock> filteredData = _store.Stocks.Where(
        data => data.ID == id);
      Stock result = null;
      if (filteredData.Count() > 0) {
        result = filteredData.First();
      }
      return result;
    }
    Stock IStockState.UpdateStockAmountById(int stockID, int amountDifference) {
      Stock stock = _store.Stocks.Find(data => data.ID == stockID);
      if (stock != null) {
        if (stock.Amount == 0 || stock.Amount + amountDifference < 0) {
          throw new ArgumentNullException("Stock amount is zero, IStockState.UpdateStockAmountById");
        }
        else {
          stock += amountDifference;
        }
      }
      else {
        throw new NullReferenceException("Stock in IStockState.UpdateStockAmountById, null");
      }

      return stock;
    }
    Stock IStockState.DeleteOneStockById(int stockID) {
      Stock stock = _store.Stocks.Find(data => data.ID == stockID);
      if (stock != null) {
        _store.RemoveStockInStocks(stock);
        return stock;
      }
      else {
        throw new NullReferenceException("Stock in IStockState.DeleteOneStockById, null");
      }
    }
  }
}
