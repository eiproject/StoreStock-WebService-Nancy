using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Book : Stock {
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
