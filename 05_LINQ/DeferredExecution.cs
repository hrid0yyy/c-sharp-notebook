using System;
using System.Collections.Generic;
using System.Linq;

namespace Concepts.LINQ
{
    // ==========================================
    // Topic: Deferred vs Immediate Execution
    // ==========================================
    //
    // STORY LINE:
    // THE PIZZA ORDER:
    //
    // 1. DEFERRED EXECUTION (The Order Slip):
    //    You write down an order: "I want all pizzas with pepperoni."
    //    Nothing happens yet. No pizzas are baked. It's just a query definition.
    //    If you change the menu before handing it to the chef, the result changes.
    //    Keywords: Select, Where, Take, Skip.
    //
    // 2. IMMEDIATE EXECUTION (The Delivery):
    //    You say: "Give me the list NOW." (.ToList(), .Count(), .ToArray())
    //    The chef bakes everything immediately and hands you the box.
    //    If the menu changes afterwards, your box doesn't change.
    //
    // ==========================================

    class DeferredExecution
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.LINQ.DeferredExecution
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Deferred vs Immediate Execution ---");

            List<int> numbers = new List<int> { 1, 2, 3 };

            // 1. Deferred Execution
            Console.WriteLine("\n1. Deferred Execution:");
            // We define the query. NO LOOP runs here.
            var query = numbers.Where(n => 
            {
                Console.WriteLine($"  Checking {n}..."); // Proof of when it runs
                return n > 1;
            });

            Console.WriteLine("  (Query defined. Nothing happened yet.)");
            
            numbers.Add(4); // We modify the source AFTER defining the query
            Console.WriteLine("  (Added 4 to list.)");

            Console.WriteLine("  Running foreach loop now:");
            // The query executes NOW, iterating over the CURRENT state of the list (1, 2, 3, 4)
            foreach (var n in query)
            {
                Console.WriteLine($"  Result: {n}");
            }

            // 2. Immediate Execution
            Console.WriteLine("\n2. Immediate Execution:");
            List<int> numbers2 = new List<int> { 1, 2, 3 };
            
            // .ToList() forces execution immediately.
            var resultList = numbers2.Where(n => n > 1).ToList();
            Console.WriteLine("  (List created immediately.)");

            numbers2.Add(4); // Modify source
            Console.WriteLine("  (Added 4 to source list.)");

            Console.WriteLine("  Printing result list:");
            // The resultList does NOT contain 4, because it was baked before we added it.
            foreach (var n in resultList)
            {
                Console.WriteLine($"  Result: {n}");
            }
        }
    }
}
