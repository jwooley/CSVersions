

namespace LanguageFeatures.Cs8
{
    
    public class Range
    {
        [Fact]
        public void TestRangeNums()
        {
            Span<int> arr = Enumerable.Range(1, 10).ToArray();
            var num12 = arr[..2];
            Assert.Equal(2, num12.Length);
            Assert.Equal(1, num12[0]);
            Assert.Equal(2, num12[1]);

            var num234 = arr[2..4];
            var num789 = arr[^4..^1];
            Assert.Equal(7, num789[0]);
        }

        [Fact]
        public void TestStringRange()
        {

            var input = "This is a test of string ranges";
            var test = input[10..14];
            var ranges = input[^6..];
            Assert.Equal("testranges", $"{test}{ranges}");
        }
    }
}
