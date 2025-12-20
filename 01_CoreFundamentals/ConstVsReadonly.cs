using System;

namespace Concepts
{
    // ==========================================
    // Topic: Constant vs Readonly
    // ==========================================
    //
    // STORY LINE:
    // CONST (The Stone Tablet):
    // Imagine a stone tablet carved at the factory. It says "PI = 3.14".
    // You cannot change it. Ever.
    // It is set when the tablet is MADE (Compile Time).
    // If you want to change it, you have to smash the tablet and make a new one (Recompile).
    //
    // READONLY (The Sealed Envelope):
    // Imagine a sealed envelope. You can write whatever you want on a paper, put it inside, and seal it.
    // Once sealed, you cannot change it.
    // But you can decide what to write JUST BEFORE you seal it (Runtime / Constructor).
    // Each envelope can have a different message.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - const: A value that is known at compile time and cannot change. It is implicitly static.
    // - readonly: A value that can be assigned either at declaration or in a constructor. It can be different for different objects.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - const: For absolute truths (Math.PI, DaysInWeek).
    // - readonly: For values that shouldn't change after creation but depend on input (BirthDate, AccountNumber).
    //
    // ==========================================

    class ConstantsDemo
    {
        // Const: Must be assigned immediately. Known at compile time.
        public const double Pi = 3.14159;

        // Readonly: Can be assigned in constructor.
        public readonly int InstanceId;

        // Static Readonly: Can be assigned in static constructor.
        public static readonly DateTime StartupTime;

        static ConstantsDemo()
        {
            StartupTime = DateTime.Now;
        }

        public ConstantsDemo(int id)
        {
            // We can assign readonly here!
            InstanceId = id;
        }

        // public void TryChange()
        // {
        //     InstanceId = 10; // Error! Cannot assign to readonly field outside constructor.
        // }
    }

    class ConstVsReadonly
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.ConstVsReadonly
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Const vs Readonly Demo ---");

            Console.WriteLine($"Constant Pi: {ConstantsDemo.Pi}"); // Output: Constant Pi: 3.14159
            Console.WriteLine($"Static Readonly StartupTime: {ConstantsDemo.StartupTime}"); // Output: Static Readonly StartupTime: [Current Date Time]

            ConstantsDemo obj1 = new ConstantsDemo(100);
            Console.WriteLine($"Object 1 InstanceId (Readonly): {obj1.InstanceId}"); // Output: Object 1 InstanceId (Readonly): 100

            ConstantsDemo obj2 = new ConstantsDemo(200);
            Console.WriteLine($"Object 2 InstanceId (Readonly): {obj2.InstanceId}"); // Output: Object 2 InstanceId (Readonly): 200

            Console.WriteLine("\nNotice: 'InstanceId' is immutable for that object, but different objects have different values.");
        }
    }
}
