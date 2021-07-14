using Nancy;
using Nancy.Hosting.Self;
using System;
using StoreStockWebServices.BusinessLogic;
using Nancy.Bootstrapper;
using Nancy.ViewEngines;
using Nancy.TinyIoc;
using System.Reflection;

namespace StoreStockWebServices {
  public class CustomBootstrapper : DefaultNancyBootstrapper {
    protected override NancyInternalConfiguration InternalConfiguration {
      get {
        return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder);
      }
    }
    void OnConfigurationBuilder(NancyInternalConfiguration x) {
      x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
    }
    protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
      base.ConfigureApplicationContainer(container);
      ResourceViewLocationProvider.RootNamespaces.Add(
        Assembly.GetAssembly(typeof(MainModule)), "StoreStockWebServices");
    }
  }
}
