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

namespace StoreStockWeb.Services {
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
			Store _store = new Store("Nano Store");
			IFactory factory = new Factory(_store);
			IStockRepository repository = new SStockRepository(factory);
			IStoreRepository storerepository = new SStoreRepository(factory);
			StateControl stateControl = new StateControl(repository, storerepository);

			base.ConfigureApplicationContainer(container);
			container.Register(_store);
			container.Register(factory);
			container.Register(repository);
			container.Register(storerepository);
			container.Register(stateControl);
		}

		protected override void ApplicationStartup(TinyIoCContainer container,
			IPipelines pipelines) {
			base.ApplicationStartup(container, pipelines);
			CookieBasedSessions.Enable(pipelines);
		}
	}
}