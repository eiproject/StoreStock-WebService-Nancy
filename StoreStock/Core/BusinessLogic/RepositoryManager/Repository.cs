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
      int id = _store.GetLastId();
      IStock stock = _factory.FactoryStoreStock(type, id, amount, title, price, publisher, genre, size);
      _store.AddStock(stock);
      return stock;
    }
    List<IStock> IRepository.ReadStoreStock() {
      return _store.GetListOfStoreStock();
    }
    string IRepository.ReadStoreStockAsJSONString() {
      StringBuilder jsonStrings = new StringBuilder();
      foreach (IStock data in _store.GetListOfStoreStock()) {
        string _jsonString = JsonSerializer.Serialize(data);
        jsonStrings.Append(_jsonString);
        Console.WriteLine(_jsonString);
      }
      return jsonStrings.ToString();
    }
    List<IStock> IRepository.ReadStocksByType(string type) {
      IEnumerable<IStock> filteredData = _store.GetListOfStoreStock().Where(
        data => data.Type == type);
      return filteredData.ToList();
    }
    List<IStock> IRepository.ReadStocksById(int id) {
      IEnumerable<IStock> filteredData = _store.GetListOfStoreStock().Where(
        data => data.ID == id);
      return filteredData.ToList();
    }

    IStock IRepository.UpdateStoreStock(int stockID, int amountDifference) {
      IStock stock = _store.GetListOfStoreStock().Find(data => data.ID == stockID);
      if (stock != null) {
        if (stock.Amount == 0 || stock.Amount + amountDifference < 0) {
          Console.WriteLine("Input amount INVALID | UpdateStoreStock");
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

    void IRepository.DeleteStoreStock(int stockID) {
      IStock stock = _store.GetListOfStoreStock().Find(data => data.ID == stockID);
      if (stock != null) {
        _store.RemoveStock(stock);
      }
      else {
        Console.WriteLine("Input ID INVALID | DeleteStoreStock");
      }
    }
  }
}
