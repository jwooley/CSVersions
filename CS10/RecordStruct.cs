using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageFeatures.CS10
{
    record struct EmployeeStruct(string NameFirst, string NameLast, string Title);
    record class EmployeeClass(string NameFirst, string NameLast, string Title);

    [TestClass]
    public class RecordStruct
    {
        [TestMethod]
        public void RecordEquality()
        {
            var e1 = new EmployeeStruct("Jim", "Wooley", "SA");
            // e1.Title = "Sr Delivery Principal";
            var e2 = e1 with { Title = "Sr Delivery Principal" };
            var e3 = new EmployeeStruct("Jim", "Wooley", "SA");

            var e4 = new EmployeeClass("Jim", "Wooley", "SA");

            Assert.IsFalse(e1 == e2);
            Assert.IsTrue(e1.Equals(e3));
            Assert.IsTrue(e1 == e3);

            Assert.AreNotEqual(e1.ToString(), e4.ToString());

            var (first, last, title) = e1;
            
            Console.WriteLine(first);
            Console.WriteLine(last);
            Console.WriteLine(title);
        }
    }
}
