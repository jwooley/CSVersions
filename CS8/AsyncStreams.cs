namespace LanguageFeatures.Cs8
{
    [TestClass]
    public class AsyncStreams
    {
        [TestMethod]
        public async Task DoSomethingAsync()
        {
            var test = new TestAsyncList();
            Person last = new Person(); 
            await foreach (var person in test)
            {
                last = person;
                Console.WriteLine(person.Name);
            }
            Assert.AreEqual("Person 4", last.Name);
        }
    }


    public class TestAsyncList : IAsyncEnumerable<Person>, IAsyncEnumerator<Person>
    {
        private int returnedCount = 0;
        public Person Current => new Person { Name = $"Person {returnedCount}" };

        public ValueTask DisposeAsync()
        {
            // Nothing to dispose
            return new ValueTask();
        }

        public IAsyncEnumerator<Person> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return this;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            await Task.Delay(10);
            returnedCount++;
            return returnedCount < 5;
        }
    }
	public class Person
    {
		public string Name { get; set; }
    }
}
