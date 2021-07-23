using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  enum GenerateCondition {
    OK,
    SomeDataMissing,
    DataOverload,
    NothingSaved
  }
  class GenerateDummyData {
    private string[] _testInput;
    private StringInputParser _parser;

    internal GenerateDummyData(StringInputParser parser) {
      _parser = parser;
    }
    internal GenerateCondition Generate() {
      int savedData = 0;
      _testInput = new string[] {
        "Book#100#895000#Magic Tree House Boxed Set, Books 1-4#Dongeng# #A5",
        "PENcil#210#49800#Conte Pieree Noire#Conte# #3B",
        "BOOK#10#105900#It Ends with Us#Novel# #A5",
        "pencil#300#5400#Drawing Pencil Joyko#Joyko# #2B",
        "PEN#2120#51000#Pilot Pen Mr 2 Metropolitan#Pilot#Black#0.5"
      };

      foreach (string t in _testInput) {
        bool isSaved = _parser.Save(t);
        if (isSaved) { savedData++; }
      }
      if (savedData == _testInput.Length) {
        return GenerateCondition.OK;
      }
      else if (savedData < _testInput.Length) {
        return GenerateCondition.SomeDataMissing;
      }
      else if (savedData > _testInput.Length) {
        return GenerateCondition.DataOverload;
      }
      else if (savedData == 0) {
        return GenerateCondition.NothingSaved;
      }
      else {
        return GenerateCondition.NothingSaved;
      }
    }
  }
}
