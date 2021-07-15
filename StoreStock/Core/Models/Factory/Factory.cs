using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.Models {
  class Factory : IFactory {
    private IStock _newStock;
    private IStore _store;
    internal Factory(IStore store) {
      _store = store;
    }
    IStock IFactory.FactoryStoreStock(
      string type, int id, int amount, string title, decimal price,
      string publisher, string genre, string size) {

      if (type.ToLower() == "book") {
        _newStock = new Book(_store);
        _newStock.UpdateStockInformation(
      type, id, amount, title, price, publisher, genre, size);
      }
      else if (type.ToLower() == "pen") {
        _newStock = new Pen(_store);
        _newStock.UpdateStockInformation(
      type, id, amount, title, price, publisher, genre, size);
      }
      else if (type.ToLower() == "pencil") {
        _newStock = new Pencil(_store);
        _newStock.UpdateStockInformation(
      type, id, amount, title, price, publisher, genre, size);
      }
      else {
        Console.WriteLine("Type UNVALID");
      }
      return _newStock;
    }
  }
}
