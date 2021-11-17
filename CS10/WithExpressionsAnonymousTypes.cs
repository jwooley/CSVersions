namespace LanguageFeatures.CS10;

public class WithExpressionsAnonymousTypes
{
    [Fact]
    public void Test()
    {
        var anon = new { First = "Jim", Last = "Wooley" };
        var legal = anon with { First = "James" };
        Assert.Equal("James Wooley", $"{legal.First} {legal.Last}");
    }

    [Fact]
    public void BetterInterpolatedStrings()
    {
        // TODO: Copy this into https://sharplab.io to see the generated difference
        // in string interpolation with multiple parameters
        var anon = new { First = "Jim", Last = "Wooley" };
        Assert.Equal("Jim Wooley aka James Wooley", $"{anon.First} {anon.Last} aka James {anon.Last}");
    }
}
