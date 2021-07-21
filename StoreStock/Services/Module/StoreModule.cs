using Nancy;
using Nancy.ModelBinding;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using StoreStock.BusinessLogic;
using System.Text;
using System.Linq;
using Nancy.Helpers;
using Nancy.IO;

namespace StoreStockWeb.Services {
  public class StoreModule : NancyModule {
    public StoreModule(StoreAPI storeAPI) : base("/store") {

      // Basic constrcutor end here
      Get["/"] = _ => storeAPI.ReadStore(Response, Request);
    }
  }
}