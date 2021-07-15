using System;
using System.Collections.Generic;
using System.Linq;
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
    List<IStock> ReadStocksByType(string type);
    void UpdateStoreStock(int stockID, int amount);
    void DeleteStoreStock(int stockID);
  }
}
