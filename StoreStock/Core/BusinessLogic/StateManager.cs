using System;

namespace StoreStock.BusinessLogic {
  class StateManager {
    private static IStoreRepository _storeRepo;
    private static IStockRepository _stockRepo;
    internal StateManager(IStoreRepository storeRepo, IStockRepository stockRepo) {
      _storeRepo = storeRepo;
      _stockRepo = stockRepo;
    }

    internal static void InitStockAndStore() {
      Console.WriteLine("\nInitializing...");
      _storeRepo.ChangeStateToInit();
      _stockRepo.ChangeStateToInit();
      Console.WriteLine("Initializing, OK.");
    }
    internal static void RunStockAndStore() {
      Console.WriteLine("\nRunning...");
      _storeRepo.ChangeStateToRun();
      _stockRepo.ChangeStateToRun();
      Console.WriteLine("Run. OK.");
    }
    internal static void StopStockAndStore() {
      Console.WriteLine("\nShutting down...");
      _stockRepo.ChangeStateToStop();
      _storeRepo.ChangeStateToStop();
      Console.WriteLine("Shutting down, OK.");
    }
  }
}
