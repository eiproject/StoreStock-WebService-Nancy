using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class CLIView : CLI{
    int choosenNumber;
    string userInput;
    string menu =
@"Choose data: 
1. All data
2. Book
3. Pencil
4. Pen
Your input:";
    enum dataType {
      all = 1,
      book,
      pencil,
      pen
    }
    internal CLIView(Werehouse theStore) : base(theStore) {
    }

    internal override void InterfaceView() {
      Console.WriteLine(menu);
      userInput = Console.ReadLine();
      /*int choosenNumber = int.Parse(userInput);*/
      choosenNumber = int.TryParse(userInput, out choosenNumber) ? choosenNumber : 0;

      if (choosenNumber == (int)dataType.all) {
        ViewStock fetchedStock = new ViewAllStock(store);
      }
      else if (choosenNumber == (int)dataType.book) {
        ViewStock fetchedStock = new ViewFilteredStock("book", store);
      }
      else if (choosenNumber == (int)dataType.pencil) {
        ViewStock fetchedStock = new ViewFilteredStock("pencil", store);
      }
      else if (choosenNumber == (int)dataType.pen) {
        ViewStock fetchedStock = new ViewFilteredStock("pen", store);
      }
      else {
        Console.WriteLine("Wrong input number. \n");
      }
    }
  }
}
