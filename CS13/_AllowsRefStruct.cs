namespace LanguageFeatures.CS13;

internal class _AllowsRefStruct
{
    private static int Measure<T>(scoped T value) where T : allows ref struct
    {
        return System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
    }

    private static int MeasureBefore(ReadOnlySpan<char> value)
    {
        return value.Length;
    }

    public int Demo()
    {
        ReadOnlySpan<char> text = "hello";
        return Measure(text);
    }

    public int DemoBefore()
    {
        ReadOnlySpan<char> text = "hello";
        return MeasureBefore(text);
    }
}
