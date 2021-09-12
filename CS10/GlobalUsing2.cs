[TestClass]
public class GlobalUsing2
{
    [TestMethod]
    public void UsingFromGlobalUsing()
    {
        Assert.AreEqual(1, Abs(1 - 2));
    }
}
