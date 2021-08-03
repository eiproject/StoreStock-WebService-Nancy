using System;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class Factory : IFactory {
    private Stock _newStock;
    private Store _store;
    internal Factory(Store store) {
      _store = store;
    }
    Stock IFactory.FactoryOneStock(
      string type, int id, int amount, string title, decimal price,
      string category, string subCategpry, string size) {

      if (type.ToLower() == "book") {
        _newStock = new Book(_store, id, amount, title, price, category, subCategpry, size);
      }
      else if (type.ToLower() == "pen") {
        _newStock = new Pen(_store, id, amount, title, price, category, subCategpry, size);
      }
      else if (type.ToLower() == "pencil") {
        _newStock = new Pencil(_store, id, amount, title, price, category, subCategpry, size);
      }
      else {
        Console.WriteLine("Type UNVALID");
      }
      return _newStock;
    }

    Store IFactory.GetStore() {
      return _store;
    }
  }
}
