using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStock.BusinessLogic {
  enum GenerateCondition {
    OK,
    SomeDataMissing,
    DataOverload,
    NothingSaved
  }
}
