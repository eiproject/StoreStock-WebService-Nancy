using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  public class Store : IStore{
    private List<Stock> _storeData;
    private string _storeName = "no-name";
    private const decimal _maxDiscount = 0.3m; // max discount
    private const decimal _maxAmountThatGetDiscount = 1000m; // max stock that get discount
    internal Store(string storeName) {
      _storeData = new List<Stock>();
      _storeName = storeName;
    }
    decimal IStore.MaxDiscount { get {return _maxDiscount; } }
    decimal IStore.MaxAmountThatGetDiscount { get { return _maxAmountThatGetDiscount; } }
    string IStore.GetStoreName() {
      return _storeName;
    }
    int IStore.GetLastId() {
      if (_storeData.Count > 0) {
        return _storeData[_storeData.Count - 1].ID;
      }
      else {
        return -1;
      }
    }
    List<Stock> IStore.GetListOfStoreStock() {
      return _storeData;
    }
    void IStore.AddStock(Stock newStock) {
      _storeData.Add(newStock);
    }

    void IStore.RemoveStock(Stock stock) {
      _storeData.Remove(stock);
    }
  }
}