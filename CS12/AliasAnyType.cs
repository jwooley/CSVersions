using Name = (string first, string last);
using Grade = decimal;
using g2 = System.Decimal;

namespace LanguageFeatures.CS12
{
    internal class AliasAnyType
    {
        public void TestAlias()
        {
            Name tested = ("Jim", "Wooley");
            Assert.Equal("Jim Wooley", $"{tested.first} {tested.last}");
        } 
    }
}
