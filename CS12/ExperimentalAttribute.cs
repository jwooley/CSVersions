using System.Diagnostics.CodeAnalysis;

namespace LanguageFeatures.CS12
{
    public class UseExperimental
    {
        public void TestIt()
        {
#pragma warning disable MY1234 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            var tester = new SomethingWithExperimentalFeatures();
            Console.WriteLine(tester.DoSomethingExperimental("Foo"));
#pragma warning restore MY1234 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        }
    }

    [Experimental("MY1234")]
    public class SomethingWithExperimentalFeatures
    {
        public string DoSomethingExperimental(string input)
        {
            // This implementation may change beware.
            return input;
        }
    }
}
