using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System.Linq;

namespace StoreStock.BusinessLogic {
  class ViewAllStock : ViewStock {
    string jsonString;
    internal ViewAllStock(Store theStore) {
      Repository repo = new Repository(theStore);
      fetchedStock = repo.AllStock();
      JSONParser viewer = new JSONParser(fetchedStock);
    }
  }
}
