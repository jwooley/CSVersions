namespace LanguageFeatures.CS14;

public class _NameofUnboundGenericType
{
    [Fact]
    public void Demo()
    {
        // With C# 14, nameof can be used without specifying the generic type.
        Assert.Equal("List", nameof(List<>));
    }

    [Fact]
    public void DemoBefore()
    {
        Assert.Equal("List", nameof(List<int>));
    }
}
