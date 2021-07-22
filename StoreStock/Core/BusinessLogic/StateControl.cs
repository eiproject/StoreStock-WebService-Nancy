namespace StoreStock.BusinessLogic {
  class StateControl {
    private static IStockRepository _stockRepo;
    private static IStoreRepository _storeRepo;
    internal StateControl(IStockRepository stockRepo, IStoreRepository storeRepo) {
      _stockRepo = stockRepo;
      _storeRepo = storeRepo;
    }

    internal static void Init() {
      _stockRepo.Init();
      _storeRepo.Init();
    }
    internal static void Run() {
      _stockRepo.Run();
      _storeRepo.Run();
    }
    internal static void Stop() {
      _stockRepo.Stop();
      _storeRepo.Stop();
    }
  }
}
