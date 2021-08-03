namespace StoreStock.Models {
  public abstract class Stock {
    protected Store _store;
    protected int _id;
    protected string _title;
    protected string _sku;
    protected int _amount;
    protected decimal _price;
    protected string _type;
    protected string _category;
    protected string _subCategory;
    protected string _size;
    protected decimal _discount;

    /*public variables goes here*/
    public int ID => _id;
    public string Type => _type;
    public string Title => _title;
    public string SKU => _sku;
    public int Amount => _amount;
    public string Category => _category;
    public string SubCategory => _subCategory;
    public string Size => _size;
    public decimal Discount => GetDiscountPrice();
    public decimal Price => _price;
    
    /*Method*/
    protected abstract decimal GetDiscountPrice();
    public static Stock operator + (Stock stock, int amount) {
      stock._amount += amount;
      return stock;
    }

    /*The Constructor*/
    public Stock(Store store) {
      _store = store;
    }
  }
}
