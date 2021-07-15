using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class Repository : IRepository { 
    private IStore _store;
    private IFactory _creator;
    internal Repository(IStore TheStore) {
      _store = TheStore;
    }

    // Method of the repository start here
    void IRepository.CreateStoreStock(string type,
      int id,
      int amount,
      string title,
      decimal price,
      string publisher,
      string genre,
      string size) {
      IStock stock = _creator.FactoryStoreStock(type, id, amount, title, price, publisher, genre, size);
      _store.AddStock(stock);
    }
    List<IStock> IRepository.ReadStoreStock() {
      return _store.GetListOfStoreStock();
    }
    List<IStock> IRepository.ReadStocksByType(string type) {
      IEnumerable<IStock> filteredData = _store.GetListOfStoreStock().Where(
        data => data.Type == type);
      
      return filteredData.ToList();
    }

    void IRepository.UpdateStoreStock(int stockID, int amountDifference) {
      IStock stock = _store.GetListOfStoreStock().Find(data => data.ID == stockID);
      stock.UpdateStockAmount(amountDifference);
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
