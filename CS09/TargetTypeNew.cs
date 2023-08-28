using LanguageFeatures.CS6;

namespace LanguageFeatures.CS09;

public class TargetTypeNew
{
    [Fact]
    public void TargetTypeTest()
    {
        Person original = new Person();
        var p3 = new Person();

        Person p = new();
        PrintPerson (p);

        PrintPerson(new());
    }

    public static void PrintPerson(Person p)
    {
        Console.WriteLine(p.Name); ;
    }

}
