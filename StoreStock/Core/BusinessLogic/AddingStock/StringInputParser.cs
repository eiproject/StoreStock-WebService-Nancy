using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  internal class StringInputParser {
    internal StringInputParser(string inputText, Store theStore) {
      /*Console.WriteLine("inputText: " + inputText);*/
      string[] data = inputText.Split('#');
      SavingProcess newStock = new SavingProcess(theStore);
      if (data.Length == 6) {
        newStock.SaveData(
        data[0].ToLower(), int.Parse(data[1]), decimal.Parse(data[2]),
        data[3], data[4], data[5]
        );
      }
      else if (data.Length == 7) {
        newStock.SaveData(
        data[0].ToLower(), int.Parse(data[1]), decimal.Parse(data[2]),
        data[3], data[4], data[5], data[6]
        );
      }
      else {
        Console.WriteLine("Wrong input data. \n");
      }
    }
  }
}
