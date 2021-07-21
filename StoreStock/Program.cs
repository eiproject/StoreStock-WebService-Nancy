using Nancy.Hosting.Self;
using System;

namespace StoreStockWeb.Services {
  class Program {
    static string _hostUri = "http://127.0.0.1:5000";
    Program() { }
    static void Main(string[] args) {
      NancyHost host = new NancyHost(new Uri(_hostUri), new Bootstrapper());
      host.Start(); // start hosting
      Console.WriteLine($"Starting host on { _hostUri }");
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      host.Stop();  // stop hosting
    }
  }
}


