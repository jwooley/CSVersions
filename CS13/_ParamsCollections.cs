namespace LanguageFeatures.CS13;

internal class ParamsCollections
{
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
