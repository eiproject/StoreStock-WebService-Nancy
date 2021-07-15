using Nancy;
using Nancy.Hosting.Self;
using System;
using StoreStockWeb.Services.BusinessLogic;
using Nancy.Bootstrapper;
using Nancy.ViewEngines;
using Nancy.TinyIoc;
using System.Reflection;
using StoreStock;
using StoreStock.Models;

namespace StoreStockWeb.Services {
  class Program {
    internal static Werehouse TheStore;
    static string _hostUri = "http://127.0.0.1:5000";
    Program() { }
    static void Main(string[] args) {
      //  Start Store Stock Services
      Run storeStock = new Run();
      storeStock.Start();
      storeStock.UseDummyData();
      TheStore = storeStock.Store;

      // creating host
      NancyHost host = new NancyHost(new Uri(_hostUri), new CustomBootstrapper());
      host.Start(); // start hosting
      Console.WriteLine($"Starting host on { _hostUri }");
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      host.Stop();  // stop hosting
    }
  }

  
}


