using Nancy;
using Nancy.ModelBinding;
using System;

namespace StoreStockWeb.Services { 
	public class StoreStockModule : NancyModule
	{
		private const string MessageKey = "message";
		private const string ConfigInfoKey = "ci";
		private ViewStockModel _viewModel;
		public StoreStockModule()
			: base("/store-stock")
		{
      Get["/view-stock"] = x => {
				_viewModel = new ViewStockModel();
        return View["StockViewerIndex.html", _viewModel];
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
		public string StoreName { get { return Program.TheStore.GetStoreName(); } }
		internal ViewStockModel() {
			Console.WriteLine("View Stock Model run");
    }
	}
}
