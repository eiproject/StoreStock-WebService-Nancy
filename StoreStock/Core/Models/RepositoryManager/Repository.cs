using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class Repository : IRepository {
    private IStore _store;
    private IFactory _creator;
    internal Repository(IStore TheStore) {
      _store = TheStore;
    }

    // Method of the repository start here
    void IRepository.CreateStoreStock(string type,
      int id,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      IStock stock = _creator.FactoryStoreStock(type, id, amount, title, price, publisher, genre, size);
      _store.AddStock(stock);
    }
    List<IStock> IRepository.ReadStoreStock() {
      return _store.GetListOfStoreStock();
    }
    string IRepository.ReadStoreStockAsJSONString() {
      StringBuilder jsonStrings = new StringBuilder();
      foreach (Stock data in _store.GetListOfStoreStock()) {
        AutomaticObjectConverter converter = new AutomaticObjectConverter(data);
        string _jsonString = JsonSerializer.Serialize(converter.ConvertedObject);
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

    void IRepository.UpdateStoreStock(int stockID, int amountDifference) {
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
