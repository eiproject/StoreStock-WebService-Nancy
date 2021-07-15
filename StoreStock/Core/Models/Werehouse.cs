using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  public class Werehouse {
    private List<Stock> _werehouseData;
    private string _storeName;
    internal Werehouse() {
      _werehouseData = new List<Stock>();
    }
    internal List<Stock> WerehouseData { get { return _werehouseData; } }
    internal void SetStoreName(string name) {
      _storeName = name;
    }
    internal string GetStoreName() {
      return _storeName;
    }
  }
}


// Singleton Pattern
/*namespace StoreStock.Models {
  public class Werehouse {
    private static object _myLock = new object(); // threadsafe
    private static Werehouse _store;

    private List<Stock> _werehouseData;
    private Werehouse() {
      _werehouseData = new List<Stock>();
    }

    internal bool IsRunning = true;
    public List<Stock> WerehouseData { get { return _werehouseData; } }
    public static Werehouse GetInstance() {

      if (_store == null) {
        // threadsafe
        lock (_myLock) {
          if (_store == null) {
            _store = new Werehouse();
          }
        }
      }
      return _store;
    }
  }
}
*/