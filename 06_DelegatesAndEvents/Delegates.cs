using System;

namespace Concepts.DelegatesAndEvents
{
    // ==========================================
    // Topic: Delegates (Multicast & Callbacks)
    // ==========================================
    //
    // STORY LINE:
    // THE REMOTE CONTROL:
    //
    // 1. BASIC DELEGATE (The Button):
    //    You have a button on a remote. You can program it to turn on the TV.
    //    The button doesn't know HOW to turn on the TV, it just sends a signal to the TV's receiver (Method).
    //
    // 2. MULTICAST DELEGATE (The Master Switch):
    //    You program one button to turn on the TV, AND dim the lights, AND close the blinds.
    //    One click triggers multiple actions in a sequence.
    //
    // 3. DELEGATE AS PARAMETER (The Contractor):
    //    You hire a contractor to build a house.
    //    You tell him: "When you are done with the roof, call THIS number (Delegate)."
    //    He doesn't know who he is calling, he just follows the instruction to call back.
    //
    // ==========================================

    // 1. Define a Delegate
    // Signature: Takes a string, returns void.
    public delegate void LogHandler(string message);

    class Delegates
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.DelegatesAndEvents.Delegates
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Delegates Demo ---"); // Output: --- Delegates Demo ---

            // --- Part 1: Basic Delegate ---
            Console.WriteLine("\n1. Basic Delegate:"); // Output: \n1. Basic Delegate:
            LogHandler logger = LogToConsole;
            logger("System started."); // Output: [Console]: System started.

            // --- Part 2: Multicast Delegate ---
            Console.WriteLine("\n2. Multicast Delegate (Chaining):"); // Output: \n2. Multicast Delegate (Chaining):
            
            LogHandler multiLogger = LogToConsole;
            multiLogger += LogToFile; // Add another method to the chain
            
            multiLogger("System crashed!"); 
            // Output: 
            // [Console]: System crashed!
            // [File]: System crashed!

            Console.WriteLine("\nRemoving File Logger..."); // Output: \nRemoving File Logger...
            multiLogger -= LogToFile; // Remove method
            multiLogger("System recovered."); // Output: [Console]: System recovered.

            // --- Part 3: Delegate as Parameter (Callback) ---
            Console.WriteLine("\n3. Delegate as Parameter (Callback):"); // Output: \n3. Delegate as Parameter (Callback):
            
            ProcessWork(LogToConsole); // Pass the method as an argument
        }

        // Method 1 matches LogHandler signature
        static void LogToConsole(string msg)
        {
            Console.WriteLine($"[Console]: {msg}"); // Output: [Console]: [msg]
        }

        // Method 2 matches LogHandler signature
        static void LogToFile(string msg)
        {
            Console.WriteLine($"[File]: {msg}"); // Output: [File]: [msg]
        }

        // Method that takes a delegate as a parameter
        static void ProcessWork(LogHandler callback)
        {
            Console.WriteLine("Processing heavy work..."); // Output: Processing heavy work...
            System.Threading.Thread.Sleep(500);
            
            // Invoke the callback to notify completion
            callback("Work completed successfully!"); 
        }
    }
}
