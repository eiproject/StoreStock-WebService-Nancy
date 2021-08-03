using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStoreObject();
    Store UpdateStoreName(string name);
    void ChangeStateToInit();
    void ChangeStateToRun();
    void ChangeStateToStop();
  }
}
