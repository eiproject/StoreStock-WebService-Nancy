using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository_Stop : IStoreState {
    private Store _store;
    private bool _isSuccess;
    bool IStoreState.IsSuccess { get { return _isSuccess; } }
    internal StoreRepository_Stop(IFactory factory, IStockRepository repository) {
      _store = factory.GetStore();

      // cleaning store data
      _store = null;

      _isSuccess = true;
    }
    Store IStoreState.ReadStore() {
      return null;
    }

    void IStoreState.UpdateStore(string name) {

    }
  }
}
