namespace LanguageFeatures.CS13;

public class EscapeSequence
{
    [Fact]
    public void Demo()
    {
        // C# 14 allows the use of \e as an escape sequence for the ASCII escape character (ESC, 27).
        var esc = '\e';
        Assert.Equal(27, (int)esc);
        Console.WriteLine("\e[1mThis is a bold text\e[0m");
    }

    [Fact]
    public void DemoBefore()
    {
        var esc = '\x1b';
        Assert.Equal(27, (int)esc);
    }
}
