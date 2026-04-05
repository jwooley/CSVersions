namespace LanguageFeatures.CS14;

internal class LambdaParameterModifiers
{
    private delegate bool TryParseInt(string text, out int value);

    public bool Demo(string text, out int value)
    {
        TryParseInt parser = (text, out value) => int.TryParse(text, out value);
        return parser(text, out value);
    }

    public bool DemoBefore(string text, out int value)
    {
        return Parse(text, out value);

        static bool Parse(string input, out int parsedValue)
            => int.TryParse(input, out parsedValue);
    }
}
