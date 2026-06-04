namespace LanguageFeatures.CS15;

public class NullHandlingEvolutionTests
{
    [Fact]
    public void NullHandlingAdvancesSinceCSharp6()
    {
        Nullable<int> cs3;
        int? b;

        Person? maybePerson = new("Ada", new Address("NYC"));
        Person? noPerson = null;

        // C# 6.0: null-conditional operator (?.) short-circuits member access.
        Assert.Equal("Ada", maybePerson?.Name);
        Assert.Null(noPerson?.Name);

        // C# 6.0: null-conditional indexer access (?[...]).
        var names = new List<string> { "Ada", "Grace" };
        List<string>? noNames = null;
        Assert.Equal("Grace", names?[1]);
        Assert.Null(noNames?[0]);

        // C# 6.0: null-coalescing operator (??) for default values.
        string? nickname = null;
        Assert.Equal("(none)", nickname ?? "(none)");

        // C# 7.0: throw expressions, commonly paired with ?? for argument validation.
        static string RequireName(string? name) =>
            name ?? throw new ArgumentNullException(nameof(name));
        Assert.Throws<ArgumentNullException>(() => RequireName(null));
        Assert.Equal("Linus", RequireName("Linus"));

        // C# 8.0: nullable reference types (string?) and flow analysis.
        string? candidate = "value";
        Assert.Equal(5, candidate.Length);

        // C# 8.0: null-coalescing assignment (??=).
        string? city = null;
        city ??= "Unknown";
        Assert.Equal("Unknown", city);

        // C# 8.0: null-forgiving operator (!) to override nullable warnings.
        string? maybeNull = "safe";
        Assert.Equal(4, maybeNull!.Length);

        // C# 9.0: pattern-based null checks with 'is not null'.
        Assert.True(maybePerson is not null);
        Assert.False(noPerson is not null);

        // C# 10.0: improved definite assignment and flow analysis for null-state.
        var fromTry = GetUpperIfNotNull("ok", out var upper) ? upper : "MISSING";
        Assert.Equal("OK", fromTry);

        // C# 11.0: required members help guarantee non-null initialization.
        var required = new RequiredContact { Email = "dev@example.com" };
        Assert.Equal("dev@example.com", required.Email);

        // C# 12.0: primary constructors reduce boilerplate in null-safe initialization.
        var c12 = new PrimaryCtorUser("Jane");
        Assert.Equal("Jane", c12.DisplayName);

        // C# 14.0: null-conditional assignment allows concise guarded writes.
        maybePerson?.Name = "Ada Updated";
        noPerson?.Name = "Nobody";
        Assert.Equal("Ada Updated", maybePerson!.Name);
        Assert.Null(noPerson);
    }

 

    private static bool GetUpperIfNotNull(string? value, out string upper)
    {
        if (value is null)
        {
            upper = "";
            return false;
        }

        upper = value.ToUpperInvariant();
        return true;
    }

    private sealed class Person(string name, Address address)
    {
        public string Name { get; set; } = name;
        public Address Address { get; } = address;
    }

    private sealed class Address(string city)
    {
        public string City { get; } = city;
    }

    private sealed class RequiredContact
    {
        public required string Email { get; init; }
    }

    private sealed class PrimaryCtorUser(string displayName)
    {
        public string DisplayName { get; } = displayName;
    }
}