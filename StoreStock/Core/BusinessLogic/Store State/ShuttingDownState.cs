using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class ShuttingDownState : IState {
    private Store _store;
    private IFactory _factory;
    internal ShuttingDownState(Store theStore, IFactory factory) {
      _store = theStore;
      _factory = factory;
    }
    // Method of the repository start here
    Stock IState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      return null;
    }

    Stock IState.ReadStock(int id) {
      return null;
    }
    Stock IState.UpdateStock_Amount(int stockID, int amountDifference) {
      return null;
    }
    Stock IState.DeleteStock(int stockID) {
      return null;
    }
  }
}
