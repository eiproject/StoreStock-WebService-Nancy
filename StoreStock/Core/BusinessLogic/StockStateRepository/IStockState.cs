using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStockState {
    Stock CreateOneStock(string type,
  int amount,
  string title,
  decimal price,
  string category,
  string subcategory,
  string size);
    Stock ReadOneStockById(int id);
    Stock UpdateStockAmountById(int stockId, int amount);
    Stock DeleteOneStockById(int stockId);
  }
}
