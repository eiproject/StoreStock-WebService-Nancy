using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStoreStock {
    private int _code;
    private string _message;
    private string _storeName;
    private List<IStock> _storeData;
    public int Code { get { return _code; } }
    public string Message { get { return _message; } }
    public string StoreName { get { return _storeName; } }
    public List<IStock> StoreData { get { return _storeData; } }
    internal SerializableStoreStock(HTTPResponse response) {
      _code = response.Code;
      _message = response.Message;
    }
    internal void SetStoreName(string name) {
      _storeName = name;
    }
    internal void SetStoreData(List<IStock> listOfIStock) {
      _storeData = listOfIStock;
    }
  }
}
