using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System.Linq;

namespace StoreStock.BusinessLogic {
  class ViewAllStock : ViewStock {
    string jsonString;
    internal ViewAllStock(Werehouse theStore) {
      Repository repo = new Repository(theStore);
      fetchedStock = repo.AllStock();
      ViewJSON viewer = new ViewJSON(fetchedStock);
    }
  }
}
