// C# 9.0 introduced top-level statements, which allow you to write code directly in the global scope without needing to define a class or a Main method. This feature simplifies the syntax for small programs and scripts.
// Disabled in the unit test project as it causes the test runner to not be able to discover the tests,
// but you can enable it by setting the LangVersion to 9.0 or later in your project file. Here's an example of how to use top-level statements:

System.Console.WriteLine("Hello World");