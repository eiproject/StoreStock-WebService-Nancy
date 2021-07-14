using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;
using StoreStock.BusinessLogic;

namespace StoreStock.BusinessLogic {
  class CLISell : CLI{
    internal CLISell(Werehouse theStore) : base(theStore) {
    }
    internal override void InterfaceSell() {
      Console.WriteLine("Enter Specific ID to sell: ");
      string idInput = Console.ReadLine();
      Console.WriteLine("How many? ");
      string amountInput = Console.ReadLine();
      int intIdInput = int.TryParse(idInput, out intIdInput) ? intIdInput : 0;
      int intAmountInput = int.TryParse(amountInput, out intAmountInput) ? intAmountInput : 0;
      Repository sell = new Repository(store);
      sell.SellStock(intIdInput, intAmountInput);
    }
  }
}
