using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class GenerateDummyData {
    private string[] _testInput;
    private IRepository _repository;
    internal GenerateDummyData(IRepository repository) {
      _repository = repository;
    }
    internal void Generate() {
      _testInput = new string[] {
        "Book#100#895000#Magic Tree House Boxed Set, Books 1-4#Dongeng# #A5",
        "PENcil#210#49800#Conte Pieree Noire#Conte# #3B",
        "BOOK#10#105900#It Ends with Us#Novel# #A5",
        "pencil#300#5400#Drawing Pencil Joyko#Joyko# #2B",
        "PEN#2120#51000#Pilot Pen Mr 2 Metropolitan#Pilot#Black#0.5"
      };

      foreach (string t in _testInput) {
        StringInputParser parser = new StringInputParser(_repository);
        parser.Save(t);
      }
    }
  }
}
