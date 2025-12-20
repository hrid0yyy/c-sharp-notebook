using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: Data Types (Value vs Reference)
    // ==========================================
    //
    // STORY LINE:
    // THE PHOTOCOPY VS THE SHARED DOCUMENT:
    //
    // 1. VALUE TYPES (The Photocopy):
    //    Imagine you have a drawing (int, bool, struct).
    //    When you give it to a friend, you give them a PHOTOCOPY.
    //    If they draw a mustache on their copy, YOUR original drawing is unchanged.
    //    They live on the Stack (fast, temporary).
    //
    // 2. REFERENCE TYPES (The Shared Document):
    //    Imagine a Google Doc (class, string, array).
    //    When you share it, you send a LINK (URL).
    //    If your friend edits the document via the link, YOU see the changes too.
    //    They live on the Heap (larger, garbage collected).
    //
    // ==========================================

    class DataTypes
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.CoreFundamentals.DataTypes
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Data Types Demo ---");

            // 1. Value Types
            Console.WriteLine("\n1. Value Types (The Photocopy):");
            int a = 10;
            int b = a; // Copy the value
            b = 20;    // Change the copy
            Console.WriteLine($"  Original 'a': {a} (Unchanged)");
            Console.WriteLine($"  Copy 'b': {b}");

            // 2. Reference Types
            Console.WriteLine("\n2. Reference Types (The Shared Link):");
            PersonRef p1 = new PersonRef { Name = "Alice" };
            PersonRef p2 = p1; // Copy the reference (link)
            p2.Name = "Bob"; // Change the object via the second link
            Console.WriteLine($"  Original 'p1.Name': {p1.Name} (Changed!)");
            Console.WriteLine($"  Copy 'p2.Name': {p2.Name}");

            // 3. Strings (Special Reference Type)
            Console.WriteLine("\n3. Strings (Immutable Reference):");
            string s1 = "Hello";
            string s2 = s1;
            s2 = "World"; // Creates a NEW string, doesn't change the old one
            Console.WriteLine($"  Original 's1': {s1}");
            Console.WriteLine($"  Copy 's2': {s2}");
        }
    }

    class PersonRef
    {
        public string Name { get; set; } = "";
    }
}
