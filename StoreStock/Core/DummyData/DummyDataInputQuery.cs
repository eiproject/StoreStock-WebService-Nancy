using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.BusinessLogic {
  internal static class DummyDataInputQuery {
    internal static string StockTypeToLower(this string query) {
      string[] querySplitted = query.Split('#');
      querySplitted[0].ToLower();
      string result = String.Join("#", querySplitted);
      return result;
    }
  }
}
