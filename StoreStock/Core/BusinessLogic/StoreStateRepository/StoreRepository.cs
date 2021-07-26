using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository : IStoreRepository{
    private IFactory _factory;
    private IStockRepository _repository;
    private IStoreState _init;
    private IStoreState _run;
    private IStoreState _stop;
    private bool _isInitialized = false;
    private IStoreState _state;
    internal StoreRepository(IFactory factory, IStockRepository repository) {
      _factory = factory;
      _repository = repository;
      // _state = _init;
    }

    Store IStoreRepository.ReadStore() {
      if (_state != null) {
        return _state.ReadStore();
      }
      else {
        return null;
      }
    }

    Store IStoreRepository.UpdateStore(string name) {
      if (_state!= null) {
        _state.UpdateStore(name);
        return _state.ReadStore();
      }
      else {
        return null;
      }

    }
    bool IStoreRepository.Init() {
      if (_init == null && !_isInitialized) {
        _init = new StoreRepositoryInitState(_factory, _repository);
        _isInitialized = true;
      }
      _state = _init;
      return _init.IsSuccess;
    }
    bool IStoreRepository.Run() {
      if (_run == null) {
        _run = new StoreRepositoryRun(_factory, _repository);
      }
      _state = _run;
      return _run.IsSuccess;
    }
    bool IStoreRepository.Stop() {
      if (_stop == null) {
        _stop = new StoreRepositoryStop(_factory, _repository);
      }
      _state = _stop;
      return _stop.IsSuccess;
    }
    internal IStoreState GetInitState() {
      return _init;
    }
    internal IStoreState GetRunState() {
      return _run;
    }
    internal IStoreState GetShutDownState() {
      return _stop;
    }
  }
}
