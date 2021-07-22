using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IFactory {
    Stock FactoryStoreStock(
      string type, int id, int amount, string title, decimal price,
  string publisher, string genre, string size);
    Store GetStore();
  }
}
