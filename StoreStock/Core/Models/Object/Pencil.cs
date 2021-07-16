using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pencil : IStock {
    private IStore _store;
    private int _id;
    private string _title;
    private int _amount;
    private decimal _price;
    private string _type;
    private string _brand;
    private string _subCategory;
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
    public string Category => _brand;
    public string SubCategory => _subCategory;
    public string Size => _lineSize;
    public decimal Discount => _discount;
    public decimal Price => _price;
    public int ID => _id;
    public int Amount => _amount;
    public string Type => _type;
    public string Title => _title;

    void IStock.UpdateStockInformation(
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
      _subCategory = subCategory;
      _lineSize = size;
    }
    void IStock.UpdateStockAmount(int newAmount) {
      _amount += newAmount;
    }
    internal Pencil(IStore store) {
      _store = store;
    }
  }
}
