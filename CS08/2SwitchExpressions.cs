﻿

namespace LanguageFeatures.Cs8
{
    
    public class SwitchExpressions
    {

        [Fact]
        public void MyTestMethod()
        {
            Assert.Equal("known bad", ValidateOld("Error"));
            Assert.Equal("known good", Validate("test"));
        }

        private static string ValidateOld(string? x)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            string? result;

            switch (x)
            {
                case "Error":
                    result = "known bad";
                    break;
                case "test":
                    result = "known good";
                    break;
                default:
                    result = "invalid";
                    break;
            }

            return result;
        }

        private static string Validate(string? x) => x switch
        {
            null => throw new NullReferenceException("x not set"),
            "error" => "known bad",
            "test" => "known good",
            string { Length: >= 5 } => "Too long",
            string { Length: < 4 } => "Too short",
            _ => "Valid"
        };

        [Fact]
        public void TestSwitchExpression()
        {
            var (a, b, option) = (10, 5, "+");

            var example1 = option switch
            {
                "+" => a + b,
                "-" => a - b,
                _ => a * b
            };

            Assert.Equal(15, example1);
        }

    }
}
