using Nancy;

namespace StoreStockWeb.Services {
	public class MainModule : NancyModule
	{
		public MainModule()
		{
			Get["/"] = x => "Nice GET!";
		}
	}
}
