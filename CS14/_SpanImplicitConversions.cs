namespace LanguageFeatures.CS14;

internal class SpanImplicitConversions
{
    public int Demo()
    {
        int[] numbers = [1, 2, 3];
        // No longer need to expicitly call AsSpan() to get a Span<T> from an array.
        Span<int> span = numbers;
        ReadOnlySpan<int> readOnly = span;
        return readOnly[0] + readOnly[1] + readOnly[2];
    }

    public int DemoBefore()
    {
        int[] numbers = [1, 2, 3];
        Span<int> span = numbers.AsSpan();
        ReadOnlySpan<int> readOnly = span;
        return readOnly[0] + readOnly[1] + readOnly[2];
    }
}
