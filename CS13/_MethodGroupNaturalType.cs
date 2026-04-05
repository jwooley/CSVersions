namespace LanguageFeatures.CS13;

internal class _MethodGroupNaturalType
{
    private static string Convert(int value) => value.ToString();
    private static T Convert<T>(T value) where T : unmanaged => value;

    public void Demo()
    {
        Func<int, string> converter = Convert;
        Assert.Equal("42", converter(42));
    }

    public void DemoBefore()
    {
        Func<int, string> converter = value => Convert(value);
        Assert.Equal("42", converter(42));
    }
}
