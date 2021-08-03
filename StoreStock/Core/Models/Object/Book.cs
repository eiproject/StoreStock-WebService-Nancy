using System;

namespace StoreStock.Models {
  class Book : Stock {
    protected override decimal GetDiscountPrice() {
      int _counter = _amount;
      decimal percentage;
      percentage = Math.Min(
        decimal.Multiply(
          _store.MaxDiscountPrice, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscountPrice);
      return decimal.Multiply(percentage, _price);
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

      _sku = $"book-{_category.ToLower()}-{_id}";
    }
  }
}
