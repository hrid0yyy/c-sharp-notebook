using System;

namespace Concepts
{
    // ==========================================
    // Topic: Ref vs Out
    // ==========================================
    //
    // STORY LINE:
    // Imagine you are sending a friend to get pizza.
    //
    // REF (The Half-Eaten Pizza):
    // You have a pizza box with 2 slices left. You give it to your friend (Pass by Reference).
    // Your friend can eat a slice, or add a new pizza to the box.
    // When they come back, you see the changes.
    // CRITICAL: You MUST give them a box that exists (Initialized) before they leave. You can't give them "nothing".
    //
    // OUT (The Empty Box):
    // You give your friend an EMPTY box.
    // You tell them: "Go to the store and fill this."
    // It doesn't matter if the box had trash in it before; they are expected to replace it.
    // CRITICAL: Your friend MUST put a pizza in the box before they return. They cannot come back with an empty box.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - ref: Passes a variable by reference. The variable MUST be initialized before passing. The method CAN modify it.
    // - out: Passes a variable by reference. The variable DOES NOT need to be initialized. The method MUST assign a value to it.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - To allow a method to modify the caller's variable.
    // - To return multiple values from a method (especially 'out').
    //
    // ==========================================

    class RefVsOut
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.RefVsOut
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Ref vs Out Demo ---");

            // 1. REF Example
            int myPizzaSlices = 2;
            Console.WriteLine($"Before Ref: I have {myPizzaSlices} slices.");
            
            // Must be initialized!
            EatPizza(ref myPizzaSlices);
            
            Console.WriteLine($"After Ref: I have {myPizzaSlices} slices.");

            // 2. OUT Example
            int newPizza; // Not initialized!
            // Console.WriteLine(newPizza); // Error if used here.

            Console.WriteLine("\nSending friend with an empty box (Out)...");
            GetNewPizza(out newPizza);

            Console.WriteLine($"After Out: I have {newPizza} slices.");
        }

        // REF: Can read and write. Must be initialized by caller.
        static void EatPizza(ref int slices)
        {
            Console.WriteLine("  (Friend is eating one slice...)");
            slices = slices - 1;
        }

        // OUT: Must write. Initial value is ignored.
        static void GetNewPizza(out int slices)
        {
            Console.WriteLine("  (Friend bought a new pizza!)");
            slices = 8; // MUST assign a value.
        }
    }
}
