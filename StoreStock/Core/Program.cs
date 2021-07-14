using System;
using StoreStock.BusinessLogic;
using StoreStock.Models;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("UnitTest")]
namespace StoreStock {
  /*
  fitur:
 - input barang ( inget bisa macem2 tipe barang, bikin classnya )
 - simpan jumlah stock barang di array saja
 - bisa liat ada barang apa saja yang sudah diinput dan berapa jumlahnya 

  + Repository Manager

  */

  class Run {
    /* Tipe Barang#Jumlah#Harga#Judul#Genre#PaperType */
    /* Tipe Barang = Buku, Pena, Pensil */
    internal Run() {
      // singleton class
      Werehouse FormulatrixStore = Werehouse.GetInstance();

      GenerateDummyData dummy = new GenerateDummyData(FormulatrixStore);
/*
      // try to create new store using singleton class, but can't
      // there are some dummy data that created before
      Werehouse FormulatrixStoreSM = Werehouse.getDatabase();
*/
      while (FormulatrixStore.IsRunning) {
        CLI FormulatrixInterface = new CLIMenu(FormulatrixStore);
        FormulatrixInterface.InterfaceMenu();
      }
    }
  }
/*  class Program {
    static void runApp() {
      Run _app = new Run();
    }
    static void Main(string[] args) {
      Console.WriteLine("Welcome to Store Stock Application!");
      *//*Thread t = new Thread(new ThreadStart(runApp));
      t.Start();
      *//*
      Run _app = new Run();
    }
  }*/
}
