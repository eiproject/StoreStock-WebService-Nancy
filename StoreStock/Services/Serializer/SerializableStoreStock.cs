using StoreStock.Models;
using System;
using System.Collections.Generic;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStoreStock {
    private HTTPResponse _response;
    private string _storeName;
    private List<IStock> _storeData;
    public int Code { get { return _response.Code; } }
    public string Message { get { return _response.Message; } }
    public string StoreName { get { return _storeName; } }
    public List<IStock> StoreData { get { return _storeData; } }
    internal SerializableStoreStock(HTTPResponse response) {
      _response = response;
    }
    internal void SetStoreName(string name) {
      _storeName = name;
    }
    internal void SetStoreData(List<IStock> listOfIStock) {
      _storeData = listOfIStock;
    }
  }
}
