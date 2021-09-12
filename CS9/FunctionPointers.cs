namespace LanguageFeatures.CS9
{
    unsafe class FunctionPointers
    {
        void Example(Action<int> a, delegate*<int, void> f)
        {
            a(42);
            f(42);
        }
    }
}
