using System;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  internal class StringInputParser {
    Store _store;
    private IFactory _factory;
    private string[] _parsingData;
    internal StringInputParser(Store store, IFactory factory) {
      _store = store;
      _factory = factory;
    }
    internal IFactory GetRpository() {
      return _factory;
    }
    internal bool Save(string inputText) {
      try {
        _parsingData = inputText.Split('#');
        Stock stock = _factory.FactoryStock(
          type: _parsingData[0],
          id: _store.LastIdInStocks + 1,
        amount: int.Parse(_parsingData[1]),
        title: _parsingData[3],
        price: decimal.Parse(_parsingData[2]),
        category: _parsingData[4],
        subCategory: _parsingData[5],
        size: _parsingData[6]
          );
        _store.AppendStocksByStock(stock);
        
        return true;
      }
      catch (Exception e){
        Console.WriteLine($"--- {e}");
        return false;
      }
    }
  }
}
