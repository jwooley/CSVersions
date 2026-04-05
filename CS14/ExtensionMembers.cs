namespace LanguageFeatures.CS14;

public static class StringExtensions
{
    extension(string value)
    {
        public bool IsBlank => string.IsNullOrWhiteSpace(value);

        public string Repeat(int count)
            => string.Concat(Enumerable.Repeat(value, count));
    }
}

public class ExtensionMembersTests
{
    public void ExtensionMembersNew()
    {
        var message = "hi";
        Assert.Equal("hihi", message.Repeat(2));
        Assert.False(message.IsBlank);
    }

    public void ExtensionMembersAfter()
    {
        var message = "hi";
        Assert.Equal("hihi", message.RepeatBefore(2));
    }
}

public static class StringExtensionsBefore
{
    public static bool IsBlankBefore(this string value) => string.IsNullOrWhiteSpace(value);

    public static string RepeatBefore(this string value, int count)
        => string.Concat(Enumerable.Repeat(value, count));
}
