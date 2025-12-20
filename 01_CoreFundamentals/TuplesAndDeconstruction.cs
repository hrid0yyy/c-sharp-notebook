using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: Tuples, Deconstruction, and Discards
    // ==========================================
    //
    // STORY LINE:
    // THE COMBO MEAL & THE SPY EXCHANGE:
    //
    // 1. TUPLES (The Combo Meal):
    //    Sometimes you want to return two things from a method, like a Burger AND Fries.
    //    In the old days, you had to create a class `BurgerAndFriesContainer` or use `out` parameters (clunky).
    //    With Tuples, you just hand over a bag containing both: `(Burger, Fries)`.
    //    It's a lightweight, temporary grouping of values.
    //
    // 2. DECONSTRUCTION (The Unpacking):
    //    You get the bag. You don't want to keep holding the bag.
    //    You want to take the Burger out to your left hand, and the Fries to your right hand.
    //    `var (myBurger, myFries) = GetCombo();`
    //
    // 3. DISCARDS (The "I don't want that"):
    //    The combo comes with a toy. You are an adult. You don't want the toy.
    //    You throw it directly in the trash without even looking at it.
    //    `var (burger, fries, _) = GetHappyMeal();` -> The `_` is the trash can.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Tuples: Lightweight data structures to group multiple data elements.
    // - Deconstruction: Unpacking a tuple (or object) into separate variables.
    // - Discards (_): A write-only variable used when you don't care about the value.
    //
    // ==========================================

    class TuplesAndDeconstruction
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AdvancedConcepts.TuplesAndDeconstruction
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Tuples & Deconstruction Demo ---");

            // 1. Basic Tuple
            Console.WriteLine("\n1. Basic Tuple:");
            var values = GetMinMax(new int[] { 1, 5, 3, 9, 2 });
            Console.WriteLine($"Min: {values.Min}, Max: {values.Max}"); // Output: Min: 1, Max: 9

            // 2. Deconstruction (Unpacking)
            Console.WriteLine("\n2. Deconstruction:");
            // We unpack the tuple directly into two variables: 'min' and 'max'
            var (min, max) = GetMinMax(new int[] { 10, 50, 30 });
            Console.WriteLine($"Unpacked -> Min: {min}, Max: {max}"); // Output: Unpacked -> Min: 10, Max: 50

            // 3. Discards (Ignoring values)
            Console.WriteLine("\n3. Discards:");
            // We only care about the Max value. We discard the Min using '_'.
            var (_, onlyMax) = GetMinMax(new int[] { 100, 500, 300 });
            Console.WriteLine($"I only care about Max: {onlyMax}"); // Output: I only care about Max: 500

            // 4. Deconstructing Objects
            Console.WriteLine("\n4. Deconstructing Objects:");
            var p = new PersonDeconstruct("John", "Doe", 30);
            // The PersonDeconstruct class has a Deconstruct method, so we can treat it like a tuple!
            var (first, last, age) = p; 
            Console.WriteLine($"{first} {last} is {age} years old."); // Output: John Doe is 30 years old.

            // 5. Using 'out' parameters (The Old Way vs New Way)
            Console.WriteLine("\n5. Out Parameters:");
            if (int.TryParse("123", out int result)) // Inline out declaration
            {
                Console.WriteLine($"Parsed number: {result}"); // Output: Parsed number: 123
            }
            
            // Using discard with out
            if (int.TryParse("999", out _)) 
            {
                Console.WriteLine("It is a valid number, but I don't care what it is."); // Output: It is a valid number, but I don't care what it is.
            }
        }

        // Method returning a Tuple (int Min, int Max)
        static (int Min, int Max) GetMinMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return (0, 0);
            
            int min = numbers[0];
            int max = numbers[0];

            foreach (var n in numbers)
            {
                if (n < min) min = n;
                if (n > max) max = n;
            }

            return (min, max);
        }
    }

    // Class with Deconstruct support
    class PersonDeconstruct
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public PersonDeconstruct(string first, string last, int age)
        {
            FirstName = first;
            LastName = last;
            Age = age;
        }

        // The magic method that allows: var (f, l, a) = person;
        public void Deconstruct(out string first, out string last, out int age)
        {
            first = FirstName;
            last = LastName;
            age = Age;
        }
    }
}
