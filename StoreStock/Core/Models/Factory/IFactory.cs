using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IFactory {
    Stock FactoryStoreStock(
      string type, int id, int amount, string title, decimal price,
  string category, string subCategory, string size);
    Store GetStore();
  }
}
