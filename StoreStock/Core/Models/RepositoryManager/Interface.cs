using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  interface IUserRepository {
    List<Stock> AllStock();
    List<Stock> FilterStocksByCategory(string category);
    void AddMoreStock(Stock newStock);
    void DeleteStock(int stockID);
    void SellStock(int stockID, int amount);
  }
}
