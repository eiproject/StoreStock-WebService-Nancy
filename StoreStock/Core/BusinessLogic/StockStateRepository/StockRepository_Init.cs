using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository_Init : IStockState {
    private Store _store;
    private IFactory _factory;
    private bool _isSuccess;
    bool IStockState.IsSuccess { get { return _isSuccess; } }

    internal StockRepository_Init(IFactory factory) { 
      _isSuccess = CheckingFactory(factory); 
      _isSuccess = CheckingStore(factory.GetStore()) && _isSuccess; 
    }

    bool CheckingStore(Store store) {
      Console.WriteLine("... Checking Store Object");
      Thread.Sleep(1500);
      if (store != null) {
        Console.WriteLine("+++ Store, OK");
        _store = store;
        return true;
      }
      else {
        Console.WriteLine("--- Store, NULL");
        return false;
      }
    }
    bool CheckingFactory(IFactory factory) {
      Console.WriteLine("... Checking Factory Object");
      Thread.Sleep(1500);
      if (factory != null) {
        Console.WriteLine("+++ Factory, OK");
        _factory = factory;
        return true;
      }
      else {
        Console.WriteLine("--- Factory, NULL");
        return false;
      }
    }

    Stock IStockState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }

    Stock IStockState.ReadStock(int id) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
    Stock IStockState.UpdateStock_Amount(int stockID, int amountDifference) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
    Stock IStockState.DeleteStock(int stockID) {
      Console.WriteLine("Initializing Stock...");
      return null;
    }
  }
}
