using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IState {
    Stock CreateStock(string type,
  int amount,
  string title,
  decimal price,
  string category,
  string subcategory,
  string size);
    Stock ReadStock(int id);
    Stock UpdateStock_Amount(int stockID, int amount);
    Stock DeleteStock(int stockID);
    bool IsSuccess { get; }
  }
}
