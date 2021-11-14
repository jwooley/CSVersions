public class GlobalUsing2
{
    [Fact]
    public void UsingFromGlobalUsing()
    {
        Assert.Equal(1, Abs(1 - 2));
    }
}
