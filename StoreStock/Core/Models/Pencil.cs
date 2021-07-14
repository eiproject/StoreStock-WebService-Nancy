using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pencil : Stock {
    private string _brand;
    private string _pencilSize;
    public string Brand { get { return _brand; } }
    public string PencilSize { get { return _pencilSize; } }

    public void SetPencilData(string brand, string pencilSize) {
      _brand = brand;
      _pencilSize = pencilSize;
    }
  }
}
