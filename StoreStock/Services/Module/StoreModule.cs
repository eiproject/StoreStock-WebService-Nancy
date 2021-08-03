using Nancy;

namespace StoreStockWeb.Services {
  public class StoreModule : NancyModule {
    public StoreModule(StoreAPI storeAPI) : base("/store") {
      Get["/"] = _ => storeAPI.ReadStoreAPI(Response, Request);
      Put["/"] = _ => storeAPI.UpdateStoreAPI(Response, Request, this);
    }
  }
}