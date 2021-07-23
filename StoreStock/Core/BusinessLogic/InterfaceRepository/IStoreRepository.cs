using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStore();
    Store UpdateStore(string name);
    bool Init();
    bool Run();
    bool Stop();
  }
}
