using System;

namespace Concepts.OOP
{
    // ==========================================
    // Topic: Interfaces vs Abstract Classes
    // ==========================================
    //
    // STORY LINE:
    // THE JOB DESCRIPTION VS THE PARTIAL BLUEPRINT:
    //
    // 1. INTERFACE (The Job Description):
    //    "I don't care who you are or where you come from. Can you do the job?"
    //    Contract: "Must be able to Fly() and Swim()."
    //    A Bird can Fly. A Plane can Fly. They are unrelated, but both sign the contract.
    //    Multiple contracts allowed (Multiple Inheritance).
    //
    // 2. ABSTRACT CLASS (The Partial Blueprint):
    //    "We are building a Vehicle. All vehicles have wheels and an engine."
    //    "But I don't know how the engine starts yet (Abstract Method)."
    //    A Car IS A Vehicle. A Truck IS A Vehicle. They share DNA (Code).
    //    Only one parent allowed.
    //
    // ==========================================

    // Interface
    interface IFlyable
    {
        void Fly();
    }

    interface ISwimmable
    {
        void Swim();
    }

    // Abstract Class
    abstract class Animal
    {
        public string Name { get; set; } = "Unknown";
        
        // Shared code (Concrete method)
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping."); // Output: Donald is sleeping.
        }

        // Abstract method (Must be implemented by child)
        public abstract void MakeSound();
    }

    // Concrete Class implementing Abstract Class AND Interfaces
    class Duck : Animal, IFlyable, ISwimmable
    {
        public override void MakeSound()
        {
            Console.WriteLine("Quack!"); // Output: Quack!
        }

        public void Fly()
        {
            Console.WriteLine("Duck is flying."); // Output: Duck is flying.
        }

        public void Swim()
        {
            Console.WriteLine("Duck is swimming."); // Output: Duck is swimming.
        }
    }

    class InterfacesVsAbstract
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.OOP.InterfacesVsAbstract
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Interfaces vs Abstract Classes ---"); // Output: --- Interfaces vs Abstract Classes ---

            Duck d = new Duck { Name = "Donald" };
            
            // Using Abstract Class features
            d.Sleep();      // Inherited
            d.MakeSound();  // Overridden

            // Using Interface features
            d.Fly();
            d.Swim();
        }
    }
}
