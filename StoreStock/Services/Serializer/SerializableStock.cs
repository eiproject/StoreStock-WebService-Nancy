using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStock {
    private Stock _stock;
    public Stock Data { get { return _stock; } }
    internal SerializableStock() { }
    internal void SetStock(Stock newStock) {
      _stock = newStock;
    }
  }
}
