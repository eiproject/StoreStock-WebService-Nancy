using Nancy.Hosting.Self;
using System;
using StoreStock.BusinessLogic;

namespace StoreStockWeb.Services {
  class Program {
    static string _hostUri = "http://127.0.0.1:5000";
    Program() {

    }
    static void Main(string[] args) {
      Console.WriteLine("Welcome to Store Stock \n.");
      Bootstrapper bootstrapper = new Bootstrapper();
      NancyHost host = new NancyHost(new Uri(_hostUri), bootstrapper);

      host.Start(); // start hosting
      Console.WriteLine($"Host started on { _hostUri }");

      Console.WriteLine("\nPress any key to initialize data.");
      Console.ReadKey();
      
      StateManager.Init();
      StateManager.Run();
      
      Console.WriteLine("\nPress any key to shutting down.");
      Console.ReadKey();

      // Application state manager
      StateManager.Stop();

      Console.WriteLine("Please any key to exit.");
      Console.ReadKey();
      host.Stop();  // stop hosting
    }
  }
}