using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StockRepository_Stop : IStockState {
    private Store _store;
    private IFactory _factory;
    private bool _isSuccess;
    bool IStockState.IsSuccess { get { return _isSuccess; } }
    internal StockRepository_Stop(IFactory factory) {
      _store = factory.GetStore();
      _factory = factory;
      _isSuccess = true;
    }
    // Method of the repository start here
    Stock IStockState.CreateStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      return null;
    }

    Stock IStockState.ReadStock(int id) {
      return null;
    }
    Stock IStockState.UpdateStock_Amount(int stockID, int amountDifference) {
      return null;
    }
    Stock IStockState.DeleteStock(int stockID) {
      return null;
    }
  }
}
