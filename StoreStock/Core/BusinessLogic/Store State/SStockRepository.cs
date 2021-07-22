using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class SStockRepository : IStockRepository{

    private IState _init;
    private IState _running;
    private IState _shuttingDown;

    private IState _state;
    internal SStockRepository(IFactory factory) {
      _init = new InitState(factory);
      _running = new RunningState(factory);
      _shuttingDown = new ShuttingDownState(factory);
      
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

    internal void SetState(IState state) {
      _state = state;
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
