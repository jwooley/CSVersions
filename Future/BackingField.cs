namespace LanguageFeatures.Future;

internal class BackingField
{
    public string Name { get; set => field = value.Trim(); }

    public class var
    {
        var x = 1;
    }
}


