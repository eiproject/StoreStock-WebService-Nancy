using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreStock.BusinessLogic;

namespace StoreStock.Models {
  public class Stock {
    private const decimal _maxDiscount = 0.3m; // max discount
    private const decimal _maxDiscountStock = 1000m; // max stock that get discount

    // internal static data
    /*internal static int countID;*/
    /*internal static List<Stock> allStock = new List<Stock>();*/

    
    private int _id;
    private string _title;
    private int _quantity;
    private decimal _price;
    private string _type;

    private decimal _discount {
      get {
        int _counter = _quantity;
        decimal percentage;
        percentage = Math.Min(decimal.Multiply(_maxDiscount, _counter / _maxDiscountStock), _maxDiscount);
        return decimal.Multiply(percentage, _price);
      }
    }
    // internal data
    internal void SetStockData(int id, string title, int quantity, decimal price, string type) {
      _id = id;
      _title = title;
      _quantity = quantity;
      _price = price;
      _type = type;
    }
    internal void RemoveSomeQuantitiy(int q) {
      _quantity -= q;
      if (_quantity < 0) {
        _quantity = 0;
      }
    }

    // All public data
    public int ID { get { return _id; } }
    public string Type { get { return _type; } }
    public int Quantity { get { return _quantity; } }
    public decimal Discount { get { return _discount; } }
    public decimal Price {
      get {
        return _price - _discount;
      }
    }
    public string Title { get { return _title; } }
    public Stock() {}
  }
}
