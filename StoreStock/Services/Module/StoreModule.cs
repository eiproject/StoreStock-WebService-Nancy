using Nancy;

namespace StoreStockWeb.Services {
  public class StoreModule : NancyModule {
    public StoreModule(StoreAPI storeAPI) : base("/store") {
      Get["/"] = _ => storeAPI.ReadStoreObject(Response, Request);
      Put["/"] = _ => storeAPI.UpdateStoreName(Response, Request, this);
    }
  }
}