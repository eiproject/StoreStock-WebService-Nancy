using System;

namespace StoreStock.BusinessLogic {
  class StateManager {
    private static IStoreRepository _storeRepo;
    private static IStockRepository _stockRepo;
    internal StateManager(IStoreRepository storeRepo, IStockRepository stockRepo) {
      _storeRepo = storeRepo;
      _stockRepo = stockRepo;
    }

    internal static void Init() {
      Console.WriteLine("\nInitializing...");
      _storeRepo.StateToInit();
      _stockRepo.StateToInit();
      Console.WriteLine("Initializing, OK.");
    }
    internal static void Run() {
      Console.WriteLine("\nRunning...");
      _storeRepo.StateToRun();
      _stockRepo.StateToRun();
      Console.WriteLine("Run. OK.");
    }
    internal static void Stop() {
      Console.WriteLine("\nShutting down...");
      _stockRepo.StateToStop();
      _storeRepo.StateToStop();
      Console.WriteLine("Shutting down, OK.");
    }
  }
}
