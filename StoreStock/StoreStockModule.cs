using Nancy;
using Nancy.ModelBinding;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using StoreStock.BusinessLogic;
using System.Text;

namespace StoreStockWeb.Services {
  public class StoreStockModule : NancyModule {
    private const string MessageKey = "message";
    private const string ConfigInfoKey = "ci";
    private ViewStockModel _viewModel;
    public StoreStockModule()
      : base("/store-stock") {
      Get["/view"] = parameters => {
        _viewModel = new ViewStockModel();
        return View["StockViewerIndex.html", _viewModel];
      };
      Get["/"] = parameters => {
        string storeName = this.Request.Query["store"];
        string strId = this.Request.Query["id"];
        int? id = int.TryParse(strId, out var tempId) ? int.Parse(strId) : (int?)null;
        if (id == null) {
          Console.WriteLine("Params: " + storeName + " " + id);
          _viewModel = new ViewStockModel();
          StoreStockSerializable serialize = new StoreStockSerializable();
          serialize.Data = _viewModel;
          serialize.Store = _viewModel.StoreName;

          return Response.AsJson(serialize);
        }
        else {
          _viewModel = new ViewStockModel();
          return View["StockViewerIndex.html", _viewModel];
        }
      };
      Post["/"] = parameters => {
        var config = this.Bind<ConfigInfo>();

        // save information

        Session[MessageKey] = "Configuration Updated";
        Session[ConfigInfoKey] = config;
        return Response.AsRedirect("/config");
      };
    }
  }

  public class ViewStockModel {
    public string StoreName { get { return ; } }
    public List<Stock> ListOfStoreStock { get { return Program.TheStore.WerehouseData; } }
    internal ViewStockModel() {
      Console.WriteLine("View Stock Model run");
    }
  }
}
