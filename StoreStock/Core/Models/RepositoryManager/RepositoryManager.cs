using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class Repository : IUserRepository {
    List<Stock> storeStock;
    Werehouse curentWerehouse;
    internal Repository(Werehouse TheStore) {
      storeStock = TheStore.WerehouseData;
      curentWerehouse = TheStore;
    }

    // Method of the repository start here
    public List<Stock> AllStock() {
      List<Stock> allStock = storeStock;
      return allStock;
    }
    public List<Stock> FilterStocksByCategory(string className) {
      List<Stock> allStock = storeStock;
      IEnumerable<Stock> filteredData = allStock.Where(
        data => data.Type == className);
      return filteredData.ToList();
    }

    public void AddMoreStock(Stock obj) {
      List<Stock> allStock = storeStock;
      allStock.Add(obj);
      Console.WriteLine("Adding Stock Done.");
    }

    public void DeleteStock(int stockID) {
      List<Stock> allStock = storeStock;
      Stock target = allStock.Find(data => data.ID == stockID);
      if (target != null) {
        allStock.Remove(target);
        Console.WriteLine($"Product iD: {target?.ID } '{target?.Title}' Quantitiy: { target?.Quantity } sucessfully removed.");
      }
      else {
        Console.WriteLine($"Product ID: { stockID } is not exist.");
      }
    }

    public void SellStock(int stockID, int amount) {
      List<Stock> allStock = storeStock;
      Stock target = allStock.Find(data => data.ID == stockID);
      if (target != null) {
        if (amount > target.Quantity) {
          Console.WriteLine($"Amount { amount } is exceed Product ID: { stockID } stock. (Available: {target?.Quantity})");
        }
        else {
          target.RemoveSomeQuantitiy(amount);
          Console.WriteLine($"Product iD: {target?.ID } '{target?.Title}' Sold { amount } pcs");
          if (target.Quantity == 0) {
            Repository del = new Repository(curentWerehouse);
            del.DeleteStock(stockID);
          }
        }
      }
      else {
        Console.WriteLine($"Product ID: { stockID } is not exist.");
      }
    }
  }
}
