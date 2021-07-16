using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStock {
    private HTTPResponse _response;
    private IStock _stock;
    public int Code { get { return _response.Code; } }
    public string Message { get { return _response.Message; } }
    public IStock Stock { get { return _stock; } }
    internal SerializableStock(HTTPResponse response) {
      _response = response;
    }
    internal void SetStock(IStock newStock) {
      _stock = newStock;
    }
  }
}
