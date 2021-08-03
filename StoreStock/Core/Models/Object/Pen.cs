using System;

namespace StoreStock.Models {
  class Pen : Stock {
    protected override decimal GetDiscountPrice() {
      int _counter = _amount;
      decimal percentage;
      percentage = Math.Min(
        decimal.Multiply(
          _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
      return decimal.Multiply(percentage, _price);
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

      _sku = $"pen-{_category.ToLower()}-{_id}";
    }
  }
}
