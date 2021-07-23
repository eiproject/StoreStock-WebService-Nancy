using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  public interface IStoreRepository {
    Store ReadStore();
    void UpdateStore(string name);
    bool Init();
    bool Run();
    bool Stop();
  }
}
