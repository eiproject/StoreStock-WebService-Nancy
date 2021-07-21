using StoreStock.Models;
using System;
using System.Collections.Generic;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStoreStock {
    private string _storeName;
    private List<Stock> _storeData;
    public string Name { get { return _storeName; } }
    public List<Stock> Data { get { return _storeData; } }
    internal SerializableStoreStock() { }
    internal void SetStoreName(string name) {
      _storeName = name;
    }
    internal void SetStoreData(List<Stock> listOfIStock) {
      _storeData = listOfIStock;
    }
  }
}
