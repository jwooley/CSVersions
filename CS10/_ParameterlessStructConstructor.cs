using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS10
{
    public class ParameterlessStructConstructor
    {
        [Fact]
        public void Test()
        {
            var t = new ParameterlessStruct();
            Assert.Equal("Jim", t.First);
        }
    }

    struct ParameterlessStruct
    {
        public ParameterlessStruct()
        {
            First = "Jim";
            Last = "Wooley";
        }

        public ParameterlessStruct(string first, string last)
        {
            First = first;
            Last = last;
        }
        public string First;
        public string Last;
    }
}
