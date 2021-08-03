using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository : IStockRepository{
    IFactory _factory;
    private IStockState _init;
    private IStockState _run;
    private IStockState _stop;

    private bool _isInitialized = false;
    private IStockState _state;
    internal StockRepository(IFactory factory) {
      _factory = factory;
      // _state = _init;
    }

    Stock IStockRepository.CreateOneStockUsingState(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      if (_state == null) { return null; }
      return _state.CreateOneStock(type, amount, title, price, publisher, genre, size);
    }

    Stock IStockRepository.ReadOneStockByIdUsingState(int id) {
      if (_state == null) { return null; }
      return _state.ReadOneStockById(id);
    }

    Stock IStockRepository.UpdateStockAmountByIdUsingState(int stockID, int amountDifference) {
      if (_state == null) { return null; }
      return _state.UpdateStockAmountById(stockID, amountDifference);
    }

    Stock IStockRepository.DeleteOneStockByIdUsingState(int stockID) {
      if (_state == null) { return null; }
      return _state.DeleteOneStockById(stockID);
    }

    void IStockRepository.ChangeStateToInit() {
      if (_init == null && !_isInitialized) {
        _init = new StockStateInit(_factory);
        _isInitialized = true;
      }
      _state = _init;
    }
    void IStockRepository.ChangeStateToRun() {
      if (_run == null) {
        _run = new StockStateRun(_factory);
      }
      _state = _run;
    }
    void IStockRepository.ChangeStateToStop() {
      if (_stop == null) {
        _stop = new StockStateStop(_factory);
      }
      _state = _stop;
    }
  }
}
