using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class InitStoreState : IStoreState {
    private Store _store;
    private IFactory _factory;
    private IStockRepository _repository;
    internal InitStoreState(IFactory factory, IStockRepository repository) {
      _factory = factory;
      _store = factory.GetStore();
      _repository = repository;
      GenerateDummyData();
    }
    void GenerateDummyData() {
      Console.WriteLine("--- Generating dummy data");
      StringInputParser inputParse = new StringInputParser(_factory);
      GenerateDummyData dummy = new GenerateDummyData(inputParse);
      dummy.Generate();

      Console.WriteLine("--- Generating dummy data (OK)");
    }
    // Method of the repository start here
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {
     
    }
  }
}
