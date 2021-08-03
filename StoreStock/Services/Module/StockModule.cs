using Nancy;

namespace StoreStockWeb.Services {
  public class StockModule : NancyModule {
    public StockModule(StockAPI stocksAPI) : base("/stock") {
      Get["/"] = _ => stocksAPI.ReadStockById(Response, Request);

      Post["/"] = _ => stocksAPI.CreateOneStock(Response, Request, this);

      Put["/"] = _ => stocksAPI.UpdateStockAmountById(Response, Request, this);

      Delete["/"] = _ => stocksAPI.DeleteStockById(Response, Request);
    }
  }
}
