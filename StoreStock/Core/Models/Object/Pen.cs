using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pen : Stock {
    internal Pen(Store store, int id, int amount, string title, decimal price,
      string brand, string color, string size) : base(store) {
      _store = store;
      _type = "pen";
      _id = id;
      _amount = amount;
      _title = title;
      _price = price;
      _category = brand;
      _subCategory = color;
      _size = size;
    }
  }
}
