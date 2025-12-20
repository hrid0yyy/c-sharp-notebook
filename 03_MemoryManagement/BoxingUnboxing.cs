using System;

namespace Concepts
{
    // ==========================================
    // Topic: Boxing and Unboxing
    // ==========================================
    //
    // STORY LINE:
    // Imagine you have a small toy car (Value Type, int). It lives on your desk (Stack). It's fast to grab.
    // Now, you want to ship it to a friend. You can't just throw the car in the mail.
    // You have to put it inside a cardboard box (Object, Reference Type).
    //
    // BOXING:
    // The act of taking the toy (int) and putting it into the box (object).
    // This takes time (wrapping) and space (the box itself). The box goes to the warehouse (Heap).
    //
    // UNBOXING:
    // Your friend gets the box. They have to open it to get the toy car out.
    // If they think it's a toaster inside and try to use it as one, it explodes (InvalidCastException).
    // They must know it's a car.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Boxing: Converting a Value Type (int, double, bool, struct) to a Reference Type (object).
    // - Unboxing: Converting a Reference Type (object) back to a Value Type.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Sometimes you need to store different types in a single collection (like ArrayList in old C#).
    // - Passing values to methods that accept 'object'.
    //
    // ------------------------------------------
    // PERFORMANCE:
    // Boxing and Unboxing are expensive operations (memory allocation, type checking).
    // Generics (List<int>) avoid this!
    //
    // ==========================================

    class BoxingUnboxing
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.BoxingUnboxing
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Boxing and Unboxing Demo ---"); // Output: --- Boxing and Unboxing Demo ---

            // 1. Value Type
            int num = 123; // Lives on Stack
            Console.WriteLine($"Value Type: {num}"); // Output: Value Type: 123

            // 2. Boxing
            // Implicit conversion to object
            object boxedNum = num; // Lives on Heap
            Console.WriteLine($"Boxed (Object): {boxedNum}"); // Output: Boxed (Object): 123

            // 3. Unboxing
            // Explicit conversion back to int
            int unboxedNum = (int)boxedNum;
            Console.WriteLine($"Unboxed: {unboxedNum}"); // Output: Unboxed: 123

            // 4. The Danger (Invalid Unboxing)
            try
            {
                // Trying to unbox into the wrong type
                // The box contains an int, but we try to take out a double.
                double d = (double)boxedNum; 
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"\nError Unboxing: {e.Message}"); // Output: \nError Unboxing: Specified cast is not valid.
                Console.WriteLine("Story: You tried to take a Toaster out of a box that contained a Car!"); // Output: Story: You tried to take a Toaster out of a box that contained a Car!
            }
        }
    }
}
