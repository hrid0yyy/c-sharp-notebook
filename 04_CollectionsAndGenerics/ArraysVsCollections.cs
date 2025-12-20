using System;
using System.Collections.Generic;

namespace Concepts
{
    // ==========================================
    // Topic: Arrays vs Collections (List, Dictionary)
    // ==========================================
    //
    // STORY LINE:
    // ARRAY (The Egg Carton):
    // You buy an egg carton. It has exactly 12 slots.
    // You can put eggs in slot 1, slot 2, etc.
    // If you buy a 13th egg, you CANNOT put it in the carton. It's full.
    // You have to buy a bigger carton and move all eggs manually.
    // It is fast and simple, but rigid.
    //
    // LIST (The Magic Shopping Bag):
    // You have a bag. You put an item in. The bag stretches.
    // You put 100 items in. It stretches more.
    // You take an item out. It shrinks.
    // It is flexible and easy to use.
    //
    // DICTIONARY (The Coat Check):
    // You give your coat to the attendant. They give you a ticket #55 (Key).
    // When you want your coat (Value) back, you don't look through every coat on the rack.
    // You just give ticket #55, and they go directly to slot 55.
    // It is extremely fast for lookups.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Array: Fixed-size collection of same-type elements.
    // - List<T>: Dynamic-size collection.
    // - Dictionary<TKey, TValue>: Key-Value pair collection for fast lookups.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Arrays: Low-level, high performance, fixed buffer.
    // - Collections: Ease of use, dynamic resizing, advanced methods (Add, Remove, Find).
    //
    // ==========================================

    class ArraysVsCollections
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.ArraysVsCollections
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Arrays vs Collections Demo ---"); // Output: --- Arrays vs Collections Demo ---

            // 1. Array
            Console.WriteLine("\n1. Array (The Egg Carton)"); // Output: \n1. Array (The Egg Carton)
            string[] carton = new string[3]; // Fixed size of 3
            carton[0] = "Egg 1";
            carton[1] = "Egg 2";
            carton[2] = "Egg 3";
            // carton[3] = "Egg 4"; // Crash! IndexOutOfRangeException
            Console.WriteLine($"Carton has {carton.Length} slots."); // Output: Carton has 3 slots.

            // 2. List<T>
            Console.WriteLine("\n2. List (The Magic Bag)"); // Output: \n2. List (The Magic Bag)
            List<string> bag = new List<string>();
            bag.Add("Apple");
            bag.Add("Banana");
            bag.Add("Orange");
            bag.Add("Grapes"); // No problem, it grows!
            Console.WriteLine($"Bag has {bag.Count} items."); // Output: Bag has 4 items.
            
            bag.Remove("Banana"); // Easy to remove
            Console.WriteLine($"Removed Banana. Bag has {bag.Count} items."); // Output: Removed Banana. Bag has 3 items.

            // 3. Dictionary<TKey, TValue>
            Console.WriteLine("\n3. Dictionary (The Coat Check)"); // Output: \n3. Dictionary (The Coat Check)
            Dictionary<int, string> coatCheck = new Dictionary<int, string>();
            coatCheck.Add(101, "Red Jacket");
            coatCheck.Add(102, "Blue Coat");
            
            // Fast lookup by Key
            if (coatCheck.ContainsKey(101))
            {
                Console.WriteLine($"Ticket 101 belongs to: {coatCheck[101]}"); // Output: Ticket 101 belongs to: Red Jacket
            }
        }
    }
}
