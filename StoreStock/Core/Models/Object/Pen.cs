using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pen : Stock {
    protected override decimal GetDiscount() {
      int _counter = _amount;
      decimal percentage;
      percentage = Math.Min(
        decimal.Multiply(
          _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
      return decimal.Multiply(percentage, _price);
    }

    internal override void UpdateStockAmount(int newAmount) {
      _amount += newAmount;
    }
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
