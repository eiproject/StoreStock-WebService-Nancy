using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository_Init : IState {
    private Store _store;
    private IFactory _factory;
    internal StockRepository_Init(IFactory factory) {
      CheckingFactory(factory);
      CheckingStore(factory.GetStore());
    }

    void CheckingStore(Store store) {
      Console.WriteLine("... Checking Store Object");
      if (store != null) {
        Console.WriteLine("+++ Store, OK");
        _store = store;
      }
      else {
        Console.WriteLine("--- Store, NULL");
      }
    }
    void CheckingFactory(IFactory factory) {
      Console.WriteLine("... Checking Factory Object");
      if (factory != null) {
        Console.WriteLine("+++ Factory, OK");
        _factory = factory;
      }
      else {
        Console.WriteLine("--- Factory, NULL");
      }
    }

    Stock IState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }

    Stock IState.ReadStock(int id) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
    Stock IState.UpdateStock_Amount(int stockID, int amountDifference) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
    Stock IState.DeleteStock(int stockID) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
  }
}
