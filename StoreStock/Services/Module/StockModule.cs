using Nancy;

namespace StoreStockWeb.Services {
  public class StockModule : NancyModule {
    public StockModule(StockAPI stocksAPI) : base("/stock") {
      Get["/"] = _ => stocksAPI.ReadStockByID(Response, Request);

      Post["/"] = _ => stocksAPI.CreateStock(Response, Request, this);

      Put["/"] = _ => stocksAPI.UpdateStockAmount(Response, Request, this);

      Delete["/"] = _ => stocksAPI.DeleteStockByID(Response, Request);
    }
  }
}
