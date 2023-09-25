using System.Diagnostics.CodeAnalysis;

namespace LanguageFeatures.CS11;

public class SetsRequiredMembers
{
    [Fact]
    public void CanCreateWithRequiredConstructor()
    {
        var t1 = new TestType("Jim");
        var t2 = new TestType { Name = "Jim" };
        //var fails = new TestType();
        //var alsofails = new TestType { Optional = "Not required" };
    }
}

file class TestType
{
    public TestType()
    {

    }
    [SetsRequiredMembers]
    public TestType(string name)
    {
        Name = name;
    }

    public required string Name { get; init; }
    public string Optional { get; set; } = "";
}
