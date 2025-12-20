using System;

namespace Concepts
{
    // ==========================================
    // Topic: Static Constructors
    // ==========================================
    //
    // STORY LINE:
    // Imagine a "Blueprint Office" for a skyscraper.
    // Before ANY construction worker (Instance Constructor) can start building the first floor of ANY building,
    // the Chief Architect must set up the office, buy the coffee machine, and hang the safety rules on the wall.
    // This setup happens ONLY ONCE, the very first time the company gets a contract.
    // Even if you build 100 skyscrapers, the Chief Architect doesn't set up the office again.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // A static constructor is a special method used to initialize the class itself (static members), not a specific object.
    // It is called automatically before the first instance is created or any static members are referenced.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - To initialize static data (e.g., configuration settings, logging setup) that is shared across all instances.
    // - To perform a one-time setup for the class.
    //
    // ------------------------------------------
    // REAL LIFE SCENARIO:
    // - Loading configuration from a file when the application starts.
    // - Setting up a connection string that is used by all database helpers.
    //
    // ==========================================

    class Configuration
    {
        public static string AppName;
        public static DateTime StartTime;

        // Static Constructor
        // No access modifiers (public/private), no parameters.
        static Configuration()
        {
            Console.WriteLine("Static Constructor: Setting up the Blueprint Office..."); // Output: Static Constructor: Setting up the Blueprint Office...
            AppName = "My Awesome App";
            StartTime = DateTime.Now;
        }

        // Instance Constructor
        public Configuration()
        {
            Console.WriteLine("Instance Constructor: Building a new object..."); // Output: Instance Constructor: Building a new object...
        }
    }

    class StaticConstructors
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.StaticConstructors
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Static Constructors Demo ---"); // Output: --- Static Constructors Demo ---

            Console.WriteLine("1. Accessing a static property..."); // Output: 1. Accessing a static property...
            // This triggers the Static Constructor immediately.
            Console.WriteLine($"App Name: {Configuration.AppName}"); // Output: App Name: My Awesome App

            Console.WriteLine("\n2. Creating the first instance..."); // Output: \n2. Creating the first instance...
            // Static constructor is NOT called again. Only Instance constructor runs.
            Configuration c1 = new Configuration();

            Console.WriteLine("\n3. Creating the second instance..."); // Output: \n3. Creating the second instance...
            // Only Instance constructor runs.
            Configuration c2 = new Configuration();
        }
    }
}
