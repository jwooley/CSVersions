using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS10
{
    [TestClass]
    public class ConstantInterpolatedStrings
    {
        [TestMethod]    
        public void CanInterpolateConstantStrings()
        {
            const string interpolate = "interpolate";
            const string s = $"Can {interpolate} this";
            const string s2 = $"Can {nameof(interpolate)} this too";

            var nonConstant = "not this";
            // const string s3 = $"But {nonConstant}"; // Does not compile
        }
    }
}
