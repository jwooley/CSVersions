namespace LanguageFeatures.CS10.FileScoped; 

public class FileScopedNamespace
{
    [Fact]
    public void TestNamespace()
    {
        var c = new Class2();
        Assert.Equal(
            "LanguageFeatures.CS10.FileScoped.Class2",
            c.GetType().FullName);

        var emp = new EmployeeStruct("Jim", "Wooley", "SDP");
        Assert.Equal(
            "LanguageFeatures.CS10.EmployeeStruct",
            emp.GetType().FullName);
    }
}

public class Class2
{

}

