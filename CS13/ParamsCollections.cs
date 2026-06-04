namespace LanguageFeatures.CS13;

internal class ParamsCollections
{
    // C# 14 allows params parameters to be collections, which means that you can
    // use the params keyword with any type that implements IEnumerable<T>, not just arrays.
    public int Sum(params IReadOnlyList<int> values) => values.Sum();

    public void Demo()
    {
        var total = Sum(1, 2, 3, 4);
        Assert.Equal(10, total);
    }

    public int SumBefore(IReadOnlyList<int> values) => values.Sum();

    public void DemoBefore()
    {
        var total = SumBefore(new[] { 1, 2, 3, 4 });
        Assert.Equal(10, total);
    }
}
