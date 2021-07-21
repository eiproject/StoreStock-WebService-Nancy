using Nancy;
using Nancy.Helpers;
using Nancy.IO;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStockWeb.Services {
  public class StoreAPI {
    private Store _store;
    private SerializableStoreStock _storeData;
    private ModelStoreStock _storeModel;
    private IFactory _factory;
    private IStoreRepository _repository;
    private SerializableStock _stockData;
    private ModelStock _stockModel;
    private HttpStatusCode _statusCode;
    public StoreAPI(
        Store store, SerializableStoreStock storeData,
        ModelStoreStock storeModel, IFactory factory, IStoreRepository repository,
        SerializableStock stockData, ModelStock stockModel) {
      _store = store;
      _storeData = storeData;
      _storeModel = storeModel;
      _factory = factory;
      _repository = repository;
      _stockData = stockData;
      _stockModel = stockModel;
    }
    internal Response ReadStore(IResponseFormatter response, Request request) {
      try {
        _storeData.SetStoreName(_store.StoreName);
        _storeData.SetStoreData(_repository.ReadStoreStock());
        _statusCode = HttpStatusCode.OK;
      }
      catch (Exception e) {
        Console.WriteLine(e);
        _statusCode = HttpStatusCode.InternalServerError;
      }

      return response.AsJson(_storeModel.StoreStockData, _statusCode);
    }
  }
}
