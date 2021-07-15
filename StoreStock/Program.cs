using Nancy;
using Nancy.Hosting.Self;
using System;
using StoreStockWeb.Services.BusinessLogic;
using Nancy.Bootstrapper;
using Nancy.ViewEngines;
using Nancy.TinyIoc;
using System.Reflection;

namespace StoreStockWeb.Services {
  class Program {
    static string _hostUri = "http://127.0.0.1:5000";
    Program() { }
    static void Main(string[] args) {
      // initialize an instance of NancyHost (found in the Nancy.Hosting.Self package)
      // HostConfiguration hostConfigs = new HostConfiguration();
      // hostConfigs.UrlReservations.CreateAutomatically = true;
      NancyHost host = new NancyHost(new Uri(_hostUri), new CustomBootstrapper());
      host.Start(); // start hosting
      Console.WriteLine($"Starting host on { _hostUri }");
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      host.Stop();  // stop hosting
    }
  }

  
}


