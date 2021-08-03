using System.Collections.Generic;

namespace StoreStock.Models {
  public class Store {
    private List<Stock> _stocks;
    private string _storeName = "no-name";
    private const decimal _maxDiscountPrice = 0.3m; // max discount
    private const decimal _maxAmountThatGetDiscount = 1000m; // max stock that get discount
    public string StoreName { get { return _storeName; } }
    public decimal MaxDiscountPrice { get { return _maxDiscountPrice; } }
    public decimal MaxAmountThatGetDiscount { get { return _maxAmountThatGetDiscount; } }
    public List<Stock> Stocks { get { return _stocks; } }
    public int LastID {
      get {
        if (_stocks.Count > 0) {
          return _stocks[_stocks.Count - 1].ID;
        }
        else {
          return -1;
        }
      }
    }
    public void AddStock(Stock newStock) {
      _stocks.Add(newStock);
    }
    public void RemoveStock(Stock stock) {
      _stocks.Remove(stock);
    }
    public void CleanStock() {
      _stocks.Clear();
    }
    public void UpdateName(string name) {
      _storeName = name;
    }
    internal Store(string storeName) {
      _stocks = new List<Stock>();
      _storeName = storeName;
    }
  }
}