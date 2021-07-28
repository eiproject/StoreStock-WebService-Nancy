using System;

namespace StoreStock.BusinessLogic {
  class StateControl {
    private static IStoreRepository _storeRepo;
    private static IStockRepository _stockRepo;
    internal StateControl(IStoreRepository storeRepo, IStockRepository stockRepo) {
      _storeRepo = storeRepo;
      _stockRepo = stockRepo;
    }

    internal static void Init() {
      Console.WriteLine("\nInitializing...");
      _storeRepo.Init();
      _stockRepo.Init();
      Console.WriteLine("Initializing, OK.");
    }
    internal static void Run() {
      Console.WriteLine("\nRunning...");
      _storeRepo.Run();
      _stockRepo.Run();
      Console.WriteLine("Run. OK.");
    }
    internal static void Stop() {
      Console.WriteLine("\nShutting down...");
      _stockRepo.Stop();
      _storeRepo.Stop();
      Console.WriteLine("Shutting down, OK.");
    }
  }
}
