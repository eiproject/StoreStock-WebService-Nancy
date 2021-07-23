using System;

namespace StoreStock.BusinessLogic {
  class StateControl {
    private static IStockRepository _stockRepo;
    private static IStoreRepository _storeRepo;
    private static bool _initStock = false;
    private static bool _initStore = false;
    private static bool _runStock = false;
    private static bool _runStore = false;
    private static bool _stopStock = false;
    private static bool _stopStore = false;
    internal StateControl(IStockRepository stockRepo, IStoreRepository storeRepo) {
      _stockRepo = stockRepo;
      _storeRepo = storeRepo;
    }

    internal static void Init() {
      _initStock = _stockRepo.Init();
      _initStore = _storeRepo.Init();
    }
    internal static void Run() {
      if (_runStock && _runStore) {
        _runStock = _stockRepo.Run();
        _runStore = _storeRepo.Run();
      }
      else {
        Console.WriteLine("!!! Cannot Running, check init log!");
      }
    }
    internal static void Stop() {
      _stopStock = _stockRepo.Stop();
      _stopStore = _storeRepo.Stop();
    }
  }
}
