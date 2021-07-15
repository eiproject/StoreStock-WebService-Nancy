using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;
using StoreStock.BusinessLogic;

namespace StoreStock.BusinessLogic {
  class SavingProcess {
    int currentID;
    internal List<Stock> currentStocks;
    Werehouse store;
    internal SavingProcess(Werehouse theStore) {
      currentStocks = theStore.WerehouseData;

      if (currentStocks.Count != 0) {
        currentID = theStore.WerehouseData[currentStocks.Count - 1].ID + 1;
      }
      else {
        currentID = 0;
      }

      store = theStore;
    }
    internal void SaveData(
      string type, int quantity, decimal price,
      string title, string genreOrBrand, string size) {
      if (type.ToLower() == "book") {
        // singleton error during inheritance 
        // book reference never changed (duplicated data)

        /*Book newBook = new Book {
          genre = genre_or_brand,
          paperSize = size
        };*/

        // Book newBook = Book.GetInstance(genreOrBrand, size);
        Book newBook = new Book();
        newBook.SetBookData(genreOrBrand, size);
        newBook.SetStockData(currentID, title, quantity, price, type);

        Stock newStock = newBook;
        Repository repo = new Repository(store);
        repo.AddMoreStock(newStock);
      }
      else if (type.ToLower() == "pencil") {
        Pencil newPencil = new Pencil();
        newPencil.SetPencilData(genreOrBrand, size);
        newPencil.SetStockData(currentID, title, quantity, price, type);

        Stock newStock = newPencil;
        Repository repo = new Repository(store);
        repo.AddMoreStock(newStock);
      }
      else {
        Console.WriteLine("Failed to save data.");
      }
    }

    internal void SaveData(
      string type, int quantity, decimal price,
      string title, string brand, string inkColor, string linesize) {
      Pen newPen = new Pen();
      newPen.SetPenData(brand, inkColor, linesize);
      newPen.SetStockData(currentID, title, quantity, price, type);

      Stock newStock = newPen;
      Repository repo = new Repository(store);
      repo.AddMoreStock(newStock);
    }
  }

}
