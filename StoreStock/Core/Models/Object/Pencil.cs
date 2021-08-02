using System;

namespace StoreStock.Models {
  class Pencil : Stock {
    protected override decimal GetDiscount() {
      int _counter = _amount;
      decimal percentage;
      percentage = Math.Min(
        decimal.Multiply(
          _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
      return decimal.Multiply(percentage, _price);
    }

    internal Pencil(Store store, int id,
      int amount,
      string title,
      decimal price,
      string brand,
      string color,
      string size) : base(store) {
      _store = store;
      _type = "pencil";
      _id = id;
      _amount = amount;
      _title = title;
      _price = price;
      _category = brand;
      _subCategory = color;
      _size = size;

      _sku = $"pencil-{_category.ToLower()}-{_id}";
    }
  }
}
