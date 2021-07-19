using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  public abstract class Stock {
    protected Store _store;
    protected int _id;
    protected string _title;
    protected int _amount;
    protected decimal _price;
    protected string _type;
    protected string _category;
    protected string _subCategory;
    protected string _size;
    protected decimal _discount {
      get {
        int _counter = _amount;
        decimal percentage;
        percentage = Math.Min(
          decimal.Multiply(
            _store.MaxDiscount, _counter / _store.MaxAmountThatGetDiscount), _store.MaxDiscount);
        return decimal.Multiply(percentage, _price);
      }
    }
    public string Category => _category;
    public string SubCategory => _subCategory;
    public string Size => _size;
    public decimal Discount => decimal.Round(_discount, 2);
    public decimal Price => _price;
    public int ID => _id;
    public int Amount => _amount;
    public string Type => _type;
    public string Title => _title;

/*    void UpdateStockInformation(
  string type,
  int id,
  int amount,
  string title,
  decimal price,
  string brand,
  string subCategory,
  string size) {
      UpdateStockInformation(type, id, amount, title, price, brand, subCategory, size);
    }*/

    internal abstract void UpdateStockInformation(
      string type,
      int id,
      int amount,
      string title,
      decimal price,
      string brand,
      string subCategory,
      string size);

    internal void UpdateStockAmount(int newAmount) {
      _amount += newAmount;
    }
    internal Stock(Store store) {
      _store = store;
    }
  }
}
