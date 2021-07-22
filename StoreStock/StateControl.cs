using StoreStock.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  class StateControl {
    static IStockRepository _repository;
    internal StateControl(IStockRepository repository) {
      _repository = repository;
    }

    internal static void Init() {
      _repository.Init();
    }
    internal static void Run() {
      _repository.Run();
    }
    internal static void Stop() {
      _repository.Stop();
    }
  }
}
