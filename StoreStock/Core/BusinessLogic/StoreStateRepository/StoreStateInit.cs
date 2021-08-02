using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreStateInit : IStoreState {
    private IFactory _factory;
    private IStockRepository _repository;
    internal StoreStateInit(IFactory factory, IStockRepository repository) {
      _factory = factory ?? throw new NullReferenceException("--- Store init - Factory reference null");
      _repository = repository ?? throw new NullReferenceException("--- Store init - Repository reference null");
      GenerateDummyData();
    }

    void GenerateDummyData() {
      Console.WriteLine("... Generating dummy data");
      Thread.Sleep(1500);
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
      // Exception handler
      throw new NotImplementedException();
    }
  }
}
