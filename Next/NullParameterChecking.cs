namespace LanguageFeatures.Next;

// feature not included
public class NullParameterChecking
{
    [Fact]
    public void ShouldThrowIfNotPassed()
    {
        Assert.Throws<ArgumentNullException>(() => ToTest(null));
    }

    public void ToTest(string input!!)
    {
        Console.WriteLine(input);
    }
}
