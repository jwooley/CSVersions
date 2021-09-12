using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageFeatures.Cs8
{
    [TestClass]
    public class SwitchExpressions
    {
        [TestMethod]
        public void TestSwitchExpression()
        {
            var (a, b, option) = (10, 5, "+");

            var example1 = option switch
            {
                "+" => a + b,
                "-" => a - b,
                _ => a * b
            };

            Assert.AreEqual(15, example1);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual("known bad", ValidateOld("Error"));
            Assert.AreEqual("known good", Validate("test"));
        }

        private static string ValidateOld(string? x)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            string? result;

            if (x == "Error")
                result = "known bad";
            else if (x == "test")
                result = "known good";
            else
                result = "invalid";

            return result;
        }

        private static string Validate(string? x)
        {
            return x switch
            {
                null => throw new NullReferenceException("x not set"),
                "error" => "known bad",
                "test" => "known good",
                string { Length: >= 5 } => "Too long",
                string { Length: < 4 } => "Too short",
                _ => "invalid"
            };
        }
    }
}
