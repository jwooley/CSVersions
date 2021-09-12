namespace LanguageFeatures.CS10.FileScoped;

[TestClass]
public class FileScopedNamespace
{
    [TestMethod]
    public void TestNamespace()
    {
        var c = new Class2();
        Assert.AreEqual(
            "LanguageFeatures.CS10.FileScoped.Class2",
            c.GetType().FullName);

        var emp = new EmployeeStruct("Jim", "Wooley", "SDP");
        Assert.AreEqual(
            "LanguageFeatures.CS10.EmployeeStruct",
            emp.GetType().FullName);
    }
}

public class Class2
{

}

