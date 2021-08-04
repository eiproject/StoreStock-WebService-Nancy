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
    }

    Store IStoreRepository.ReadStoreObjectUsingState() {
      Store readStoreResult = null;
      if (_state != null) {
        readStoreResult = _state.ReadStoreObject();
      }
      return readStoreResult;
    }

    Store IStoreRepository.UpdateStoreNameUsingState(string name) {
      Store updateStoreResult = null;
      if (_state!= null) {
        _state.UpdateStoreName(name);
        updateStoreResult = _state.ReadStoreObject();
      }
      return updateStoreResult;
    }
    void IStoreRepository.ChangeStateToInit() {
      if (_init == null && !_isInitialized) {
        _init = new StoreStateInit(_factory, _repository);
        _isInitialized = true;
      }
      _state = _init;
    }
    void IStoreRepository.ChangeStateToRun() {
      if (_run == null) {
        _run = new StoreStateRun(_factory, _repository);
      }
      _state = _run;
    }
    void IStoreRepository.ChangeStateToStop() {
      if (_stop == null) {
        _stop = new StoreStateStop(_factory, _repository);
      }
      _state = _stop;
    }
  }
}
