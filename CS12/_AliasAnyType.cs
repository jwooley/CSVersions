// With C# 12, you can create type aliases for any type, including tuples and built-in types.
// This allows you to give more meaningful names to complex types
// or to simplify the usage of frequently used types. 
using Name = (string first, string last);
using Grade = decimal;
using g2 = System.Decimal;

namespace LanguageFeatures.CS12
{
    internal class _AliasAnyType
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
