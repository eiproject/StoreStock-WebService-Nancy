using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.BusinessLogic;
using StoreStock.BusinessLogic;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class MainMenuSelection : CLI{
    enum UserSelection {
      addStock = 1,
      viewStock,
      deleteStock,
      sellStock,
    }
    internal MainMenuSelection(Werehouse theStore) : base(theStore) {

    }
    internal override void InterfaceMenuSelector(int menuSelected) {
      // check selected main menu
      if (menuSelected == (int)UserSelection.addStock) {
        /*CLIManager addInterface = new AddStockInterface();*/
        CLI menu = new CLIAdd(store);
        menu.InterfaceAdd();
      }
      else if (menuSelected == (int)UserSelection.viewStock) {
        CLI menu = new CLIView(store);
        menu.InterfaceView();
      }
      else if (menuSelected == (int)UserSelection.deleteStock) {
        CLI menu = new CLIDelete(store);
        menu.InterfaceDelete();
      }
      else if (menuSelected == (int)UserSelection.sellStock) {
        CLI menu = new CLISell(store);
        menu.InterfaceSell();
      }
      else {
        Console.WriteLine("Thanks for using Store Stock.");
        store.IsRunning = false;
      }
    }
  }
}
