namespace LanguageFeatures.CS15;

public class PatternMatchingEvolutionTests
{
    [Fact]
    public void PatternMatchingAdvancesSinceCSharp7()
    {
        object candidate = 42;

        // C# 7.0: declaration/type pattern in an is expression.
        Assert.True(candidate is int number && number == 42);

        // C# 7.0: patterns in switch statements with a when guard.
        string csharp7SwitchResult;
        object csharp7Value = 5;
        switch (csharp7Value)
        {
            case int i when i > 0:
                csharp7SwitchResult = "positive int";
                break;
            case int:
                csharp7SwitchResult = "non-positive int";
                break;
            case string s:
                csharp7SwitchResult = $"string: {s}";
                break;
            default:
                csharp7SwitchResult = "other";
                break;
        }

        // C# 8.0: switch expressions and recursive property patterns.
        static string csharp8Recursive(object toTest) => toTest switch
        {
            int i when i > 0 => "positive int",
            int => "non-positive int",
            string s => int.TryParse(s, out int si ) ? csharp8Recursive(si) : $"string: {s}",
            _ => "other",
        };
        Assert.Equal("positive int", csharp8Recursive("42"));

        // C# 8.0: positional patterns (using Deconstruct).
        Assert.Equal(
            "origin",
            new CartesianPoint(0, 0) switch
            {
                CartesianPoint(0, 0) => "origin",
                CartesianPoint(0, _) => "y-axis",
                CartesianPoint(_, 0) => "x-axis",
                _ => "quadrant"
            });

        // C# 9.0: relational and logical patterns (and/or/not).
        static int getAge(int year) => 2026 - year;
        Assert.True(getAge(2010) is >= 13 and < 20);
        Assert.False(getAge(1994) is >= 13 and < 20);
        object? maybeText = "text";
        Assert.True(maybeText is not null);

        var employee = new Employee("Ada", new Manager("Grace"));

        // C# 10.0: extended property patterns (dot-path member access).
        Assert.True(employee is { Boss.Name: "Grace" });

        int[] values = [1, 2, 3, 4, 5];

        // C# 11.0: list patterns, including the slice pattern (..).
        Assert.True(values is [1, 2, .., 5]);
    }

    private sealed class Employee(string name, Manager boss)
    {
        public string Name { get; } = name;
        public Manager Boss { get; } = boss;
    }

    private sealed class Manager(string name)
    {
        public string Name { get; } = name;
    }

    private readonly struct CartesianPoint(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}