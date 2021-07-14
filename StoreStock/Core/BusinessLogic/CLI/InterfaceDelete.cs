using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;
using StoreStock.BusinessLogic;

namespace StoreStock.BusinessLogic {
  class CLIDelete : CLI{
    internal CLIDelete(Werehouse theStore) : base(theStore) {
    }
    internal override void InterfaceDelete() {
      Console.WriteLine("Enter Specific ID to delete: ");
      string idInput = Console.ReadLine();
      int intIdInput = int.TryParse(idInput, out intIdInput) ? intIdInput : 0;
      Repository del = new Repository(store);
      del.DeleteStock(intIdInput);
    }
  }
}
