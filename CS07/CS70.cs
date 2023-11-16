
using System.Diagnostics;

namespace LanguageFeatures.Cs7
{
    
    public class CS7Tests
    {
        [Fact]
        public void CS7Test()
        {
            object[] numbers = {0b1, 0b10, new object[] { 122_345.6, 0b10, 0b100, 0b_1000 }, 0b1_00_00, 0b1000_00, "123", null }; // Binary literals with digit separators
            (int sum, int count) Tally(IEnumerable<object> list)        // Local Functions with tuple value types
            {
                var r = (sum: 0, count: 0);
                foreach (var v in list)
                {
                    switch (v)
                    {
                        case int i:                                     // Pattern matching Type Switch
                            r.sum += i;
                            r.count++;
                            break;
                        case IEnumerable<object> l when l.Any():
                            (int s, int c) = Tally(l);               // Tuple Deconstruction
                            r.sum += s;
                            r.count += c;
                            break;
                        case string iStr:
                            if (int.TryParse(iStr, out var parsed))     // out var
                            {
                                r.sum += parsed;
                                r.count++;
                            }
                            Assert.Equal(123, parsed);
                            break;
                        case null:
                            break;
                    }
                }
                return r;
            }
            var result = Tally(numbers);
            Trace.WriteLine($"Sum: {result.sum} Count: {result.count}");
            Assert.Equal(8, result.count);
        }

        [Fact]
        public void PatternMatch()
        {
            object p = new CS09.Employee();
            if (p is CS09.Employee)
            {
                var emp = (CS09.Employee)p;
                Assert.Equal(p, emp);
            }

            var emp1 = p as CS09.Employee;
            if (emp1 != null)
            {
                Assert.Equal(p, emp1);
            }

            if (p is CS09.Employee emp2)
            {
                Assert.Equal(p, emp2);
            }
        }

        [Fact]
        public void CS7RefLocal()
        {
            var value = "1";
            int y;
            if (int.TryParse(value, out y))
            {
                Assert.Equal(1, y);                                  // Old way
            }

            if (int.TryParse(value, out int x))                         // Ref local
            {
                Assert.Equal(1, x);
            }

            Assert.Equal(1, x);                                      // Ref local scope
        }

        [Fact]
        public void CS7ThrowExpressions()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                string s = null;
                if (s == null)
                {
                    throw new NullReferenceException("s is null");
                }

                var t = s ?? throw new NullReferenceException("s is null");
                Assert.Null(t);

            });
        }

        #region LessCommonFeatures
        [Fact]
        public async Task GeneralizedAsyncReturnTypes()
        {
            Assert.Equal(0, loadCount);
            Assert.Equal("Jim", await GetUserName());
            Assert.Equal(1, loadCount);
            Assert.Equal("Jim", await GetUserName());
            Assert.Equal(1, loadCount);
        }

        public ValueTask<string> GetUserName()
        {
            return loadCount == 0 ? new ValueTask<string>(Load()) : new ValueTask<string>(cachedName);
        }

        int loadCount = 0;
        string cachedName = null;
        private async Task<string> Load()
        {
            // Simulated delay
            await Task.Delay(100);
            cachedName = "Jim";
            loadCount += 1;
            return cachedName;
        }
        #endregion
    }
}
