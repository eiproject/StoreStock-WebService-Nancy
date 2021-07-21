using StoreStock.Models;
using System;
using System.Collections.Generic;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStoreStock {
    private string _storeName;
    private List<IStock> _storeData;
    public string StoreName { get { return _storeName; } }
    public List<IStock> StoreData { get { return _storeData; } }
    internal SerializableStoreStock() { }
    internal void SetStoreName(string name) {
      _storeName = name;
    }
    internal void SetStoreData(List<IStock> listOfIStock) {
      _storeData = listOfIStock;
    }
  }
}
