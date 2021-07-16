using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class HTTPResponse {
    private int _code = 500;
    private string _message = "Unknown";
    public int Code { get { return _code; } }
    public string Message { get { return _message; } }
    internal HTTPResponse() {
      
    }
    internal void SetCode(int code) {
      _code = code;
      if (code == 200) {
        _message = "Success";
      }
      else if (code == 201) {
        _message = "Created";
      }
      else if (code == 404) {
        _message = "Not Found";
      }
      else if (code == 404) {
        _message = "Method Not Allowed";
      }
      else if (code == 409) {
        _message = "Conflict";
      }
      // Error or unknown
      else {
        _code = 500;
        _message = "Internal Server Error";
      }
    }
  }
}
