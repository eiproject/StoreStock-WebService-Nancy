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
			Store _store = new Store("Nano Store");
			IFactory factory = new Factory(_store);
			IStockRepository repository = new StockRepository(factory);
			IStoreRepository storerepository = new StoreRepository(factory, repository);
			StateControl stateControl = new StateControl(storerepository, repository);

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