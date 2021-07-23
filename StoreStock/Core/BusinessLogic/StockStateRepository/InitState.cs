using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class InitState : IState {
    private Store _store;
    private IFactory _factory;
    internal InitState(IFactory factory) {
      _factory = factory;
      _store = factory.GetStore();
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
