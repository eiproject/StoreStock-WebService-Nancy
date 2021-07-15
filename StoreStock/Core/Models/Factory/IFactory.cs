using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.Models {
  interface IFactory {
    IStock FactoryStoreStock(string type,
  int id,
  int amount,
  string title,
  decimal price,
  string publisher,
  string genre,
  string size);
  }
}
