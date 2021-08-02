using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStockState {
    Stock CreateStock(string type,
  int amount,
  string title,
  decimal price,
  string category,
  string subcategory,
  string size);
    Stock ReadStock(int id);
    Stock UpdateStockAmount(int stockID, int amount);
    Stock DeleteStock(int stockID);
  }
}
