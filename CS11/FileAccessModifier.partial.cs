namespace LanguageFeatures.CS11;
// For a description of the motivation of this feature and a bit
// of a behind the scenes around the language design process
// See https://www.youtube.com/watch?v=ArN9R_8eL-E&list=PLdo4fOcmZ0oVlqu_V8EXUDDnPsYwemxjn&index=26
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
