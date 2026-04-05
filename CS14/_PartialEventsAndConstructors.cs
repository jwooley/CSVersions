namespace LanguageFeatures.CS14;

public partial class _PartialEventsAndConstructors
{
    // Prior to C# 14, events and constructors could not be declared as partial.
    public partial event EventHandler? Updated;
    public partial _PartialEventsAndConstructors(string name);

    public string Name { get; }

    public void RaiseUpdated() => _updated?.Invoke(this, EventArgs.Empty);
}

public partial class _PartialEventsAndConstructors
{
    private EventHandler? _updated;

    public partial event EventHandler? Updated
    {
        add => _updated += value;
        remove => _updated -= value;
    }

    public partial _PartialEventsAndConstructors(string name)
    {
        Name = name;
    }

    public void RaiseWithBackingField() => _updated?.Invoke(this, EventArgs.Empty);
}

public class PartialEventsAndConstructorsBefore
{
    public event EventHandler? Updated;

    public PartialEventsAndConstructorsBefore(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void RaiseUpdated() => Updated?.Invoke(this, EventArgs.Empty);
}
