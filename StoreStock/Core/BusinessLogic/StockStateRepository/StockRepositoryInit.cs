﻿using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepositoryInit : IStockState {
    private Store _store;
    private IFactory _factory;

    internal StockRepositoryInit(IFactory factory) {
      _factory = factory ?? throw new NullReferenceException("--- Stock init - Factory reference null");
      _store = factory.GetStore() ?? throw new NullReferenceException("--- Stock init - Store reference null");
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
