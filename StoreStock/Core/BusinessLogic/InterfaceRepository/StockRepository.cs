using System;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository : IStockRepository {
    Stock _stock;
    Store _store;
    IFactory _factory;
    private IStockState _init;
    private IStockState _run;
    private IStockState _stop;

    private bool _isInitialized = false;
    private IStockState _state;
    internal StockRepository(Store store, IFactory factory) {
      _store = store;
      _factory = factory;
    }

    Stock IStockRepository.CreateOneStockUsingState(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      Stock createStockResult = null;
      if (_state != null) {
        createStockResult = _state.CreateOneStock(type, amount, title, price, publisher, genre, size);
      }
      return createStockResult;
    }

    Stock IStockRepository.ReadOneStockByIdUsingState(int id) {
      CheckState();
      _stock = _state.ReadOneStockById(id);
      return _stock;
    }

    Stock IStockRepository.UpdateStockAmountByIdUsingState(int stockID, int amountDifference) {
      CheckState();
      _stock = _state.UpdateStockAmountById(stockID, amountDifference);
      return _stock;
    }

    Stock IStockRepository.DeleteOneStockByIdUsingState(int stockID) {
      CheckState();
      _stock = _state.DeleteOneStockById(stockID);
      return _stock;
    }

    void IStockRepository.ChangeStateToInit() {
      if (_init == null && !_isInitialized) {
        _init = new StockStateInit(_factory);
        _isInitialized = true;
      }
      _state = _init;
    }
    void IStockRepository.ChangeStateToRun() {
      if (_run == null) _run = new StockStateRun(_store, _factory);
      _state = _run;
    }
    void IStockRepository.ChangeStateToStop() {
      if (_stop == null) _stop = new StockStateStop(_factory);
      _state = _stop;
    }
    private void CheckState() {
      _state = _state ?? throw new NullReferenceException("Host is up. But the State not yet defined");
    }
  }
}
