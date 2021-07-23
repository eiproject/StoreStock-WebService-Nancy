using StoreStock.Models;
using System.Collections.Generic;

namespace StoreStock.BusinessLogic {
  public interface IStoreState {
    Store ReadStore();
    void UpdateStore(string name);
    bool IsSuccess { get; }
  }
}
