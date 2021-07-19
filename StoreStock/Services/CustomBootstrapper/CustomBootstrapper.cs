using Nancy;
using Nancy.Hosting.Self;
using System;
using Nancy.Bootstrapper;
using Nancy.ViewEngines;
using Nancy.TinyIoc;
using System.Reflection;
using Nancy.Conventions;
using Nancy.Responses;
using System.IO;
using Nancy.Session;
using StoreStock.Models;
using StoreStock.BusinessLogic;
using StoreStock;
using System.Collections.Generic;
/*
using Nancy.ViewEngines;
using TinyIoC;
*/
namespace StoreStockWeb.Services {
	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
    protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
      base.ConfigureApplicationContainer(container);
			container.Register<IStore>(new Store(new List<IStock>(), "Nano Store"));
    }

		protected override void ApplicationStartup(TinyIoCContainer container,
			IPipelines pipelines) {
			base.ApplicationStartup(container, pipelines);

			// create dummy data 
			IStore store = container.Resolve<IStore>();
			IFactory factory = new Factory(store);
			//  Start Store Stock Services
			Run storeStock = new Run(factory);
			storeStock.Start(store);
			storeStock.UseDummyData();

			CookieBasedSessions.Enable(pipelines);
		}
	}
}