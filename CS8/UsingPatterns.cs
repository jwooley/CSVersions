namespace LanguageFeatures.Cs8
{
    [TestClass]
    public class UsingPatterns
    {
        [TestMethod]
        public void OldUsing()
        {
            using (var tw = new StringWriter())
            {
                tw.Write("Test");
                Assert.AreEqual("Test", tw.ToString());
            }
            // but tw is out of scope now
            // tw.ToString();
        }

        [TestMethod]
        public void TestSimpleUsing()
        {
            using var tw = new StringWriter();
            tw.Write("Test");
            Assert.AreEqual("Test", tw.ToString());
        }
    }
}
