using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class CLIAdd : CLI {
    internal CLIAdd(Werehouse theStore) : base(theStore) {
    }

    internal override void InterfaceAdd() {
      Console.WriteLine(
@"Input Format: 
- Book#Stock amount#Price#Stock title#Genre#Size
- Pen#Stock amount#Price#Stock title#Brand#Ink color#Size
- Pencil#Stock amount#Price#Stock title#Brand#Size
Your input:"
      );
      string userInput = Console.ReadLine();
      try {
        StringInputParser userInputObj = new StringInputParser(userInput, store);
      }
      catch {
        Console.WriteLine("Wrong input. \n");
      }
    }
  }
}
