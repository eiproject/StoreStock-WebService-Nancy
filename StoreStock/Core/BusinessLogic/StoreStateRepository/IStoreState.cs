using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreState {
    Store ReadStore();
    void UpdateStoreName(string name);
  }
}
