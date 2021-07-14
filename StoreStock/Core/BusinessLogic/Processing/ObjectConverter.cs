using System;
using System.Collections.Generic;
using System.Text;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class AutomaticObjectConverter {
    object convertedObject;
    public object ConvertedObject { get { return convertedObject; } }
    internal AutomaticObjectConverter(Stock obj) {
      if (obj.Type == "book") {
        Book bookObj = (Book)obj;
        convertedObject = bookObj;
      }
      else if (obj.Type == "pencil") {
        Pencil pencilObj = (Pencil)obj;
        convertedObject = pencilObj;
      }
      else if (obj.Type == "pen") {
        Pen penObj = (Pen)obj;
        convertedObject = penObj;
      }
      else {
        convertedObject = obj;
        Console.WriteLine("Unidentified Filled Object");
      }
    }
  }
}
