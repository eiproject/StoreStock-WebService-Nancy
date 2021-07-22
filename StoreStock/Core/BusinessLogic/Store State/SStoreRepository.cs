using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class SStoreRepository {

    private IState _init;
    private IState _running;
    private IState _shuttingDown;

    private IState _state;
    internal SStoreRepository(Store store, IFactory factory) {
      _init = new InitState(store, factory);
      _running = new RunningState(store, factory);
      _shuttingDown = new ShuttingDownState(store, factory);
    }

    internal Stock CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      return _state.CreateStock(type, amount, title, price, publisher, genre, size);
    }

    internal Stock ReadStock(int id) {
      return _state.ReadStock(id);
    }

    internal Stock UpdateStock_Amount(int stockID, int amountDifference) {
      return _state.UpdateStock_Amount(stockID, amountDifference);
    }

    internal Stock DeleteStock(int stockID) {
      return DeleteStock(stockID);
    }
  }
}
