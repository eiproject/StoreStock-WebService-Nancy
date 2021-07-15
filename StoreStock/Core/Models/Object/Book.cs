using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Book : IStock {
    private IStore _store;
    private int _id;
    private string _title;
    private int _amount;
    private decimal _price;
    private string _type;
    private string _publisher;
    private string _genre;
    private string _paperSize;
    private decimal _discount {
      get {
        int _counter = _amount;
        decimal percentage;
        percentage = Math.Min(
          decimal.Multiply(
            _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
        return decimal.Multiply(percentage, _price);
      }
    }
    string IStock.Category => _publisher;
    string IStock.SubCategory => _genre;
    string IStock.Size => _paperSize;
    decimal IStock.Discount => _discount;
    decimal IStock.Price => _price;
    int IStock.ID => _id;
    int IStock.Amount => _amount;
    string IStock.Type => _type;
    string IStock.Title => _title;

    void IStock.UpdateStockInformation(
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
      _amount = newAmount;
    }
    internal Book(IStore store) {
      _store = store;
    }
  }
}
