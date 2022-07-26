using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11
{
    public class ListPatterns
    {
        [Fact]
        public void TestPatterns()
        {
            var nums = Enumerable.Range(0, 10).ToArray();
            var evens = nums.Where(n => n % 2 == 0).ToArray();
            var odds = nums.Where(n => n % 2 != 0).ToArray();

            Assert.True(evens is [0, 2, 4, 6, 8]);
            Assert.False(evens is [1, 3, 5, 7, 9]);

            // Has a 6
            Assert.True(evens is [.., 6, _]);

            // Less than 10
            Assert.True(odds is [_, .., < 10]);
        }
    }
}
