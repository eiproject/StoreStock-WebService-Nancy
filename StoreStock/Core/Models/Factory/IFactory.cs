using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IFactory {
    Stock FactoryOneStock(
      string type, int id, int amount, string title, decimal price,
  string category, string subCategory, string size);
    Store GetStore();
  }
}
