using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  public class Store : IStore{
    private List<IStock> _werehouseData;
    private string _storeName = "no-name";
    private const decimal _maxDiscount = 0.3m; // max discount
    private const decimal _maxAmountThatGetDiscount = 1000m; // max stock that get discount
    internal Store() {
      _werehouseData = new List<IStock>();
    }
    decimal IStore.MaxDiscount { get {return _maxDiscount; } }
    decimal IStore.MaxAmountThatGetDiscount { get { return _maxAmountThatGetDiscount; } }
    void IStore.SetStoreName(string storeName) {
      _storeName = storeName;
    }
    string IStore.GetStoreName() {
      return _storeName;
    }
    List<IStock> IStore.GetListOfStoreStock() {
      return _werehouseData;
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