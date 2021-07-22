using StoreStock.Models;
using System.Collections.Generic;

namespace StoreStock.BusinessLogic {
  public interface IStoreState {
    List<Stock> ReadStoreStock();
    void UpdateStore(string name);
  }
}
