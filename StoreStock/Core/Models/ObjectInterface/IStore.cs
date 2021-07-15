using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.Models {
  interface IStore {
    decimal MaxDiscount { get; }
    decimal MaxAmountThatGetDiscount { get; }
    void SetStoreName(string name);
    string GetStoreName();
    List<IStock> GetListOfStoreStock();
  }
}
