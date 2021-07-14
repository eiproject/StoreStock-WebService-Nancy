using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  /*interface ICLI {
    void InterfaceMenu();
    void InterfaceMenuSelector(int menuSelected);
    void InterfaceAdd();
    *//*void InterfaceBuy();*//*
    void InterfaceDelete();
    void InterfaceSell();
    void InterfaceView();
  }*/

  class CLI {
    internal Werehouse store;
    internal CLI(Werehouse theStore) {
      store = theStore;
    }
    internal virtual void InterfaceMenu() { }
    internal virtual void InterfaceMenuSelector(int menuSelected){ }
    internal virtual void InterfaceAdd(){ }
    /*void InterfaceBuy(){ }*/
    internal virtual void InterfaceDelete(){ }
    internal virtual void InterfaceSell(){ }
    internal virtual void InterfaceView(){ }
  }
}
