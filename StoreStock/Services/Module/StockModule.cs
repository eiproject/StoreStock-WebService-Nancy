using Nancy;

namespace StoreStockWeb.Services {
  public class StockModule : NancyModule {
    public StockModule(StockAPI stocksAPI) : base("/stock") {
      Get["/"] = _ => stocksAPI.ReadStockByID(Response, Request);

      Post["/"] = _ => stocksAPI.CreateStock(Response, Request);

      Put["/"] = _ => stocksAPI.UpdateStockAmount(Response, Request);

      Delete["/"] = _ => stocksAPI.DeleteStockByID(Response, Request);
    }
  }
}
