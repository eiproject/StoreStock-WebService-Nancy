﻿using System.Collections.Generic;

namespace StoreStock.Models {
  public interface Store {
    decimal MaxDiscount { get; }
    decimal MaxAmountThatGetDiscount { get; }
    string GetStoreName();
    int GetLastId();
    List<Stock> GetListOfStoreStock();
    void AddStock(Stock stock);
    void RemoveStock(Stock stock);
  }
}