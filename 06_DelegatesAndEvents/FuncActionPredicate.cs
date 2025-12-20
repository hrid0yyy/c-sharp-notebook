using System;

namespace Concepts.DelegatesAndEvents
{
    // ==========================================
    // Topic: Func, Action, Predicate
    // ==========================================
    //
    // STORY LINE:
    // THE PRE-MADE FORMS:
    // Before .NET 3.5, if you wanted a delegate, you had to define it:
    // `delegate int MathOp(int x, int y);`
    //
    // Microsoft realized everyone was doing this, so they created standard forms:
    //
    // 1. ACTION (The Doer):
    //    "Go do this."
    //    Returns void. Can take arguments.
    //    Action<string> = void MyMethod(string s)
    //
    // 2. FUNC (The Calculator):
    //    "Calculate this and give me the result."
    //    Returns a value. Last type parameter is the Return Type.
    //    Func<int, int, string> = string MyMethod(int x, int y)
    //
    // 3. PREDICATE (The Judge):
    //    "Is this true or false?"
    //    Returns bool. Takes one argument.
    //    Predicate<int> = bool MyMethod(int x)
    //    (Mostly replaced by Func<T, bool> nowadays).
    //
    // ==========================================

    class FuncActionPredicate
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.DelegatesAndEvents.FuncActionPredicate
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Func, Action, Predicate Demo ---");

            // 1. Action (Void)
            // Lambda: takes 'msg', prints it.
            Action<string> greeter = (msg) => Console.WriteLine($"Action says: {msg}");
            greeter("Hello World!");

            // 2. Func (Returns Value)
            // Lambda: takes x and y, returns sum.
            // Func<int, int, int> -> Input, Input, Output
            Func<int, int, int> adder = (x, y) => x + y;
            int result = adder(5, 10);
            Console.WriteLine($"Func result: {result}");

            // 3. Predicate (Returns Bool)
            // Lambda: takes x, returns true if even.
            Predicate<int> isEven = (x) => x % 2 == 0;
            Console.WriteLine($"Predicate (Is 4 even?): {isEven(4)}");
            Console.WriteLine($"Predicate (Is 5 even?): {isEven(5)}");

            // Real world usage: List.Find uses Predicate
            var numbers = new System.Collections.Generic.List<int> { 1, 3, 5, 8, 9 };
            int firstEven = numbers.Find(isEven);
            Console.WriteLine($"First even number in list: {firstEven}");
        }
    }
}
