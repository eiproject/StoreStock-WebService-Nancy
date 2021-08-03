using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStockRepository {
    Stock CreateOneStockUsingState(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subcategory,
      string size);
    Stock ReadOneStockByIdUsingState(int id);
    Stock UpdateStockAmountByIdUsingState(int stockID, int amount);
    Stock DeleteOneStockByIdUsingState(int stockID);
    void ChangeStateToInit();
    void ChangeStateToRun();
    void ChangeStateToStop();
  }
}
