using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class SerializableStock {
    private IStock _stock;
    public IStock Stock { get { return _stock; } }
    internal SerializableStock() { }
    internal void SetStock(IStock newStock) {
      _stock = newStock;
    }
  }
}
