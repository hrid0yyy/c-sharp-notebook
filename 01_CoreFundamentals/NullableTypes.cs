using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: Nullable Types
    // ==========================================
    //
    // STORY LINE:
    // THE MYSTERY BOX:
    //
    // VALUE TYPE (The Coin):
    // An integer (`int`) is like a coin in your pocket. You ALWAYS have a coin.
    // It can be 0 cents, 5 cents, or 100 cents. But it is NEVER "nothing".
    // You cannot have "no coin" if the rule says "You must have a coin".
    //
    // NULLABLE TYPE (The Box):
    // A nullable integer (`int?`) is a small box.
    // You can open the box.
    // Scenario A: There is a coin inside (HasValue = true).
    // Scenario B: The box is empty (HasValue = false, or null).
    //
    // Before you spend the coin, you MUST check if the box is empty.
    // If you try to spend an empty box, the shopkeeper gets confused (InvalidOperationException).
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Value types (int, bool, double) cannot be null by default.
    // - `Nullable<T>` or `T?` allows a value type to hold a null value.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Databases! A database column for "Age" might be NULL (unknown).
    // - Forms! A user might skip the "Phone Number" field.
    //
    // ==========================================

    class NullableTypes
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AdvancedConcepts.NullableTypes
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Nullable Types Demo ---");

            // 1. Defining Nullable Types
            int? age = null; // The box is empty
            int? height = 180; // The box has 180

            Console.WriteLine($"Age is: {(age.HasValue ? age.ToString() : "Unknown")}"); // Output: Age is: Unknown
            Console.WriteLine($"Height is: {height}");                                   // Output: Height is: 180

            // 2. The Null Coalescing Operator (??)
            // Story: "If the box is empty, use this backup coin."
            // If age is null, use 0.
            int safeAge = age ?? 0; 
            Console.WriteLine($"Safe Age: {safeAge}"); // Output: Safe Age: 0

            // 3. The Null Conditional Operator (?.)
            // Story: "Only ring the doorbell IF the house exists."
            string? message = null;
            // int length = message.Length; // CRASH! NullReferenceException
            int? length = message?.Length; // Returns null if message is null. No crash.
            
            Console.WriteLine($"Message Length: {length}"); // Output: Message Length: 

            // 4. Danger Zone
            try
            {
                // Trying to force open an empty box
                if (age.HasValue)
                {
                    int realAge = (int)age; 
                }
                else
                {
                    throw new InvalidOperationException("Box is empty");
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error: You tried to take a value from an empty box!"); // Output: Error: You tried to take a value from an empty box!
            }
        }
    }
}
