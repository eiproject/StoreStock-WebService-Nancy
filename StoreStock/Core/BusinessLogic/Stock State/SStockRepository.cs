using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class SStockRepository : IStockRepository{
    IFactory _factory;
    private IState _init;
    private IState _running;
    private IState _shuttingDown;

    private bool _isInit = false;
    private IState _state;
    internal SStockRepository(IFactory factory) {
      _factory = factory;
      _state = _init;
    }

    Stock IStockRepository.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      return _state.CreateStock(type, amount, title, price, publisher, genre, size);
    }

    Stock IStockRepository.ReadStock(int id) {
      return _state.ReadStock(id);
    }

    Stock IStockRepository.UpdateStock_Amount(int stockID, int amountDifference) {
      return _state.UpdateStock_Amount(stockID, amountDifference);
    }

    Stock IStockRepository.DeleteStock(int stockID) {
      return _state.DeleteStock(stockID);
    }

    void IStockRepository.Init() {
      if (_init == null && !_isInit) {
        _init = new InitState(_factory);
        _isInit = true;
      }
      _state = _init;
    }
    void IStockRepository.Run() {
      if (_running == null) {
        _running = new RunningState(_factory);
      }
      _state = _running;
    }
    void IStockRepository.Stop() {
      if (_shuttingDown == null) {
        _shuttingDown = new ShuttingDownState(_factory);
      }
      _state = _shuttingDown;
    }
    internal IState GetInitState() {
      return _init;
    }
    internal IState GetRunState() {
      return _running;
    }
    internal IState GetShutDownState() {
      return _shuttingDown;
    }
  }
}
