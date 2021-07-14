using System;
using System.Collections.Generic;
using System.Text;
// using System.Text.Json;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class ViewJSON {
    List<string> jsonStrings = new List<string>();
    internal List<string> JsonStrings { get { return jsonStrings; } }
    internal ViewJSON(List<Stock> stockData) {
      foreach (Stock data in stockData) {
        AutomaticObjectConverter converter = new AutomaticObjectConverter(data);
        string _jsonString = " ";// JsonSerializer.Serialize(converter.ConvertedObject);
        jsonStrings.Add(_jsonString);
        Console.WriteLine(_jsonString);
      }
    }
  }
}
