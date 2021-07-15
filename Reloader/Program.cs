using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reloader {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("[SPECIAL INSTRUCTION] Reloader Started!, press any key to reload.");
      while (true) {
        var setup = new AppDomainSetup();
        setup.ApplicationBase = @"C:\Lab Formulatrix\NancyFxStoreStockWeb\StoreStock\";
        setup.ShadowCopyFiles = "true";
        var domain = AppDomain.CreateDomain("Nancy", new Evidence(), setup);
        domain.ExecuteAssembly(@"C:\Lab Formulatrix\NancyFxStoreStockWeb\StoreStock\bin\Debug\StoreStockWeb.Services.exe");
        AppDomain.Unload(domain);
      }
    }
  }
}
