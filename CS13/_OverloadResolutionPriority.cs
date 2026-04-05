namespace LanguageFeatures.CS13;

internal class _OverloadResolutionPriority
{
    [System.Runtime.CompilerServices.OverloadResolutionPriority(1)]
    private static string Format(ReadOnlySpan<char> value) => new(value);

    [System.Runtime.CompilerServices.OverloadResolutionPriority(0)]
    private static string Format(string value) => value;

    public string Demo()
    {
        return Format("priority");
    }

    public string DemoBefore()
    {
        return Format("priority".AsSpan());
    }
}
