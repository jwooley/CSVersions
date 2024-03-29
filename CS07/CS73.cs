﻿

namespace LanguageFeatures.Cs7
{
    /// <summary>
    /// CS main themes:
    /// <list type="bullet">
    /// <item>Better performance for safe code</item>
    /// <item>Incremental improvements to existing features</item>
    /// </list>
    /// </summary>
    
    public class CS73
    {
        public int ExpressionVariablesInInitializer = int.TryParse("42", out var answer) ? 0 : answer;

        [Fact]
        public void CS73_ExpressionVariablesInLinq()
        {
            var vals = Enumerable.Range(1, 10);
            var evens = vals
                .Select(v => v.ToString())
                .Select(v => int.TryParse(v, out var value) ? value : -1)
                .Where(v => v % 2 == 0);
        }

        [Fact]
        public void CS73_TupleEqualityComparisons()
        {
            var t1 = (x: 1, Y: "two");
            var t2 = (a: 1, b: "two");
            var t3 = (Y: "two", x: 1);
            Assert.Equal(t1, t2);
            Assert.False(t1.Equals(t3));
        }

        #region CS73_IndexFixedFieldsWithoutPinning()
        private unsafe struct S
        {
            public fixed int myFixedField[10];
        }
        class C
        {
            static S s = new S();
            unsafe public void CsNew()
            {
                int p = s.myFixedField[5];
            }
            unsafe public void Old()
            {
                fixed(int* ptr = s.myFixedField)
                {
                    int p = ptr[5];
                }
            }
        }
        #endregion

        [Fact]
        public void CS73_ReassigningRefLocals()
        {
        }

        [Fact]
        unsafe public void CS73_StackallocArrayInitializers()
        {
            var old = new int[] { 1, 2, 3 };
            int* cs73a = stackalloc int[] { 1, 2, 3 };

            Assert.Equal(2, cs73a[1]);
        }

        [Fact]
        unsafe public void CS73_FixedWorksWithGetPinnableReference()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
            Span<int> teens = new Span<int>(primes, 4, 4);

            fixed(int* ptrToTeens = teens)
            {
                var sum = 0;
                for(int i = 0; i < teens.Length; i++)
                {
                    sum += *(ptrToTeens + i);
                }
                Assert.Equal(60, sum);
            }
            Assert.Equal(teens[0], 11);
        }

        [Fact]
        public void CS73_AdditionalGenericConstraints()
        {
            M<Action<string>, System.ConsoleColor, CS73>(x => Console.Write(x), System.ConsoleColor.Black, this);

            void M<D,E,O>(D d, E e, O o)
                where D: Delegate
                where E: Enum
                where O: new()
            {
                // Do something with these values
                Assert.True(d is Delegate);
                Assert.True(e is Enum);
                Assert.True(o is Object);
            }
        }

    }
}
