

namespace LanguageFeatures.Cs7
{
    class Program
    {
        // Async Main
        static async Task Main(string[] args)
        {
            await Task.FromResult(0);
        }
    }

    
    public class CS71
    {
        [Fact]
        public void CS71_DefaultLiteralExpresions()
        {
            Func<string, bool> whereOld = default(Func<string, bool>);
            Assert.Null(whereOld);

            Func<string, bool> whereClause = default;
            Assert.Null(whereClause);

            int? i = default;
            Assert.False(i.HasValue);

            int j = default;
            Assert.Equal(0, j);
        }

        [Fact]
        public void CS71_InferredTupleElementNames()
        {
            int theAnswer = 42;
            var q1 = (theAnswer: theAnswer, PI: Math.PI);
            Assert.Equal(42, q1.theAnswer);

            var q2 = (theAnswer, Math.PI);
            Assert.Equal(42, q2.theAnswer);
        }
    }
}
