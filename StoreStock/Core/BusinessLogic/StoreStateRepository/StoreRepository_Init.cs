using System;
using System.Threading;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Init : IStoreState {
    private IFactory _factory;
    private IStockRepository _repository;
    private bool _isSuccess;
    bool IStoreState.IsSuccess { get { return _isSuccess; } }
    internal StoreRepository_Init(IFactory factory, IStockRepository repository) { 
      _factory = factory;
      _isSuccess = CheckingStockRepository(repository); 
      _isSuccess = GenerateDummyData() && _isSuccess; 
    }
    bool CheckingStockRepository(IStockRepository repository) {
      Console.WriteLine("... Checking Stock Repository");
      Thread.Sleep(1500);
      if (repository != null) {
        Console.WriteLine("+++ Stock Repository, OK");
        _repository = repository;
        return true;
      }
      else {
        Console.WriteLine("--- Stock Repository, NULL");
        return false;
      }
    }
    bool GenerateDummyData() {
      Console.WriteLine("... Generating dummy data");
      Thread.Sleep(1500);
      StringInputParser inputParse = new StringInputParser(_factory);
      GenerateDummyData dummy = new GenerateDummyData(inputParse);
      GenerateCondition condition = dummy.Generate();
      if (condition == GenerateCondition.OK) {
        Console.WriteLine("+++ Dummy Data, OK");
        return true;
      }
      else if (condition == GenerateCondition.SomeDataMissing) {
        Console.WriteLine("??? Dummy Data, Some Data Missing (suggestion: Check it)");
        return true;
      }
      else if (condition == GenerateCondition.DataOverload) {
        Console.WriteLine("??? Dummy Data, Data Overload (suggestion: Check it)");
        return true;
      }
      else {
        Console.WriteLine("--- Dummy Data, Failed");
        return false;
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
