using Nancy.Hosting.Self;
using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using TinyIoC;
using Nancy.TinyIoc;

namespace StoreStockWeb.Services {
  class Program {
    static string _hostUri = "http://127.0.0.1:5000";
    Program() {

    }
    static void Main(string[] args) {
      Console.WriteLine("Welcome to Store Stock \n.");
      Bootstrapper bootstrapper = new Bootstrapper();
      NancyHost host = new NancyHost(new Uri(_hostUri), bootstrapper);

      var something = TinyIoC.TinyIoCContainer.Current;
      host.Start(); // start hosting
      Console.WriteLine($"Host started on { _hostUri }");

      Console.WriteLine("\nPress any key to initialize data.");
      Console.ReadKey();
      Console.WriteLine("\nInitializing data...");
      StateControl.Init();
      Console.WriteLine("Initializing, OK.");

/*      Console.WriteLine("\nPress any key to start.");
      Console.ReadKey();*/
      Console.WriteLine("\nStarting...");
      StateControl.Run();
      Console.WriteLine("Starting, OK.");
      
      Console.WriteLine("\nPress any key to shutting down.");
      Console.ReadKey();
      Console.WriteLine("\nShutting down...");
      StateControl.Stop();
      Console.WriteLine("Shutting down, OK.");

      Console.WriteLine("Please any key to exit.");
      Console.ReadKey();
      host.Stop();  // stop hosting
    }
  }
}