using System;
using System.Collections.Generic;
using System.Linq;

namespace Concepts
{
    // ==========================================
    // Topic: Lambda Expressions in C#
    // ==========================================
    //
    // STORY LINE:
    // Imagine you are a busy Chef (The Compiler/Runtime).
    // Usually, when you want to cook a specific dish, you look up a full recipe in a big cookbook (Named Method).
    // The recipe has a name, a list of ingredients, and step-by-step instructions.
    //
    // However, sometimes you just need a quick instruction for a helper, like "Chop this onion" or "Square this number".
    // You don't want to write a full page in the cookbook for that.
    // Instead, you write a quick sticky note: "Onion => Chop(Onion)".
    // This sticky note is a Lambda Expression. It's an anonymous function—a method without a name—defined right where you need it.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // A Lambda expression is a concise way to represent an anonymous method.
    // It uses the lambda operator "=>", which is read as "goes to".
    // Syntax: (input_parameters) => expression_or_statement_block
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // 1. Conciseness: Reduces boilerplate code. No need to define a full method for simple logic.
    // 2. Readability: Keeps the logic close to where it is used (e.g., inside a LINQ query).
    // 3. Functional Programming: Enables passing behavior (code) as arguments to methods.
    //
    // ------------------------------------------
    // REAL LIFE SCENARIO:
    // - Filtering a list of products: products.Where(p => p.Price > 100);
    // - Sorting a list of users: users.OrderBy(u => u.Name);
    // - Event handling: button.Click += (sender, e) => { Console.WriteLine("Clicked!"); };
    //
    // ==========================================

    class LambdaExpressions
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.LambdaExpressions
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Lambda Expressions Demo ---"); // Output: --- Lambda Expressions Demo ---

            // 1. Basic Example: Squaring a number
            // Old way (using a delegate and a named method - not shown here for brevity)
            
            // New way (Lambda):
            // Input 'x' goes to 'x * x'
            Func<int, int> square = x => x * x;
            Console.WriteLine($"Square of 5 is: {square(5)}"); // Output: Square of 5 is: 25

            // 2. Using Lambda with Lists (LINQ)
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Story: "Hey helper, filter this list. Keep only the numbers that are even."
            // Lambda: n => n % 2 == 0
            List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

            Console.WriteLine("Even Numbers:"); // Output: Even Numbers:
            evenNumbers.ForEach(n => Console.Write(n + " ")); // Another lambda! // Output: 2 4 6 8 10 
            Console.WriteLine();

            // 3. Lambda with multiple parameters
            // Story: "Add these two numbers."
            // (a, b) => a + b
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine($"Sum of 10 and 20 is: {add(10, 20)}"); // Output: Sum of 10 and 20 is: 30

            // 4. Lambda with a statement block (curly braces)
            // Used when you need multiple lines of code.
            Action<string> greet = name => 
            {
                string greeting = $"Hello, {name}!";
                Console.WriteLine(greeting); // Output: Hello, Developer!
            };

            greet("Developer");
        }
    }
}
