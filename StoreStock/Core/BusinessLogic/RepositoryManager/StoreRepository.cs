using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository : IStoreRepository {
    private IStore _store;
    private IFactory _factory;
    internal StoreRepository(IStore TheStore, IFactory factory) {
      _store = TheStore;
      _factory = factory;
    }
    List<Stock> IStoreRepository.ReadStoreStock() {
      return _store.GetListOfStoreStock();
    }
  }
}
