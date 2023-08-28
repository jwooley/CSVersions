namespace LanguageFeatures.CS12;

internal class CollectionExpression
{
    public void Test()
    {
        // Old
        DoSomething(new List<decimal> { 1.2m, 1.3m });
        // New
        List<decimal> nums = [1.2m, 1.3m];
        DoSomething(nums);

        DoSomething(new());
        DoSomething([1.2m, 1.3m]);
        DoSomething([]);
        //var stillNotSure = [1, 2, 3];
        //var dictionaryLiteral = ["first": 1, "second": 2];

        decimal[] more = [3.1m, 4.2m];
        decimal[] combined = [.. nums, .. more];
    }
    public void DoSomething(List<decimal> items)
    {
        items.Sum();
    }
}
