global using System;
global using System.IO;
global using System.Linq;
global using static System.Math;
global using Xunit;
global using System.Threading.Tasks;
// Moved to project file
// global using System.Collections.Generic;

namespace LanguageFeatures.CS10;

public class GlobalUsing
{
    [Fact]
    public void TestUsing()
    {
        Assert.Equal(1, Abs(1 - 2));
    }
}
