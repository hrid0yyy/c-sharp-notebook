using System;
using System.Collections.Generic;
using System.Linq;

namespace Concepts
{
    // ==========================================
    // Topic: LINQ (Language Integrated Query)
    // ==========================================
    //
    // STORY LINE:
    // THE TRANSLATOR:
    // You speak C# (Objects, Lists). The Database speaks SQL (Tables, Rows).
    // Before LINQ, you had to write SQL strings inside C# (messy and error-prone).
    // LINQ is a universal translator. You ask for data in C# syntax ("Where Price > 10"), and LINQ translates it to whatever the data source understands (SQL, XML, Objects).
    //
    // DEFERRED EXECUTION (The Lazy Waiter):
    // You are at a restaurant. You look at the menu and decide:
    // 1. "I want a burger." (Query Defined)
    // 2. "No onions." (Filter Added)
    // 3. "Add cheese." (Filter Added)
    // The waiter DOES NOT go to the kitchen yet. He just writes it down.
    // He only runs to the kitchen when you say "Bring it now!" (ToList(), Count(), foreach).
    // This saves trips to the kitchen.
    //
    // IENUMERABLE vs IQUERYABLE:
    // - IEnumerable (In-Memory): You bring ALL the ingredients to your table, then pick out the onions yourself. (Good for lists).
    // - IQueryable (Remote): You tell the chef "No onions", and he sends you the burger without onions. (Good for Databases - filters happen on the server).
    //
    // ==========================================

    class Linq
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.Linq
        public static void Main(string[] args)
        {
            Console.WriteLine("--- LINQ Demo ---"); // Output: --- LINQ Demo ---

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 1. Define Query (Deferred Execution)
            // The query is NOT executed here.
            var query = numbers.Where(n => 
            {
                Console.WriteLine($"Checking number: {n}"); // Output: Checking number: 1
                return n % 2 == 0;
            });

            Console.WriteLine("Query defined. Nothing happened yet."); // Output: Query defined. Nothing happened yet.

            // 2. Execute Query
            Console.WriteLine("Executing query now (foreach)..."); // Output: Executing query now (foreach)...
            foreach (var n in query)
            {
                Console.WriteLine($"Found even: {n}"); // Output: Found even: 2
            }

            // 3. Method Syntax vs Query Syntax
            Console.WriteLine("\nQuery Syntax:"); // Output: \nQuery Syntax:
            var querySyntax = from n in numbers
                              where n > 5
                              select n;
            
            foreach(var n in querySyntax) Console.Write(n + " "); // Output: 6 7 8 9 10 
            Console.WriteLine();
        }
    }
}
