namespace LanguageFeatures.CS10;

public class SealedRecordToString
{

    [Fact]
    public void CanOverrideToString()
    {
        var emp = new OverlodedEmployee("Jim", "Wooley", "Mr");
        Assert.Equal("Jim Wooley", emp.ToString());
    }

}

record OverlodedEmployee : Employee
{
    public OverlodedEmployee(string NameFirst, string NameLast, string Title) : base(NameFirst, NameLast, Title)
    {
    }

    public sealed override string ToString() => $"{NameFirst} {NameLast}";
    }

