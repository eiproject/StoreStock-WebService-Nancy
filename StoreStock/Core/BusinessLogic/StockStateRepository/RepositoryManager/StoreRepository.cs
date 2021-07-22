using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreStock.Models;

namespace StoreStock.BusinessLogic {
  class StoreRepository : IStoreRepository {
    private Store _store;
    internal StoreRepository(IFactory factory) {
      _store = factory.GetStore();
    }
    List<Stock> IStoreRepository.ReadStoreStock() {
      return _store.StoreData;
    }
    void IStoreRepository.UpdateStore(string storeName) {
      _store.UpdateName(storeName);
    }
  }
}
