namespace LanguageFeatures.CS15;

using Xunit;

public class CollectionExpressionArguments
{
    [Fact]
    public void Demo()
    {
        string[] values = ["one", "two", "three"];

        // C# 15 allows collection expressions to be used as arguments in method calls, object initializers, and collection initializers. This means that you can directly pass a collection expression to a method or use it to
        // initialize an object or collection without needing to create a separate variable for the collection.
        List<string> names = [with(capacity: values.Length * 2), .. values];
        Assert.Equal(3, names.Count);
  
        HashSet<string> set = [with(StringComparer.OrdinalIgnoreCase), "Hello", "HELLO", "World", "world"];
        Assert.Equal(2, set.Count);
    }
}
