namespace LanguageFeatures.CS14;

public static class StringExtensionsBefore
{
    public static bool IsBlankBefore(this string value) => string.IsNullOrWhiteSpace(value);

    public static string RepeatBefore(this string value, int count)
        => string.Concat(Enumerable.Repeat(value, count));
}

public static class StringExtensions
{
    extension(string value)
    {
        // Extension Methods allow you to define methods that can be called as if they were instance methods of the extended type.
        public string Repeat(int count)
            => string.Concat(Enumerable.Repeat(value, count));

        // Extension Properties allow you to define properties that can be accessed
        // as if they were instance properties of the extended type.
        // They can not have a setter, but they can be used to provide additional information or functionality related to the extended type.
        public bool IsBlank => string.IsNullOrWhiteSpace(value);

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
        Assert.False(message.IsBlankBefore());
    }
}
