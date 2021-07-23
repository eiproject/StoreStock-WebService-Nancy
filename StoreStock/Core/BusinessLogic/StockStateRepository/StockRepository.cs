using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository : IStockRepository{
    IFactory _factory;
    private IState _init;
    private IState _run;
    private IState _stop;

    private bool _isInitialized = false;
    private IState _state;
    internal StockRepository(IFactory factory) {
      _factory = factory;
      // _state = _init;
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
      if (_state == null) { return null; }
      return _state.ReadStock(id);
    }

    Stock IStockRepository.UpdateStock_Amount(int stockID, int amountDifference) {
      if (_state == null) { return null; }
      return _state.UpdateStock_Amount(stockID, amountDifference);
    }

    Stock IStockRepository.DeleteStock(int stockID) {
      if (_state == null) { return null; }
      return _state.DeleteStock(stockID);
    }

    bool IStockRepository.Init() {
      if (_init == null && !_isInitialized) {
        _init = new StockRepository_Init(_factory);
        _isInitialized = true;
      }
      _state = _init;
      return _init.IsSuccess;
    }
    bool IStockRepository.Run() {
      if (_run == null) {
        _run = new StockRepository_Run(_factory);
      }
      _state = _run;
      return _run.IsSuccess;
    }
    bool IStockRepository.Stop() {
      if (_stop == null) {
        _stop = new StockRepository_Stop(_factory);
      }
      _state = _stop;
      return _stop.IsSuccess;
    }
    internal IState GetInitState() {
      return _init;
    }
    internal IState GetRunState() {
      return _run;
    }
    internal IState GetShutDownState() {
      return _stop;
    }
  }
}
