using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Init : IStoreState {
    private IFactory _factory;
    private IStockRepository _repository;
    internal StoreRepository_Init(IFactory factory, IStockRepository repository) {
      _factory = factory;
      CheckingStockRepository(repository);
      GenerateDummyData();
    }
    void CheckingStockRepository(IStockRepository repository) {
      Console.WriteLine("... Checking Stock Repository");
      if (repository != null) {
        Console.WriteLine("+++ Stock Repository, OK");
        _repository = repository;
      }
      else {
        Console.WriteLine("--- Stock Repository, NULL");
      }
    }
    void GenerateDummyData() {
      Console.WriteLine("... Generating dummy data");
      StringInputParser inputParse = new StringInputParser(_factory);
      GenerateDummyData dummy = new GenerateDummyData(inputParse);
      GenerateCondition condition = dummy.Generate();
      if (condition == GenerateCondition.OK) {
        Console.WriteLine("+++ Dummy Data, OK");
      }
      else if (condition == GenerateCondition.SomeDataMissing) {
        Console.WriteLine("??? Dummy Data, Some Data Missing (suggestion: Check it)");
      }
      else if (condition == GenerateCondition.DataOverload) {
        Console.WriteLine("??? Dummy Data, Data Overload (suggestion: Check it)");
      }
      else {
        Console.WriteLine("--- Dummy Data, Failed");
      }

    }
    // Method of the repository start here
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {
     
    }
  }
}
