using System;

namespace Concepts.AdvancedConcepts
{
    // ==========================================
    // Topic: Exception Handling (Try, Catch, Finally, Throw)
    // ==========================================
    //
    // STORY LINE:
    // THE TRAPEZE ARTIST:
    // You are a trapeze artist performing a dangerous stunt (The Code).
    //
    // TRY (The Stunt):
    // You attempt the jump. "I will fly through the air!"
    //
    // CATCH (The Safety Net):
    // If you slip and fall (Exception), you don't hit the ground and die (App Crash).
    // You land in the net. The net catches you.
    // You can then climb out and say "I slipped, but I'm okay." (Handling the error).
    //
    // FINALLY (The Bow):
    // Whether you landed the jump perfectly OR fell into the net, you ALWAYS take a bow and exit the stage.
    // This is where you clean up (turn off lights, close doors).
    //
    // THROW (The Emergency Stop):
    // Sometimes, you see the rope is broken BEFORE you jump.
    // You shout "STOP!" and refuse to jump. You manually trigger the safety protocol.
    //
    // ==========================================

    class ExceptionHandling
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AdvancedConcepts.ExceptionHandling
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Exception Handling Demo ---");

            // Scenario 1: The Safe Landing
            Console.WriteLine("\n1. Attempting a dangerous calculation...");
            SafeDivision(10, 2);

            // Scenario 2: The Fall
            Console.WriteLine("\n2. Attempting the impossible...");
            SafeDivision(10, 0);

            // Scenario 3: The Custom Error
            Console.WriteLine("\n3. The Broken Rope...");
            try
            {
                PerformStunt("Broken Rope");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [CATCH] Stunt cancelled: {ex.Message}");
            }
        }

        static void SafeDivision(int a, int b)
        {
            try
            {
                // The Stunt
                Console.WriteLine($"  [TRY] Dividing {a} by {b}...");
                int result = a / b;
                Console.WriteLine($"  [TRY] Success! Result is {result}");
            }
            catch (DivideByZeroException ex)
            {
                // The Safety Net
                Console.WriteLine($"  [CATCH] Caught a fall! You cannot divide by zero.");
                Console.WriteLine($"  Error Details: {ex.Message}");
            }
            finally
            {
                // The Bow
                Console.WriteLine("  [FINALLY] Cleaning up calculation resources.");
            }
        }

        static void PerformStunt(string equipmentStatus)
        {
            if (equipmentStatus == "Broken Rope")
            {
                // Manually throwing an exception
                throw new InvalidOperationException("Equipment is unsafe!");
            }
            Console.WriteLine("Stunt performed successfully!");
        }
    }
}
