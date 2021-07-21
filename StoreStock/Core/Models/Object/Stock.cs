using System;

namespace StoreStock.Models {
  public class Stock {
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

    /*public variables goes here*/
    public string Category => _category;
    public string SubCategory => _subCategory;
    public string Size => _size;
    public decimal Discount => _discount;
    public decimal Price => _price;
    public int ID => _id;
    public int Amount => _amount;
    public string Type => _type;
    public string Title => _title;
    
    // Method
    internal void UpdateStockAmount(int newAmount) {
      _amount += newAmount;
    }
    /*The Constructor*/
    public Stock(Store store) {
      _store = store;
    }
  }
}
