using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace StoreStockWebServices.BusinessLogic {
  public class MainModule : NancyModule {
    public MainModule() {
/*      Get["/"] = x => {
        Console.WriteLine("index API");
        return "Hello World!";
      };*/
      Get["/"] = x =>
      {
        return View["index.html"];
      };
    }
  }
}
