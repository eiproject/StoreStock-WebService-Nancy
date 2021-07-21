using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  interface IStoreRepository {
    List<Stock> ReadStoreStock();
  }
}
