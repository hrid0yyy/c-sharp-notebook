using System;

namespace Concepts.MemoryManagement
{
    // ==========================================
    // Topic: Records (C# 9.0+)
    // ==========================================
    //
    // STORY LINE:
    // THE PHOTOCOPY:
    //
    // CLASS (The Clay Model):
    // You make a clay model of a car.
    // You can squish the clay and change the shape (Mutable).
    // If you want to compare two clay models, you have to look at every inch. Even if they look alike, they are two different lumps of clay (Reference Equality).
    //
    // RECORD (The Printed Document):
    // You print a document with data: "Name: John, Age: 30".
    // Once printed, you cannot change the ink on the paper (Immutable).
    // If you want to change the age to 31, you don't erase the ink. You print a NEW document with the new age (Non-destructive Mutation).
    // If you have two documents with the exact same text, they are considered "Equal" (Value Equality).
    //
    // ------------------------------------------
    // WHAT IS IT?
    // A Record is a special reference type that provides built-in functionality for encapsulating data.
    // It defaults to value-based equality (two records are equal if their data is equal) and immutability.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Perfect for DTOs (Data Transfer Objects) where you just want to hold data.
    // - Reduces boilerplate code (no need to write Equals, GetHashCode, ToString).
    // - Thread-safe because they are immutable.
    //
    // ==========================================

    // 1. Defining a Record (One line!)
    // This creates a class with properties Name and Age, a constructor, and deconstructor.
    public record PersonRecord(string Name, int Age);

    // 2. Defining a Class (The old way, for comparison)
    public class PersonClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonClass(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Records
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.OOP.Records
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Records Demo ---"); // Output: --- Records Demo ---

            // 1. Creation
            var r1 = new PersonRecord("Alice", 25);
            var r2 = new PersonRecord("Alice", 25);
            
            var c1 = new PersonClass("Alice", 25);
            var c2 = new PersonClass("Alice", 25);

            // 2. Equality Check
            Console.WriteLine("\n1. Equality:"); // Output: \n1. Equality:
            Console.WriteLine($"Record 1 == Record 2: {r1 == r2}"); // Output: Record 1 == Record 2: True
            Console.WriteLine($"Class 1 == Class 2:   {c1 == c2}"); // Output: Class 1 == Class 2:   False

            // 3. Immutability & "With" expression
            Console.WriteLine("\n2. Mutation (The 'With' keyword):"); // Output: \n2. Mutation (The 'With' keyword):
            // r1.Age = 26; // Error! Cannot change property.

            // Create a copy of r1, but change Age to 26.
            var r3 = r1 with { Age = 26 };
            
            Console.WriteLine($"Original: {r1}"); // Output: Original: PersonRecord { Name = Alice, Age = 25 }
            Console.WriteLine($"New Copy: {r3}"); // Output: New Copy: PersonRecord { Name = Alice, Age = 26 }

            // 4. Deconstruction
            Console.WriteLine("\n3. Deconstruction:"); // Output: \n3. Deconstruction:
            var (name, age) = r1;
            Console.WriteLine($"Name: {name}, Age: {age}"); // Output: Name: Alice, Age: 25
        }
    }
}
