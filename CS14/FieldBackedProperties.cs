namespace LanguageFeatures.CS14;

internal class FieldBackedProperties
{
    //string field;

    public string SimpleAuto { get; set; } = string.Empty;

    // If you want to do something more complex in the setter,
    // you can use the field directly without having to declare it yourself.
    // The compiler will generate a backing field for you and you can use it in the property accessors.
    public string Message
    {
        get;
        set => field = value ?? throw new ArgumentNullException(nameof(value));
    } = string.Empty;
}

internal class FieldBackedPropertiesBefore
{
    private string _message = string.Empty;

    public string Message
    {
        get => _message;
        set => _message = value ?? throw new ArgumentNullException(nameof(value));
    }
}
