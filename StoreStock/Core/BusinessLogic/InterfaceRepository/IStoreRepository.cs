using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStore();
    Store UpdateStore(string name);
    void StateToInit();
    void StateToRun();
    void StateToStop();
  }
}
