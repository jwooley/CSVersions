namespace LanguageFeatures.CS13;

internal class ImplicitIndexerAccessInObjectInitializers
{
    private class Buffer
    {
        public int[] Data { get; } = new int[4];
    }

    // C# 14 allows implicit indexer access in object initializers.
    // This means that you can use the indexer syntax to
    // initialize elements of an array or collection property directly
    // within an object initializer.
    public void Demo()
    {
        var value = new Buffer
        {
            Data =
            {
                [^1] = 1,
                [^2] = 2,
                [^3] = 3,
                [^4] = 4,
            }
        };

        Assert.Equal("4,3,2,1", string.Join(",", value.Data));
    }

    public void DemoBefore()
    {
        var value = new Buffer();
        value.Data[^1] = 1;
        value.Data[^2] = 2;
        value.Data[^3] = 3;
        value.Data[^4] = 4;

        Assert.Equal("4,3,2,1", string.Join(",", value.Data));
    }
}
