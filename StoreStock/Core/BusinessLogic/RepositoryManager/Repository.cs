using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class Repository : IRepository {
    private IStore _store;
    private IFactory _factory;
    internal Repository(IStore TheStore, IFactory factory) {
      _store = TheStore;
      _factory = factory;
    }

    // Method of the repository start here
    IStock IRepository.CreateStoreStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      int id = _store.GetLastId() + 1;
      IStock stock = _factory.FactoryStoreStock(type, id, amount, title, price, publisher, genre, size);
      _store.AddStock(stock);
      return stock;
    }
    List<IStock> IRepository.ReadStoreStock() {
      return _store.GetListOfStoreStock();
    }
    List<IStock> IRepository.ReadStocksByType(string type) {
      IEnumerable<IStock> filteredData = _store.GetListOfStoreStock().Where(
        data => data.Type == type);
      return filteredData.ToList();
    }
    List<IStock> IRepository.ReadStocksById(int id) {
      IEnumerable<IStock> filteredData = _store.GetListOfStoreStock().Where(
        data => data.ID == id);
      if (filteredData.Count() > 0) {
        return filteredData.ToList();
      }
      else {
        return null;
      }
    }

    IStock IRepository.UpdateStockAmount(int stockID, int amountDifference) {
      IStock stock = _store.GetListOfStoreStock().Find(data => data.ID == stockID);
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

    bool IRepository.DeleteStoreStock(int stockID) {
      IStock stock = _store.GetListOfStoreStock().Find(data => data.ID == stockID);
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
