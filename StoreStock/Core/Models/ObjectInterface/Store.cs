using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  public class Store {
    private List<Stock> _storeData;
    private string _storeName = "no-name";
    private const decimal _maxDiscount = 0.3m; // max discount
    private const decimal _maxAmountThatGetDiscount = 1000m; // max stock that get discount
    public string StoreName { get { return _storeName; } }
    public decimal MaxDiscount { get { return _maxDiscount; } }
    public decimal MaxAmountThatGetDiscount { get { return _maxAmountThatGetDiscount; } }
    public List<Stock> StoreData { get { return _storeData; } }
    public int LastID {
      get {
        if (_storeData.Count > 0) {
          return _storeData[_storeData.Count - 1].ID;
        }
        else {
          return -1;
        }
      }
    }
    public void AddStock(Stock newStock) {
      _storeData.Add(newStock);
    }
    public void RemoveStock(Stock stock) {
      _storeData.Remove(stock);
    }
    internal Store(string storeName) {
      _storeData = new List<Stock>();
      _storeName = storeName;
    }
  }
}