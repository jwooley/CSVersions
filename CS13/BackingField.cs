namespace LanguageFeatures.CS13;

internal class BackingField
{
    //public string field;
    public string Name { get; set => field = value.Trim(); } = "";
}

internal class BackingFieldBefore
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value.Trim();
    }
}


