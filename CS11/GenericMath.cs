using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11
{

    internal class GenericMath
    {
        public static TResult Sum<T, TResult>(IEnumerable<T> values)
            where T : INumber<T>
            where TResult : INumber<TResult>
        {
            TResult result = TResult.Zero;

            foreach (var value in values)
            {
                result += TResult.Create(value);
            }

            return result;
        }
    }
}
