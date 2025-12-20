using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: Extension Methods
    // ==========================================
    //
    // STORY LINE:
    // THE BACKPACK ATTACHMENT:
    // Imagine you bought a standard backpack (The Class).
    // It's a great backpack, but it doesn't have a water bottle holder.
    // The company that made it (Microsoft/Third Party) sealed the design. You cannot cut it open and sew a new pocket (Sealed Class / No Source Code).
    //
    // However, you can buy a "Clip-on Bottle Holder" (Extension Method).
    // You clip it onto the backpack.
    // Now, to anyone looking, it LOOKS like the backpack has a bottle holder.
    // You use it just like a built-in pocket: `myBackpack.HoldBottle()`.
    // But in reality, the holder is a separate accessory defined somewhere else.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // Extension methods allow you to "add" methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.
    // They are static methods, but they are called as if they were instance methods on the extended type.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - To add functionality to classes you don't own (like String, Int, List).
    // - To keep code clean and readable (Fluent API design).
    // - LINQ is built entirely on extension methods!
    //
    // ==========================================

    // 1. The "Clip-on" Factory (Must be a Static Class)
    public static class StringExtensions
    {
        // 2. The Extension Method (Must be Static)
        // The 'this' keyword before the first parameter tells C# what type we are extending.
        public static int WordCount(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string ToPirateSpeak(this string str)
        {
            return $"Yarr! {str} Ahoy!";
        }
    }

    class ExtensionMethods
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AdvancedConcepts.ExtensionMethods
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Extension Methods Demo ---");

            string message = "Hello world. This is C#.";

            // 3. Using the Extension Method
            // Even though 'WordCount' is not defined inside the String class, we call it like it is.
            int count = message.WordCount(); 
            
            Console.WriteLine($"Original: {message}"); // Output: Original: Hello world. This is C#.
            Console.WriteLine($"Word Count: {count}"); // Output: Word Count: 5

            // Another one
            Console.WriteLine(message.ToPirateSpeak()); // Output: Yarr! Hello world. This is C#. Ahoy!

            // Without extension methods, we would have to do this (Ugly):
            // int count2 = StringExtensions.WordCount(message);
        }
    }
}
