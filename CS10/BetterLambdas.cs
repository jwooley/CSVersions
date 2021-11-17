using System.Linq.Expressions;

namespace LanguageFeatures.CS10;

public class BetterLambdas
{
    [Fact]
    public void Test()
    {
        var old = new Func<int, int, int>((x, y) => x * y);
        var old2 = (Func<int, int, int>)((x, y) => x * y);

        var newLambda = (int x, int y) => x * y;

        Expression<Func<int, int, int>> newExpression = (int x, int y) => x * y;

        Assert.Equal(old(1, 2), newLambda(1, 2));
        Assert.Equal(old(1, 2), newExpression.Compile().Invoke(1, 2));
    }
}
