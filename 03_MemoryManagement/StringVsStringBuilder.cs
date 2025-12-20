using System;
using System.Text;
using System.Diagnostics;

namespace Concepts
{
    // ==========================================
    // Topic: String vs StringBuilder
    // ==========================================
    //
    // STORY LINE:
    // Imagine you are writing a letter.
    //
    // STRING (The Notebook Page):
    // You write "Hello". Then you decide to add " World".
    // Because the page is "Immutable" (cannot be changed once written), you cannot just add words.
    // You have to tear out the page, take a NEW page, and write "Hello World" from scratch.
    // If you add "!", you tear that page out, take a NEW one, and write "Hello World!".
    // This creates a lot of waste (memory garbage) if you do it thousands of times.
    //
    // STRINGBUILDER (The Whiteboard):
    // You have a whiteboard. You write "Hello".
    // You want to add " World". You just pick up the marker and write it next to "Hello".
    // No new board needed. It is "Mutable" (changeable).
    // You can append, remove, and replace text efficiently without creating new objects every time.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - String: An immutable sequence of characters. Any modification creates a new string object in memory.
    // - StringBuilder: A mutable sequence of characters. Modifications happen in place.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Performance: Concatenating strings in a loop using '+' is very slow and memory-intensive because it creates a new object for every iteration.
    // - StringBuilder is designed for scenarios where you need to modify a string many times (e.g., building a large report, processing text).
    //
    // ------------------------------------------
    // REAL LIFE SCENARIO:
    // - Generating a large CSV file from a database.
    // - Constructing a long SQL query dynamically.
    // - Logging systems where messages are built piece by piece.
    //
    // ==========================================

    class StringVsStringBuilder
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.StringVsStringBuilder
        public static void Main(string[] args)
        {
            Console.WriteLine("--- String vs StringBuilder Demo ---"); // Output: --- String vs StringBuilder Demo ---

            int iterations = 10000; // Try increasing this to 50000 to see a huge difference

            // 1. Using String (The Slow Way)
            Console.WriteLine($"Concatenating {iterations} times using String..."); // Output: Concatenating 10000 times using String...
            Stopwatch sw = Stopwatch.StartNew();
            string s = "";
            for (int i = 0; i < iterations; i++)
            {
                s += "a"; // Creates a new string object EVERY time!
            }
            sw.Stop();
            Console.WriteLine($"String took: {sw.ElapsedMilliseconds} ms"); // Output: String took: [Time] ms

            // 2. Using StringBuilder (The Fast Way)
            Console.WriteLine($"Concatenating {iterations} times using StringBuilder..."); // Output: Concatenating 10000 times using StringBuilder...
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("a"); // Modifies the existing buffer
            }
            string result = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder took: {sw.ElapsedMilliseconds} ms"); // Output: StringBuilder took: [Time] ms

            Console.WriteLine("\nConclusion: StringBuilder is MUCH faster for repeated modifications."); // Output: \nConclusion: StringBuilder is MUCH faster for repeated modifications.
        }
    }
}
