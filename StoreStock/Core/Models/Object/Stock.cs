using System;

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
    protected decimal _discount;

    /*public variables goes here*/
    public string Category => _category;
    public string SubCategory => _subCategory;
    public string Size => _size;
    public decimal Discount => GetDiscount();
    public decimal Price => _price;
    public int ID => _id;
    public int Amount => _amount;
    public string Type => _type;
    public string Title => _title;
    
    /*Method*/
    protected abstract decimal GetDiscount();
    internal abstract void UpdateStockAmount(int newAmount);

    /*The Constructor*/
    public Stock(Store store) {
      _store = store;
    }
  }
}
