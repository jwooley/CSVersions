namespace LanguageFeatures.CS13;

internal class NewLockType
{
    private readonly System.Threading.Lock _lock = new();
    private readonly object _legacyLock = new();
    private int _counter;

    public void Increment()
    {
        lock (_lock)
        {
            _counter++;
        }
    }

    public void IncrementBefore()
    {
        lock (_legacyLock)
        {
            _counter++;
        }
    }
}
