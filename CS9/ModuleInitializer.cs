using System.Runtime.CompilerServices;

namespace LanguageFeatures.CS9
{
    class ModuleInitializer
    {
        static string? somethingThatNeedsToBeInitializedFirst;

        [ModuleInitializer]
        internal static void Initializer()
        {
            somethingThatNeedsToBeInitializedFirst = "Must be important";
        }
    }
}
