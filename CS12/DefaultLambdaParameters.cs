using LanguageFeatures.CS10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS12
{
    public class LambdaParameters
    {
        [Fact]
        public void DefaultLambdaParameters()
        {
            var l = (string f, string l = "") => $"{f} {l}";
            Assert.Equal("Jim ", l("Jim"));
        }

        [Fact]
        public void ParamArray()
        {
            var l = (params string[] parts) => string.Join(" ", parts);
            Assert.Equal("Jim Wooley", l(new [] { "Jim", "Wooley"}));
        }
    }
}
