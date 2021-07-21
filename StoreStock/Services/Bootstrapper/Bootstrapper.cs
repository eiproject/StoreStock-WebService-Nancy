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
	public class Bootstrapper : DefaultNancyBootstrapper
	{
    protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
			IStore _store = new Store(new List<Stock>(), "Nano Store");
			IFactory factory = new Factory(_store);
			IRepository repository = new Repository(_store, factory);
			
			SerializableStoreStock storeData = new SerializableStoreStock();
			ModelStoreStock storeModel = new ModelStoreStock(storeData);
			SerializableStock stockData = new SerializableStock();
			ModelStock stockModel = new ModelStock(stockData);

			base.ConfigureApplicationContainer(container);
			container.Register(_store);
			container.Register(storeData);
			container.Register(storeModel);
			container.Register(factory);
			container.Register(repository);
			container.Register(stockData);
			container.Register(stockModel);
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