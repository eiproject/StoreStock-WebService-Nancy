namespace StoreStockWeb.Services {
  class RequestStock {
    public string Type { get; set; }
    public int Amount { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    public string Size { get; set; }
  }
}
