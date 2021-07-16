using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class HTTPResponse {
    private int _code;
    private string _status;
    public int Code { get { return _code; } }
    public string Status { get { return _status; } }
    internal HTTPResponse(string condition) {
      if (condition.ToLower() == "success") {
        _code = 200;
        _status = "Success";
      }
      else if (condition.ToLower() == "not found") {
        _code = 404;
        _status = "Not Found";
      }
      else if (condition.ToLower() == "method not allowed") {
        _code = 404;
        _status = "Method Not Allowed";
      }
      else if (condition.ToLower() == "conflict") {
        _code = 409;
        _status = "Conflict";
      }
      // Error or unknown
      else {
        _code = 500;
        _status = "Internal Server Error";
      }
    }
  }
}
