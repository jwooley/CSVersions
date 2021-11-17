namespace LanguageFeatures.Cs8
{
    
    public class SimpleUsing
    {
        [Fact]
        public void OldUsing()
        {
            using (var tw = new StringWriter())
            {
                tw.Write("Test");
                Assert.Equal("Test", tw.ToString());
            }
            // but tw is out of scope now
            // tw.ToString();
        }

        [Fact]
        public void TestSimpleUsing()
        {
            using var tw = new StringWriter();
            tw.Write("Test");
            Assert.Equal("Test", tw.ToString());
        }
    }
}
