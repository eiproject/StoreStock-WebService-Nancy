using System;

namespace StoreStock.BusinessLogic {
  class StateControl {
    private static IStoreRepository _storeRepo;
    private static IStockRepository _stockRepo;
    private static bool _initStore = false;
    private static bool _initStock = false;
    private static bool _runStore = false;
    private static bool _runStock = false;
    private static bool _stopStore = false;
    private static bool _stopStock = false;
    internal StateControl(IStoreRepository storeRepo, IStockRepository stockRepo) {
      _storeRepo = storeRepo;
      _stockRepo = stockRepo;
    }

    internal static void Init() {
      Console.WriteLine("\nInitializing...");
      _initStore = _storeRepo.Init();
      _initStock = _stockRepo.Init();
      if (_initStore && _initStock) {
        Console.WriteLine("Initializing, OK.");
      }
      else {
        Stop();
        Console.WriteLine("Initializing. Failed, check log.");
      }
    }
    internal static void Run() {
      Console.WriteLine("\nRunning...");
      if (_initStock && _initStore) {
        _runStore = _storeRepo.Run();
        _runStock = _stockRepo.Run();

        if (_runStore && _runStock) {
          Console.WriteLine("Run. OK.");
        }
        else {
          Stop();
          Console.WriteLine("!!! Cannot Running, check run log!");
        }
      } 
      else {
        Console.WriteLine("!!! Cannot Running, check init log!");
      }
    }
    internal static void Stop() {
      Console.WriteLine("\nShutting down...");
      _stopStock = _stockRepo.Stop();
      _stopStore = _storeRepo.Stop();
      Console.WriteLine("Shutting down, OK.");
    }
  }
}
