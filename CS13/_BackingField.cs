// This code was proposed for C#13, but not released until C#14.
namespace LanguageFeatures.CS13;

internal class BackingFieldBefore
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value.Trim();
    }
}

internal class _BackingField
{
    //public string field;
    public string Name { get; set => field = value.Trim(); } = "";
}
