using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  interface IFactory {
    IStock FactoryStoreStock(string type,
  int id,
  int amount,
  string title,
  decimal price,
  string publisher,
  string genre,
  string size);
  }
}
