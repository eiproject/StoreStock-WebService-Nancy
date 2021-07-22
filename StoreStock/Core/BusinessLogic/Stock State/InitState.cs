﻿using System;
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
      
      GenerateDummyData();
    }
    void GenerateDummyData() {
      Run storeStock = new Run(_factory);
      storeStock.Start(_store);
      storeStock.UseDummyData();
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