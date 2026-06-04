namespace LanguageFeatures.CS13;


internal class NewLockType
{
    private readonly object _legacyLock = new();
    private int _counter;

    public void IncrementBefore()
    {
        lock (_legacyLock)
        {
            _counter++;
        }
    }

    // C# 13 introduces a new lock type that is more efficient
    // and has better performance characteristics than the traditional lock statement.
    private readonly System.Threading.Lock _lock = new();
    public void Increment()
    {
        lock (_lock)
        {
            _counter++;
        }
    }

}
