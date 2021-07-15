using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class JSONParser {
    private StringBuilder _jsonStrings = new StringBuilder();
    public StringBuilder JsonStrings { get { return _jsonStrings; } }

    private List<Stock> _stockData;
    internal JSONParser(List<Stock> stockData) {
      _stockData = stockData;
      }
    internal string ListStockToJSON() {
      foreach (Stock data in _stockData) {
        AutomaticObjectConverter converter = new AutomaticObjectConverter(data);
        string _jsonString = JsonSerializer.Serialize(converter.ConvertedObject);
        _jsonStrings.Append(_jsonString);
        Console.WriteLine(_jsonString);
      }
      return JsonSerializer.Serialize(_jsonStrings);
    }
  }
}
