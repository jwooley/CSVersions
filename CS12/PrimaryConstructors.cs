namespace LanguageFeatures.CS12;

public class PrimaryConstructors(string first, string last, string backingFieldRemoved = "")
{
    public PrimaryConstructors() : this("", "") { }

    public string NameFormatted => $"{first} {last}";
    public string Surname => last;
    public string Last => last;
}
public class  Consumer
{
    public void Test()
    {
        var t = new PrimaryConstructors("Jim", "Wooley");
        Assert.Equal("Jim Wooley", t.NameFormatted);
        Assert.Equal("Wooley", t.Surname);
        //Assert.Fail("can not access", t.firstName);
    }
}
