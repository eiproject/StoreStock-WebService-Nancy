using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class ModelStoreStock {
    private SerializableStoreStock _storeStockData;
    public SerializableStoreStock StoreStockData { get { return _storeStockData; } }
    internal ModelStoreStock(SerializableStoreStock serializedStoreStock) {
      _storeStockData = serializedStoreStock;
    }
  }
}
