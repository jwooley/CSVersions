using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11
{
    public class RawStringLiterals
    {
        [Fact]
        public void RawStringLiterals_RemovesExtraIndentationAndDoesntNeedQuoteEscaping()
        {
            var oldMultiLineString = @"var someString = ""this is a value"";
if (true)
{
    Console.WriteLine(someString);
}";

            var rawStringLiteralVersion = """
                var someString = "this is a value";
                if (true)
                {
                    Console.WriteLine(someString);
                }
             """;


            Assert.Equal(oldMultiLineString, rawStringLiteralVersion);
        }

        [Fact]
        public void RawStringLiterals_DollarSignsIndicatePlaceholderCount()
        {
            var expected = "String with \"{placeholder}\" ";
            var value = "placeholder";
            var concatenated = $$"""String with "{{{value}}}" """;
            Assert.Equal(expected, concatenated);
        }
    }
}
