using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  interface IRepository {
    IStock CreateStoreStock(string type,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size);
    List<IStock> ReadStoreStock();
    string ReadStoreStockAsJSONString();
    List<IStock> ReadStocksByType(string type);
    List<IStock> ReadStocksById(int id);
    IStock UpdateStoreStock(int stockID, int amount);
    void DeleteStoreStock(int stockID);
  }
}
