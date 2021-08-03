using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStoreObjectUsingState();
    Store UpdateStoreNameUsingState(string name);
    void ChangeStateToInit();
    void ChangeStateToRun();
    void ChangeStateToStop();
  }
}
