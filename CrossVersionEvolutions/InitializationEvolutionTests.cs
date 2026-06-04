using Xunit.Sdk;

namespace LanguageFeatures.CS15;

public class InitializationEvolutionTests
{
    [Fact]
    public void ObjectAndListInitializationByLanguageVersion()
    {
        Person original = new Person("First", "Last");

        // C# 3.0: object initializer syntax.
        var csharp3 = new Person
        {
            FirstName = "Ada",
            LastName = "Lovelace"
        };
        Assert.Equal("Ada Lovelace", csharp3.FullName);

        // C# 3.0: collection initializer syntax.
        var csharp3List = new List<int> { 1, 2, 3 };
        Assert.Equal(6, csharp3List.Sum());

        // C# 6.0: index initializers for dictionaries.
        var csharp6Dictionary = new Dictionary<string, int>
        {
            ["apples"] = 2,
            ["oranges"] = 3
        };
        Assert.Equal(5, csharp6Dictionary.Values.Sum());

        // C# 9.0: target-typed new for concise object creation.
        Person csharp9 = new() { FirstName = "Grace", LastName = "Hopper" };
        Assert.Equal("Grace Hopper", csharp9.FullName);
        
        static string LastFirst(Person p) => $"{p.LastName}, {p.FirstName}";
        Assert.Equal("Wooley, Jim", LastFirst( new() { FirstName = "Jim", LastName = "Wooley" }));

        // C# 11.0: required members enforce initialization at construction.
        var csharp11Required = new RequiredProfile { DisplayName = "Developer" };
        Assert.Equal("Developer", csharp11Required.DisplayName);

        // C# 12.0: collection expressions ([]) for concise list/array creation.
        List<int> csharp12List = [10, 20, 30];
        int[] csharp12Array = [1, 2, 3];
        Assert.Equal(60, csharp12List.Sum());
        Assert.Equal(6, csharp12Array.Sum());

        // C# 12.0: spread element (..) in collection expressions.
        int[] more = [4, 5];
        int[] combined = [.. csharp12Array, .. more];
        Assert.Equal("1,2,3,4,5", string.Join(",", combined));

        // C# 14.0: implicit indexer access in object initializers.
        var csharp14Buffer = new Buffer
        {
            Data =
            {
                [0] = 7,
                [1] = 8,
                [2] = 9,
            }
        };
        Assert.Equal("7,8,9", string.Join(",", csharp14Buffer.Data));
    }

    private class Person
    {
        public Person() {}
        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName => $"{FirstName} {LastName}";
    }

    private sealed class RequiredProfile
    {
        public required string DisplayName { get; init; }
    }

    private sealed class Buffer
    {
        public int[] Data { get; } = new int[3];
    }
}