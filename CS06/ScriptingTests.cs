using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LanguageFeaturesCS.CS6
{
    public class ScriptingTests
    {
        [Fact]
        public async Task Scripting_CanAddValues()
        {
            var result = await CSharpScript.EvaluateAsync<int>("1 + 2");
            Assert.Equal(3, result);
        }

        [Fact]
        public async Task Scripting_CanGetErrors()
        {
            try
            {
                Console.WriteLine(await CSharpScript.EvaluateAsync("throw new System.Exception()"));
                throw new InvalidOperationException("Should have thrown");
            }
            catch (CompilationErrorException e)
            {
                Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics));
            }
        }

        [Fact]
        public async Task Scripting_CanAddReferences()
        {
            var result = await CSharpScript.EvaluateAsync("System.Net.Dns.GetHostName()",
                ScriptOptions.Default.WithReferences(typeof(System.Net.Dns).Assembly));
        }

        [Fact]
        public async Task Scripting_Imports()
        {
            var result = await CSharpScript.EvaluateAsync<Double>("Sqrt(4)",
                ScriptOptions.Default.WithImports("System.Math"));
            Assert.Equal(2.0, result);
        }

        public class ParamaterGlobals
        {
            public int X;
            public int Y;
        }
        [Fact]
        public async Task Scripting_PassingParameters()
        {
            var parameters = new ParamaterGlobals { X = 1, Y = 2 };
            Assert.Equal(3, await CSharpScript.EvaluateAsync<int>("X+Y", globals: parameters));
        }

        [Fact]
        public async Task Scripting_ReusePrecompiledScript()
        {
            var script = CSharpScript.Create<int>("int z = X - Y;", globalsType: typeof(ParamaterGlobals));
            script.Compile();
            for (int i = 0; i < 10; i++)
            {
                var result = await script.RunAsync(new ParamaterGlobals { X = i, Y = i - 1 });
                Assert.Equal(1, (int)result.Variables[0].Value);
            }
        }

        [Fact]
        public async Task Scripting_ChainValues()
        {
            var script = CSharpScript.Create<int>("int x = 1;")
                .ContinueWith("int y = 2;")
                .ContinueWith("x + y");
            Assert.Equal(3, (int)(await script.RunAsync()).ReturnValue);
        }
    }
}
