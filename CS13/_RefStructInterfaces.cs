namespace LanguageFeatures.CS13;

internal interface ILengthProvider
{
    int Length { get; }
}

internal readonly ref struct Token(ReadOnlySpan<char> value) : ILengthProvider
{
    private readonly ReadOnlySpan<char> _value = value;
    public int Length => _value.Length;
}

internal class _RefStructInterfaces
{
    private static int GetLength<T>(T value) where T : ILengthProvider, allows ref struct => value.Length;

    public int Demo()
    {
        Token token = new("demo");
        return GetLength(token);
    }

    private static int GetLengthBefore(ILengthProvider value) => value.Length;

    public int DemoBefore()
    {
        var token = new TokenBefore("demo");
        return GetLengthBefore(token);
    }
}

internal readonly struct TokenBefore(string value) : ILengthProvider
{
    public int Length => value.Length;
}
