using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class CLIMenu : CLI {
    internal bool loopCondition = true;
    int menuSelected;
    string mainMenu =
@"Welcome to Main Menu
1. Add Stock
2. View Stock
3. Delete Stock
4. Sell Stock;
99. Exit
Choose menu:";
    string strChoosenMainMenu;
    internal CLIMenu(Werehouse theStore) : base(theStore) {

    }
    internal override void InterfaceMenu() {
      // Generate main manu
      Console.WriteLine(mainMenu);
      strChoosenMainMenu = Console.ReadLine();
      menuSelected = int.TryParse(strChoosenMainMenu, out menuSelected) ? menuSelected : 0;

      // CLI to function 
      CLI toFunction = new MainMenuSelection(store);
      toFunction.InterfaceMenuSelector(menuSelected);
    }
  }
}
