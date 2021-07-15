namespace StoreStock.Models {
  public interface IStock {
    decimal Discount { get; }
    decimal Price { get; }
    int ID { get; }
    int Amount { get; }
    string Type { get; }
    string Title { get; }
    string Category { get; }
    string SubCategory { get; }
    string Size { get; }
    void UpdateStockInformation(string type, int id, int amount, string title, decimal price, string category, string subCategory, string size);
    void UpdateStockAmount(int newAmount);
  }
}
