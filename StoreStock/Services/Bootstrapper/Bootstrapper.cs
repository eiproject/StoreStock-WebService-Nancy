using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Session;
using StoreStock.Models;
using StoreStock.BusinessLogic;

namespace StoreStockWeb.Services {
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
			Store store = new Store("Nano Store");
			IFactory factory = new Factory(store);
			IStockRepository repository = new StockRepository(store, factory);
			IStoreRepository storerepository = new StoreRepository(store, factory);
			StateManager stateControl = new StateManager(storerepository, repository);

			base.ConfigureApplicationContainer(container);
			container.Register(store);
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