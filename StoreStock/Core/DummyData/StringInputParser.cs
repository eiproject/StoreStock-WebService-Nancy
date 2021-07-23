using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  internal class StringInputParser {
    private IFactory _factory;
    private string[] _parsingData;
    internal StringInputParser(IFactory factory) {
      _factory = factory;
    }
    internal IFactory GetRpository() {
      return _factory;
    }
    internal bool Save(string inputText) {
      try {
        _parsingData = inputText.Split('#');
        Stock stock = _factory.FactoryStoreStock(
          type: _parsingData[0].ToLower(),
          id: _factory.GetStore().LastID + 1,
        amount: int.Parse(_parsingData[1]),
        title: _parsingData[3],
        price: decimal.Parse(_parsingData[2]),
        category: _parsingData[4],
        subCategory: _parsingData[5],
        size: _parsingData[6]
          );
        _factory.GetStore().AddStock(stock);
        
        return true;
      }
      catch (Exception e){
        Console.WriteLine($"--- {e}");
        return false;
      }
    }
  }
}
