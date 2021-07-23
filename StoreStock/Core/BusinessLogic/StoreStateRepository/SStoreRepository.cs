using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class SStoreRepository : IStoreRepository{
    private IFactory _factory;
    private IStockRepository _repository;
    private IStoreState _init;
    private IStoreState _running;
    private IStoreState _shuttingDown;
    private bool _isInit = false;
    private IStoreState _state;
    internal SStoreRepository(IFactory factory, IStockRepository repository) {
      _factory = factory;
      _repository = repository;
      // _state = _init;
    }

    Store IStoreRepository.ReadStore() {
      return _state.ReadStore();
    }

    void IStoreRepository.UpdateStore(string name) {
      _state.UpdateStore(name);
    }

    void IStoreRepository.Init() {
      if (_init == null && !_isInit) {
        _init = new InitStoreState(_factory, _repository);
        _isInit = true;
      }
      _state = _init;
    }
    void IStoreRepository.Run() {
      if (_running == null) {
        _running = new RunningStoreState(_factory, _repository);
      }
      _state = _running;
    }
    void IStoreRepository.Stop() {
      if (_shuttingDown == null) {
        _shuttingDown = new ShuttingDownStoreState(_factory, _repository);
      }
      _state = _shuttingDown;
    }
    internal IStoreState GetInitState() {
      return _init;
    }
    internal IStoreState GetRunState() {
      return _running;
    }
    internal IStoreState GetShutDownState() {
      return _shuttingDown;
    }
  }
}
