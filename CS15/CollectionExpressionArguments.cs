namespace LanguageFeatures.CS15;

using Xunit;

public class CollectionExpressionArguments
{
    [Fact]
    public void Demo()
    {
        string[] values = ["one", "two", "three"];

        List<string> names = [with(capacity: values.Length * 2), .. values];
        Assert.Equal(3, names.Count);
  
        HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO", "World", "world"];
        Assert.Equal(2, set.Count);
    }
}
