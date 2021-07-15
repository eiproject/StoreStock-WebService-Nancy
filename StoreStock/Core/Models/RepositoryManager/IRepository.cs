using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  interface IRepository {
    void CreateStoreStock(string type,
      int id,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size);
    List<IStock> ReadStoreStock();
    string ReadStoreStockAsJSONString();
    List<IStock> ReadStocksByType(string type);
    void UpdateStoreStock(int stockID, int amount);
    void DeleteStoreStock(int stockID);
  }
}
