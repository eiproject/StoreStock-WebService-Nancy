using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStore();
    Store UpdateStore(string name);
    void Init();
    void Run();
    void Stop();
  }
}
