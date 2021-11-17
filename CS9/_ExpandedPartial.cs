using System.Text.RegularExpressions;

namespace LanguageFeatures.CS9
{

    partial class ExpandedPartial
    {
        //[RegexGenerated("(dog|cat|fish)")]
        public partial bool IsPetMatch(string input);
    }

    partial class ExpandedPartial
    {
        // Previously partials needed to be
        // private, parameterless, return void, no out parameters
        public partial bool IsPetMatch(string input)
            => Regex.IsMatch(input, "(dog|cat|fish)");
    }
}
