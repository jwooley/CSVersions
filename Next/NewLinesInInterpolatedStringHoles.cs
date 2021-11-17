using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.Next
{
    public class NewLinesInInterpolatedStringHoles
    {
        [Fact]
        public void MultiLineInStringInterpolationHoles()
        {
            var nums = Enumerable.Range(0, 10);
            Assert.Equal("Evens: 2,4,6,8,10",
                $"Evens: {string.Join(",",
                            nums
                                .Where(num => num % 2 == 0))}");
        }
    }
}
