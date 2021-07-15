using Nancy;
using Nancy.ModelBinding;

namespace StoreStockWeb.Services { 
	public class StoreStockModule : NancyModule
	{
		private const string MessageKey = "message";
		private const string ConfigInfoKey = "ci";

		public StoreStockModule()
			: base("/store-stock")
		{
      Get["/"] = x => {
        return View["StockViewer.html"];
      };
      Post["/update"] = parameters =>
								{
									var config = this.Bind<ConfigInfo>();

									// save information

									Session[MessageKey] = "Configuration Updated";
									Session[ConfigInfoKey] = config;
									return Response.AsRedirect("/config");
								};
		}
	}

	public class ViewStockModel
	{
		public string Message { get; set; }
		public ConfigInfo Config { get; set; }
		public bool HasMessage
		{
			get { return !string.IsNullOrWhiteSpace(Message); }
		}
	}
}
