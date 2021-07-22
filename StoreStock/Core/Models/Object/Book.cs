using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Book : Stock {
    protected override decimal GetDiscount() {
      int _counter = _amount;
      decimal percentage;
      percentage = Math.Min(
        decimal.Multiply(
          _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
      return decimal.Multiply(percentage, _price);
    }

    protected override void UpdateStockAmount(int newAmount) {
      _amount += newAmount;
    }

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
