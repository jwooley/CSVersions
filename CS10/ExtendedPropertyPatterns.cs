using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS10;

[TestClass]
public class ExtendedPropertyPatterns
{
    [TestMethod]
    public void CanFilterExtendedPropertyPattern()
    {
        var person = new ComplexEmployee("Jim", "Wooley", "SDP",
            new ComplexEmployee("My", "Manager", "Director", null));

        Assert.IsTrue(IsManagedBy(person));
        Assert.IsTrue(IsManagedExtended(person));
    }

    bool IsManagedBy(ComplexEmployee test) =>
        test is { Manager: { last: "Manager" } };

    bool IsManagedExtended(ComplexEmployee test) =>
        test is { Manager.last: "Manager" };
}

record ComplexEmployee(string first, string last, string title, ComplexEmployee Manager)
    : EmployeeClass(first, last, title);

