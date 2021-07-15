using System;
using System.Collections.Generic;
using System.Text;

namespace StoreStock.Models {
  class Book : Stock {
    // private static Book _book;

    private string _genre;
    private string _paperSize;
    public string Genre { get { return _genre; } }
    public string PaperSize { get { return _paperSize; } }

    internal void SetBookData(string genre, string paperSize) {
      _genre = genre;
      _paperSize = paperSize;
    }
/*
    // Singleton pattern
    private Book() {

    }

    public static Book GetInstance(string genre, string size) {
      if ( _book == null ) {
        _book = new Book();
        _book._genre = genre;
        _book._paperSize = size;
      }
      return _book;
    }*/
  }
}
