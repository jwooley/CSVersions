namespace LanguageFeatures.CS10;

public class ExtendedPropertyPatterns
{
    [Fact]
    public void CanFilterExtendedPropertyPattern()
    {
        var person = new ComplexEmployee("Jim", "Wooley", "SDP",
            new ComplexEmployee("My", "Manager", "Director", null));

        Assert.True(IsManagedBy(person));
        Assert.True(IsManagedExtended(person));
    }

    bool IsManagedBy(ComplexEmployee test) =>
        test is { Manager: { last: "Manager" } };

    bool IsManagedExtended(ComplexEmployee test) =>
        test is { Manager.last: "Manager" };
}

record ComplexEmployee(string first, string last, string title, ComplexEmployee Manager)
    : EmployeeClass(first, last, title);

