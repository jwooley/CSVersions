namespace LanguageFeatures.CS15;

public class StringLiteralsAndInterpolationEvolutionTests
{
    [Fact]
    public void StringLiteralsAndInterpolationByLanguageVersion()
    {
        // C# 6.0: interpolated strings ($"...") provide inline expression formatting.
        var name = "Ada";
        var csharp6Interpolated = $"Hello, {name}!";
        Assert.Equal("Hello, Ada!", csharp6Interpolated);

        // C# 6.0: interpolated verbatim strings ($@"...") support multiline templates.
        var csharp6Multiline = $@"{{
    User: ""{name}"",
    City: ""London""
}}}}";
        Assert.Contains("    City: \"London\"", csharp6Multiline);

        // C# 11.0: raw string literals ("""...""") avoid escaping and preserve content.
        var csharp11Raw = """
            {
              "language": "C#",
              "version": 11
            }
            """;
        Assert.Contains("  \"language\": \"C#\"", csharp11Raw);

        // C# 11.0: interpolation in raw string literals using multiple $ for braces.
        var csharp11RawInterpolated = $$"""
            Literal braces: {{name}}
            Name: {{{name}}}
            """;
        Assert.Contains("Literal braces: Ada", csharp11RawInterpolated);
        Assert.Contains("Name: {Ada}", csharp11RawInterpolated);

        // C# 8.0: index/range operators on strings and spans.
        var text = "Roslyn";
        Assert.Equal('R', text[0]);
        Assert.Equal('n', text[^1]);
        Assert.Equal("osly", text[1..^1]);

        // C# 8.0: span-friendly indexing and slicing over string data.
        ReadOnlySpan<char> chars = text;
        Assert.Equal('o', chars[1]);
        Assert.Equal('n', chars[^1]);
        Assert.Equal("sly", chars[2..^1].ToString());

        // C# 10.0: constant interpolated strings when all parts are compile-time constants.
        const string product = "Compiler";
        const string csharp10ConstInterpolated = $"{product} API";
        Assert.Equal("Compiler API", csharp10ConstInterpolated);

        // C# 11.0: new lines are allowed inside interpolation holes.
        var csharp11MultilineHole = $"Value: {
            text.ToUpperInvariant()
        }";
        Assert.Equal("Value: ROSLYN", csharp11MultilineHole);

        // C# 13.0: \e escape sequence for ESC character in string literals.
        var csharp13Escape = "\e[31merror\e[0m";
        Assert.Equal((char)27, csharp13Escape[0]);
        Assert.Equal("[31merror", csharp13Escape.AsSpan(1, 9).ToString());
    }
}