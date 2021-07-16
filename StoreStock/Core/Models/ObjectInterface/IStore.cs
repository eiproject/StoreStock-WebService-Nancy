using System.Collections.Generic;

namespace StoreStock.Models {
  interface IStore {
    decimal MaxDiscount { get; }
    decimal MaxAmountThatGetDiscount { get; }
    string GetStoreName();
    int GetLastId();
    List<IStock> GetListOfStoreStock();
    void AddStock(IStock stock);
    void RemoveStock(IStock stock);
  }
}
