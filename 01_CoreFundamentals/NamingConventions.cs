using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: C# Naming Conventions , For More: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
    // ==========================================
    //
    // WHY USE THEM?
    // - Consistency: Makes code look like it was written by one person.
    // - Readability: Helps distinguish between types, variables, and fields at a glance.
    // - Professionalism: Follows the standard .NET guidelines used by Microsoft.
    //
    // KEY RULES:
    // Interface names start with a capital I.

    // Attribute types end with the word Attribute.

    // Enum types use a singular noun for nonflags, and a plural noun for flags.

    // Identifiers shouldn't contain two consecutive underscore (_) characters. Those names are reserved for compiler-generated identifiers.

    // Use meaningful and descriptive names for variables, methods, and classes.

    // Prefer clarity over brevity.

    // Use PascalCase for class names and method names.

    // Use camelCase for method parameters and local variables.

    // Use PascalCase for constant names, both fields and local constants.

    // Private instance fields start with an underscore (_) and the remaining text is camelCased.

    // Static fields start with s_. This convention isn't the default Visual Studio behavior, nor part of the Framework design guidelines, but is configurable in editorconfig.

    // Avoid using abbreviations or acronyms in names, except for widely known and accepted abbreviations.

    // Use meaningful and descriptive namespaces that follow the reverse domain name notation.

    // Choose assembly names that represent the primary purpose of the assembly.

    // Avoid using single-letter names, except for simple loop counters. Also, syntax examples that describe the syntax of C# constructs often use the following single-letter names that match the convention used in the C# language specification. Syntax examples are an exception to the rule.

    // Use S for structs, C for classes.
    // Use M for methods.
    // Use v for variables, p for parameters.
    // Use r for ref parameters.
    //
    // ==========================================

    // Rule: Use PascalCase for Class names
    public class NamingConventions
    {
        // Rule: Use PascalCase for Constants
        public const int MaxRetries = 3;

        // Rule: Use _camelCase for Private Fields
        private string _userName;

        // Rule: Use PascalCase for Properties
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        // Rule: Use PascalCase for Methods
        public void UpdateUserInfo(string newName, int newAge) // Rule: Use camelCase for Parameters
        {
            // Rule: Use camelCase for Local Variables
            string formattedName = newName.Trim();
            
            _userName = formattedName;
            Console.WriteLine($"User updated: {_userName}, Age: {newAge}");
        }

        // Rule: Use PascalCase for Events
        public event Action OnUserUpdated;
    }

    // Rule: Interfaces start with 'I' and use PascalCase
    public interface ILogger
    {
        void Log(string message);
    }

    // Rule: Enums use PascalCase (Singular for standard enums)
    public enum UserRole
    {
        Admin,
        User,
        Guest
    }

    // Rule: Generic Type Parameters use 'T' prefix
    public class Repository<TEntity>
    {
        public void Add(TEntity entity) { }
    }

    // Entry point for the demo
    class NamingDemo
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.CodingStyle.NamingDemo
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Naming Conventions Demo ---");
            Console.WriteLine("This file demonstrates standard C# naming rules.");
            Console.WriteLine("Please read the code comments to understand the conventions.");
            
            var demo = new NamingConventions();
            demo.UpdateUserInfo("  Alice  ", 30);
        }
    }
}
