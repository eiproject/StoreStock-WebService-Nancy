using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository : IStockRepository {
    private Store _store;
    private IFactory _factory;
    internal StockRepository(Store TheStore, IFactory factory) {
      _store = TheStore;
      _factory = factory;
    }
    // Method of the repository start here
    Stock IStockRepository.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      int id = _store.LastID + 1;
      Stock stock = _factory.FactoryStoreStock(type, id, amount, title, price, publisher, genre, size);
      _store.AddStock(stock);
      return stock;
    }

    Stock IStockRepository.ReadStock(int id) {
      IEnumerable<Stock> filteredData = _store.StoreData.Where(
        data => data.ID == id);
      if (filteredData.Count() > 0) {
        return filteredData.First();
      }
      else {
        return null;
      }
    }
    Stock IStockRepository.UpdateStock_Amount(int stockID, int amountDifference) {
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
    bool IStockRepository.DeleteStock(int stockID) {
      Stock stock = _store.StoreData.Find(data => data.ID == stockID);
      if (stock != null) {
        _store.RemoveStock(stock);
        return true;
      }
      else {
        Console.WriteLine("Input ID INVALID | DeleteStoreStock");
        return false;
      }
    }
  }
}
