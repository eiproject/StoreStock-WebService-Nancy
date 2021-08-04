using StoreStock.Models;
using System;

namespace StoreStock.BusinessLogic {
  class StoreRepository : IStoreRepository{
    Store _store;
    private IFactory _factory;
    private IStoreState _init;
    private IStoreState _run;
    private IStoreState _stop;
    private bool _isInitialized = false;
    private IStoreState _state;
    internal StoreRepository(Store store, IFactory factory) {
      _factory = factory;
      _store = store;
    }

    Store IStoreRepository.ReadStoreObjectUsingState() {
      CheckState();
      _store = _state.ReadStoreObject();
      return _store;
    }

    Store IStoreRepository.UpdateStoreNameUsingState(string name) {
      CheckState();
      _state.UpdateStoreName(name);
      _store = _state.ReadStoreObject();
      return _store;
    }
    void IStoreRepository.ChangeStateToInit() {
      if (_init == null && !_isInitialized) {
        _init = new StoreStateInit(_store, _factory);
        _isInitialized = true;
      }
      _state = _init;
    }
    void IStoreRepository.ChangeStateToRun() {
      if (_run == null) {
        _run = new StoreStateRun(_store);
      }
      _state = _run;
    }
    void IStoreRepository.ChangeStateToStop() {
      if (_stop == null) {
        _stop = new StoreStateStop(_store);
      }
      _state = _stop;
    }
    private void CheckState() {
      _state = _state ?? throw new NullReferenceException("Host is up. But the State not yet defined");
    }
  }
}
