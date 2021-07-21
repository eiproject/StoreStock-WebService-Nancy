using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IRepository {
    IStock CreateStoreStock(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subcategory,
      string size);
    List<IStock> ReadStoreStock();
    List<IStock> ReadStocksByType(string type);
    IStock ReadStocksById(int id);
    IStock UpdateStockAmount(int stockID, int amount);
    bool DeleteStoreStock(int stockID);
  }
}
