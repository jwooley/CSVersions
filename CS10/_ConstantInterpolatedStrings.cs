namespace LanguageFeatures.CS10;

public class _ConstantInterpolatedStrings
{
    [Fact]
    public void CanInterpolateConstantStrings()
    {
        const string interpolate = "interpolate";
        const string s = $"Can {interpolate} this";
        const string s2 = $"Can {nameof(interpolate)} this too";

        var nonConstant = "not this";
        // const string s3 = $"But {nonConstant}"; // Does not compile
    }
}
