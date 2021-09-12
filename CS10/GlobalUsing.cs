global using System;
global using static System.Math;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageFeatures.CS10;

[TestClass]
public class GlobalUsing
{
    [TestMethod]
    public void TestUsing()
    {
        Assert.AreEqual(1, Abs(1 - 2));
    }
}
