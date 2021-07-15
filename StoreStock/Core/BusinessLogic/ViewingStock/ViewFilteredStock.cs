using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System.Linq;

namespace StoreStock.BusinessLogic {
  class ViewFilteredStock : ViewStock {
    string jsonString;
    internal ViewFilteredStock(string className, Store theStore) {
      Repository repo = new Repository(theStore);
      fetchedStock = repo.AllStock();
      IEnumerable<Stock> filteredData = fetchedStock.Where(
        data => data.Type == className);
      fetchedStock = filteredData.ToList();
      JSONParser viewer = new JSONParser(fetchedStock);
    }
  }
}
