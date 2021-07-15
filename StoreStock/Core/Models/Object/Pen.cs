using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pen : IStock {
    private IStore _store;
    private int _id;
    private string _title;
    private int _amount;
    private decimal _price;
    private string _type;
    private string _brand;
    private string _inkColor;
    private string _lineSize;
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
    string IStock.Category => _brand;
    string IStock.SubCategory => _inkColor;
    string IStock.Size => _lineSize;
    decimal IStock.Discount => _discount;
    decimal IStock.Price => _price;
    int IStock.ID => _id;
    int IStock.Amount => _amount;
    string IStock.Type => _type;
    string IStock.Title => _title;

    void IStock.CreateStock(
      string type,
      int id,
      int amount,
      string title,
      decimal price,
      string brand,
      string subCategory,
      string size) {
      _type = "book";
      _id = id;
      _amount = amount;
      _title = title;
      _price = price;
      _brand = brand;
      _inkColor = subCategory;
      _lineSize = size;
    }
    void IStock.UpdateStockAmount(int newAmount) {
      _amount = newAmount;
    }
    internal Pen(IStore store) {
      _store = store;
    }
  }
}
