using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Book : Stock {


    /*    void IStock.UpdateStockInformation(
          string type,
          int id,
          int amount,
          string title,
          decimal price,
          string publisher,
          string genre,
          string size) {
          _type = "book";
          _id = id;
          _amount = amount;
          _title = title;
          _price = price;
          _publisher = publisher;
          _genre = genre;
          _paperSize = size;
        }
        void IStock.UpdateStockAmount(int newAmount) {
          _amount += newAmount;
        }*/
    internal Book(Store store, int id, int amount, string title,
          decimal price, string publisher, string genre, string size) : base(store){
      _store = store;
      _type = "book";
      _id = id;
      _amount = amount;
      _title = title;
      _price = price;
      _category = publisher;
      _subCategory = genre;
      _size = size;
    }
  }
}
