using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class ModelStock {
    private SerializableStock _serializedStock;
    public SerializableStock SerializedStock { get { return _serializedStock; } }
    internal ModelStock(SerializableStock serializedStock) {
      _serializedStock = serializedStock;
    }
  }
}
