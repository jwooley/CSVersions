using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LanguageFeatures.CS11
{
    public class GenericMath
    {
        [Fact]
        public void CanAddNums()
        {
            var ints = new [] { 1, 2, 3 };
            var decimals = new [] { 1.1M, 1.2M, 1.3M };
            var doubles = new [] { 1.1, 1.2, 1.3 };
            var floats = new [] { 1.1f, 1.2f, 1.3f }.AsSpan();

            Assert.Equal(6, Sum(ints));
            Assert.Equal(3.6M, Sum(decimals));
            Assert.Equal(3.6d, Sum(doubles), .001);
            Assert.Equal(3.6f, Sum(floats), .001);
        }

        public static T Add<T>(T a, T b)
            where T : INumber<T>
        {
            return a + b;
        }

        public static T Sum<T>(IEnumerable<T> values)
            where T : INumber<T>
        {
            T result = T.Zero;

            foreach (var value in values)
            {
                result += value;
            }

            return result;
        }

        public static T Sum<T>(Span<T> values)
            where T : INumber<T> => 
            values switch
            {
                [] => T.Zero,
                [var first, .. var rest] => first + Sum(rest),
            };

    }
}           
