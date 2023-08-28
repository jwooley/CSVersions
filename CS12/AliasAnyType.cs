using Name = (string first, string last);
using Grade = decimal;
using g2 = System.Decimal;

namespace LanguageFeatures.CS12
{
    internal class AliasAnyType
    {
        public void TestAlias()
        {
            // See usings above
            Name tested = ("Jim", "Wooley");
            Assert.Equal("Jim Wooley", $"{tested.first} {tested.last}");

            Grade.TryParse("100", out g2 result);
            Assert.Equal(100m, result);
        } 
    }
}
