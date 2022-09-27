namespace LanguageFeatures.CS11;

public partial class FileAccessModifier
{
    public void Test2()
    {
        this.Test();
        new Restricted().CantTouchThis();
    }
}

file class Restricted
{
    public void CantTouchThis()
    {
        Console.WriteLine("Only In this file");
    }
}
