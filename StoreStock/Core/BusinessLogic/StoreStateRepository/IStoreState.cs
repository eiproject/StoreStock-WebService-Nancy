using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreState {
    Store ReadStoreObject();
    void UpdateStoreName(string name);
  }
}
