using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStock {
    private int _code;
    private string _message;
    private IStock _stock;
    public int Code { get { return _code; } }
    public string Message { get { return _message; } }
    public IStock Stock { get { return _stock; } }
    internal SerializableStock(HTTPResponse response) {
      _code = response.Code;
      _message = response.Message;
    }
    internal void SetStock(IStock newStock) {
      _stock = newStock;
    }
  }
}
