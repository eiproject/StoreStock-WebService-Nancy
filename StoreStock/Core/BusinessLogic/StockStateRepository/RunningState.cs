using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class RunningState : IState {
    private Store _store;
    private IFactory _factory;
    internal RunningState(IFactory factory) {
      _factory = factory;
      _store = factory.GetStore();
    }
    // Method of the repository start here
    Stock IState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subCategory,
      string size) {
      int id = _store.LastID + 1;
      Stock stock = _factory.FactoryStoreStock(type, id, amount, title, price, category, subCategory, size);
      _store.AddStock(stock);
      return stock;
    }

    Stock IState.ReadStock(int id) {
      IEnumerable<Stock> filteredData = _store.StoreData.Where(
        data => data.ID == id);
      if (filteredData.Count() > 0) {
        return filteredData.First();
      }
      else {
        return null;
      }
    }
    Stock IState.UpdateStock_Amount(int stockID, int amountDifference) {
      Stock stock = _store.StoreData.Find(data => data.ID == stockID);
      if (stock != null) {
        if (stock.Amount == 0 || stock.Amount + amountDifference < 0) {
          Console.WriteLine("Input amount INVALID | UpdateStoreStock");
          return null;
        }
        else {
          stock.UpdateStockAmount(amountDifference);
        }
      }
      else {
        Console.WriteLine("Input ID INVALID | UpdateStoreStock");
      }

      return stock;
    }
    Stock IState.DeleteStock(int stockID) {
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
