namespace LanguageFeatures.CS12;

internal class CollectionExpression
{
    public void Test()
    {
        // Old
        DoSomething(new List<decimal> { 1.2m, 1.3m });
        // Collection initializers
        List<decimal> nums = [1.2m, 1.3m];
        DoSomething(nums);

        // Target-typed collection expressions
        DoSomething(new());
        DoSomething([1.2m, 1.3m]);
        DoSomething([]);
        IEnumerable<int> ints = [1, 2, 3];

        // The following are not collection expressions,
        // but array literals and dictionary literals, which are not yet supported.
        //var stillNotSure = [1, 2, 3];
        // In progress, but not yet supported: https://github.com/dotnet/csharplang/issues/8659
        //var dictionaryLiteral = ["first": 1, "second": 2];

        decimal[] more = [3.1m, 4.2m];
        decimal[] combinedUsingSpreadOperator = [.. nums, .. more];
    }
    public void DoSomething(List<decimal> items)
    {
        items.Sum();
    }
}
