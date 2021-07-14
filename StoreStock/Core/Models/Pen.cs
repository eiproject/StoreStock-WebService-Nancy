using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Pen : Stock {
    private string _brand;
    private string _inkColor;
    private string _lineSize;
    public string Brand { get { return _brand; } }
    public string InkColor { get { return _inkColor; } }
    public string LineSize { get { return _lineSize; } }

    public void SetPenData(string brand, string ink, string size) {
      _brand = brand;
      _inkColor = ink;
      _lineSize = size;

    }
  }
}
