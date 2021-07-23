using Nancy;

namespace StoreStockWeb.Services {
  public class StoreModule : NancyModule {
    public StoreModule(StoreAPI storeAPI) : base("/store") {
      Get["/"] = _ => storeAPI.ReadStore(Response, Request);
      Put["/"] = _ => storeAPI.UpdateStore(Response, Request, this);
    }
  }
}