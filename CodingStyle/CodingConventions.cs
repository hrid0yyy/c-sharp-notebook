using System;
using System.Collections.Generic;
using System.Text;

namespace Concepts.CodingStyle
{
    // ==========================================
    // Topic: C# Coding Conventions, For more: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
    // ==========================================
    //
    // WHY USE THEM?
    // - Maintainability: Code is easier to read and modify.
    // - Clarity: Reduces ambiguity (e.g., knowing when to use 'var').
    // - Modernization: Encourages using new, cleaner language features.
    //
    // KEY GUIDELINES:
    // Utilize modern language features and C# versions whenever possible.
    // Avoid outdated language constructs.
    // Only catch exceptions that can be properly handled; avoid catching general exceptions. For example, sample code shouldn't catch the System.Exception type without an exception filter.
    // Use specific exception types to provide meaningful error messages.
    // Use LINQ queries and methods for collection manipulation to improve code readability.
    // Use asynchronous programming with async and await for I/O-bound operations.
    // Be cautious of deadlocks and use Task.ConfigureAwait when appropriate.
    // Use the language keywords for data types instead of the runtime types. For example, use string instead of System.String, or int instead of System.Int32. This recommendation includes using the types nint and nuint.
    // Use int rather than unsigned types. The use of int is common throughout C#, and it's easier to interact with other libraries when you use int. Exceptions are for documentation specific to unsigned data types.
    // Use var only when a reader can infer the type from the expression. Readers view our samples on the docs platform. They don't have hover or tool tips that display the type of variables.
    // Write code with clarity and simplicity in mind.
    // Avoid overly complex and convoluted code logic.
    //
    // ==========================================

    class CodingConventions
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.CodingStyle.CodingConventions
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Coding Conventions Demo ---");

            // 1. Implicit Typing (var)
            // GOOD: Type is obvious from the right side.
            var message = "Hello World"; 
            var count = 10;
            var sb = new StringBuilder();

            // BAD: Type is not obvious.
            // var result = GetResult(); // What does this return? int? string? bool?
            // BETTER:
            // int result = GetResult();

            Console.WriteLine($"1. var usage: {message}");

            // 2. String Interpolation
            string firstName = "John";
            string lastName = "Doe";
            
            // BAD
            string fullNameOld = firstName + " " + lastName;
            
            // GOOD
            string fullNameNew = $"{firstName} {lastName}";
            Console.WriteLine($"2. String Interpolation: {fullNameNew}");

            // 3. Object Initializers
            // BAD
            Person p1 = new Person();
            p1.FirstName = "Alice";
            p1.LastName = "Smith";

            // GOOD
            Person p2 = new Person 
            { 
                FirstName = "Bob", 
                LastName = "Jones" 
            };
            Console.WriteLine($"3. Object Initializer: {p2.FirstName} {p2.LastName}");

            // 4. Collection Expressions (C# 12+) & Initializers
            // OLD
            List<string> fruitsOld = new List<string>();
            fruitsOld.Add("Apple");
            fruitsOld.Add("Banana");

            // NEW (Collection Expression)
            // List<string> fruitsNew = ["Apple", "Banana"]; // Requires .NET 8+
            
            // STANDARD (Collection Initializer)
            List<string> fruitsStandard = new List<string> { "Apple", "Banana" };
            Console.WriteLine($"4. Collections: {string.Join(", ", fruitsStandard)}");

            // 5. Using Statements (Resource Management)
            // OLD Way (Requires braces)
            using (var oldResource = new DummyResource("Old"))
            {
                oldResource.DoWork();
            } // Disposed here

            // NEW Way (No braces, disposed at end of scope)
            using var newResource = new DummyResource("New");
            newResource.DoWork();
            
            Console.WriteLine("End of Main method. 'newResource' will be disposed now.");
        } // 'newResource' is disposed here

        static int GetResult() => 42;
    }

    class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

    class DummyResource : IDisposable
    {
        private string _name;
        public DummyResource(string name) => _name = name;
        public void DoWork() => Console.WriteLine($"  Using resource: {_name}");
        public void Dispose() => Console.WriteLine($"  Disposing resource: {_name}");
    }
}
