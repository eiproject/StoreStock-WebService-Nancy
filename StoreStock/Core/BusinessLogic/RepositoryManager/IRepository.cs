using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IRepository {
    Stock CreateStoreStock(string type,
      int amount,
      string title,
      decimal price,
      string category,
      string subcategory,
      string size);
    List<Stock> ReadStoreStock();
    List<Stock> ReadStocksByType(string type);
    Stock ReadStocksById(int id);
    Stock UpdateStockAmount(int stockID, int amount);
    bool DeleteStoreStock(int stockID);
  }
}
