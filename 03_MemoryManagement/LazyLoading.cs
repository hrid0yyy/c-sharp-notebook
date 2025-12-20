using System;
using System.Threading;

namespace Concepts
{
    // ==========================================
    // Topic: Lazy Loading
    // ==========================================
    //
    // STORY LINE:
    // Imagine you are going on a hiking trip.
    // You have a very heavy tent (Expensive Object).
    // You don't want to carry it on your back (Memory/Performance) from the moment you leave your house if you might not even camp.
    // Instead, you have a magic capsule. The tent is only "created" and expanded when you actually decide to set up camp.
    // If you just walk and go home, you never carried the heavy tent.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // Lazy loading is a design pattern where the initialization of an object is deferred until it is actually needed.
    // In C#, the `Lazy<T>` class helps implement this easily.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // 1. Performance: Improves application startup time by avoiding loading unnecessary resources.
    // 2. Memory Efficiency: Saves memory by not creating objects that might never be used.
    //
    // ------------------------------------------
    // REAL LIFE SCENARIO:
    // - Loading a User Profile: You load the basic info (Name, Email). You don't load the "Order History" (which could be huge) until the user clicks the "Orders" tab.
    // - Database Connections: Don't open a connection until a query is actually executed.
    //
    // ==========================================

    class ExpensiveResource
    {
        public ExpensiveResource()
        {
            Console.WriteLine("ExpensiveResource: Initializing... (This takes time and memory)");
            Thread.Sleep(1000); // Simulate heavy work
            Console.WriteLine("ExpensiveResource: Created!");
        }

        public void DoWork()
        {
            Console.WriteLine("ExpensiveResource: Working...");
        }
    }

    class LazyLoading
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.LazyLoading
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Lazy Loading Demo ---");

            // 1. Define the lazy object. 
            // We pass a lambda expression that defines HOW to create it, but it's NOT created yet.
            Lazy<ExpensiveResource> lazyResource = new Lazy<ExpensiveResource>(() => new ExpensiveResource());

            Console.WriteLine("Application Started. The heavy object is NOT created yet.");
            Console.WriteLine($"Is value created? {lazyResource.IsValueCreated}"); // False

            Console.WriteLine("Press Enter to access the resource...");
            // Console.ReadLine(); // Uncomment to pause

            // 2. The resource is accessed here for the first time.
            // This triggers the constructor of ExpensiveResource.
            Console.WriteLine("Accessing resource for the first time...");
            ExpensiveResource instance = lazyResource.Value; 
            instance.DoWork();

            Console.WriteLine($"Is value created? {lazyResource.IsValueCreated}"); // True
            
            // 3. Accessing it again uses the cached instance (Constructor not called again).
            Console.WriteLine("Accessing resource for the second time...");
            ExpensiveResource instance2 = lazyResource.Value;
            instance2.DoWork();
        }
    }
}
