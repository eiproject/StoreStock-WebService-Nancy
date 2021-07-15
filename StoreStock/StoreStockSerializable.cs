using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  [Serializable]
  public class StoreStockSerializable {
    public string Store { get; set; }
    public List<IStock> Data { get; set; }
  }
}
