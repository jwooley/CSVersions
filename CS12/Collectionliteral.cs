using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS12
{
    internal class Collectionliteral
    {
        public void Test()
        {
            // Fix
            //            DoSomething([1.2m, 1.3m]);
            //            DoSomething([]);
            // var stillNotSure = [1, 2, 3];
            // var dictionaryLiteral = ["first": 1, "second": 2];
        }
        public void DoSomething(List<decimal> items)
        {
            items.Sum();
        }
    }
}
