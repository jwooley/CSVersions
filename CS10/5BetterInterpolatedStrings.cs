namespace LanguageFeatures.CS10;

public class BetterInterpolatedStrings
{
    [Fact]
    public void TestStringInterpolation()
    {
        // TODO: Copy this into https://sharplab.io to see the generated difference
        // in string interpolation with multiple parameters
        var anon = new { First = "Jim", Last = "Wooley" };
        Console.WriteLine($"{anon.First} {anon.Last}");
        Console.WriteLine($"{anon.First} {anon.Last} aka James {anon.Last}");
    }
}
