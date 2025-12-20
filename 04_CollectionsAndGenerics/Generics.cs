using System;
using System.Collections.Generic;

namespace Concepts.CollectionsAndGenerics
{
    // ==========================================
    // Topic: Generics (Classes, Methods, Interfaces, Delegates)
    // ==========================================
    //
    // STORY LINE:
    // THE UNIVERSAL FACTORY:
    // Imagine a factory that makes containers.
    //
    // 1. GENERIC CLASS (The Universal Box):
    //    Instead of a "ShoeBox" and a "HatBox", you make a "Box<T>".
    //    When the customer orders, they say "I want a Box<Shoe>".
    //    The factory instantly configures the machine to make a box perfectly sized for a Shoe.
    //
    // 2. GENERIC METHOD (The Magic Wrapper):
    //    You have a machine that wraps items.
    //    Instead of "WrapShoe(Shoe s)" and "WrapHat(Hat h)", you have "Wrap<T>(T item)".
    //    Whatever you throw in, it wraps it.
    //
    // 3. GENERIC INTERFACE (The Contract):
    //    You have a rule: "All storage units must be able to Store and Retrieve items."
    //    Interface IStorage<T> { void Store(T item); T Retrieve(); }
    //    A Warehouse implements IStorage<Pallet>. A Pocket implements IStorage<Coin>.
    //
    // 4. GENERIC DELEGATE (The Flexible Messenger):
    //    You need a messenger to carry an item from A to B.
    //    Delegate: Action<T>(T item).
    //    You can hire a messenger to carry a Letter (Action<Letter>) or a Piano (Action<Piano>).
    //
    // ==========================================

    // 1. GENERIC INTERFACE
    // Defines a contract that works with any type T.
    public interface IRepository<T>
    {
        void Add(T item);
        T? Get(int id);
    }

    // 2. GENERIC CLASS
    // Implements the generic interface.
    public class Repository<T> : IRepository<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine($"[Repository<{typeof(T).Name}>] Added item: {item}"); // Output: [Repository<String>] Added item: Hello World
        }

        public T? Get(int id)
        {
            // Simulating fetching by ID (just returning the first one for demo)
            if (_items.Count > 0) return _items[0];
            return default(T); // Returns null for reference types, 0 for int, etc.
        }
    }

    class GenericsDemo
    {
        // 3. GENERIC DELEGATE
        // A delegate that takes an input of type T and returns void.
        // (This is actually what the built-in Action<T> does!)
        public delegate void Printer<T>(T data);

        // 4. GENERIC METHOD
        // A method that can swap any two items of the same type.
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // To run this file: dotnet run --property:StartupObject=Concepts.Generics.GenericsDemo
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Comprehensive Generics Demo ---"); // Output: --- Comprehensive Generics Demo ---

            // --- Demo: Generic Class & Interface ---
            Console.WriteLine("\n1. Generic Class & Interface:"); // Output: \n1. Generic Class & Interface:
            
            // Create a repository for Strings
            IRepository<string> stringRepo = new Repository<string>();
            stringRepo.Add("Hello World");

            // Create a repository for Integers
            IRepository<int> intRepo = new Repository<int>();
            intRepo.Add(42);

            // --- Demo: Generic Method ---
            Console.WriteLine("\n2. Generic Method:"); // Output: \n2. Generic Method:
            int a = 10, b = 20;
            Console.WriteLine($"Before Swap: a={a}, b={b}"); // Output: Before Swap: a=10, b=20
            Swap<int>(ref a, ref b);
            Console.WriteLine($"After Swap:  a={a}, b={b}"); // Output: After Swap:  a=20, b=10

            // --- Demo: Generic Delegate ---
            Console.WriteLine("\n3. Generic Delegate:"); // Output: \n3. Generic Delegate:
            
            // Define what the printer does for strings
            Printer<string> stringPrinter = (s) => Console.WriteLine($"Printing String: {s.ToUpper()}"); // Output: Printing String: GENERICS ARE COOL
            
            // Define what the printer does for integers
            Printer<int> intPrinter = (i) => Console.WriteLine($"Printing Int: {i * 2}"); // Output: Printing Int: 100

            stringPrinter("generics are cool");
            intPrinter(50);

            // Using built-in Generic Delegates (Action, Func)
            Console.WriteLine("\n4. Built-in Generic Delegates (Func/Action):"); // Output: \n4. Built-in Generic Delegates (Func/Action):
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine($"Func Add(5, 10): {add(5, 10)}"); // Output: Func Add(5, 10): 15
        }
    }
}
