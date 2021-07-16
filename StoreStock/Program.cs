using Nancy;
using Nancy.Hosting.Self;
using System;
using Nancy.Bootstrapper;
using Nancy.ViewEngines;
using Nancy.TinyIoc;
using System.Reflection;
using StoreStock;
using StoreStock.Models;
using StoreStock.BusinessLogic;
using System.Text;
using TinyIoC;

namespace StoreStockWeb.Services {
  class Program {
    static string _hostUri = "http://127.0.0.1:5000";
    Program() { }
    static void Main(string[] args) {
      // https://gist.github.com/manadart/886534/f87af151aec21c78ee77bb558354fdc018cabdd3
      TinyIoC.TinyIoCContainer container = TinyIoC.TinyIoCContainer.Current;
      container.Register<IStore>( new Store("Nano Store"));

      IStore store = container.Resolve<IStore>();
      IFactory factory = new Factory(store);
      //  Start Store Stock Services
      Run storeStock = new Run(factory);
      storeStock.Start(store);
      storeStock.UseDummyData();

/*      JSONParser parser = new JSONParser(TheStore.WerehouseData);
      StringBuilder A =parser.ListStockToJSON();
      Console.WriteLine(A);*/
      
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


