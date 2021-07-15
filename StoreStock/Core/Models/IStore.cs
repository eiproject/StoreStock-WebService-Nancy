using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.Models {
  interface IStore {
    void SetStoreName(string name);
    string GetStoreName();
    List<Stock> GetListOfStoreStock();
  }
}
