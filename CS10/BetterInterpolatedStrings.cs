namespace LanguageFeatures.CS10;

public class BetterInterpolatedStrings
{
    [Fact]
    public void TestStringInterpolation()
    {
        // TODO: Copy this into https://sharplab.io to see the generated difference
        // in string interpolation with multiple parameters
        var anon = new { First = "Jim", Last = "Wooley" };
        Assert.Equal("Jim Wooley aka James Wooley", $"{anon.First} {anon.Last} aka James {anon.Last}");
    }

}
