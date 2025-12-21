using System;

namespace Concepts.DelegatesAndEvents
{
    // ==========================================
    // Topic: Covariance and Contravariance in Delegates
    // ==========================================
    //
    // STORY LINE:
    //
    // 1. COVARIANCE (The Generous Giver):
    //    Imagine you ask for a "Fruit" (Return Type).
    //    I give you an "Apple".
    //    Are you happy? Yes! An Apple IS A Fruit.
    //    Covariance allows a method to return a MORE derived type than the delegate expects.
    //    "I promised a small thing, but I gave you a big specific thing."
    //
    // 2. CONTRAVARIANCE (The Flexible Receiver):
    //    Imagine you are a vet who knows how to treat "Animals" (Parameter Type).
    //    I bring you a "Dog".
    //    Can you treat it? Yes! A Dog IS An Animal.
    //    Contravariance allows a delegate to point to a method that accepts a LESS derived type (Base class) than the delegate expects.
    //    "I expected a specific patient, but the doctor can handle ANY patient."
    //
    // ==========================================

    // Class Hierarchy
    class Animal { public string Name = "Animal"; }
    class Dog : Animal { public string Breed = "Pug"; }

    class CovarianceContravariance
    {
        // ------------------------------------------
        // 1. COVARIANCE (Return Types)
        // ------------------------------------------
        // Delegate expects to return an Animal.
        delegate Animal AnimalFactory();

        // Method returns a Dog (which is an Animal).
        static Dog GetDog() 
        {
            Console.WriteLine("Returning a Dog..."); // Output: Returning a Dog...
            return new Dog(); 
        }

        // ------------------------------------------
        // 2. CONTRAVARIANCE (Parameter Types)
        // ------------------------------------------
        // Delegate expects to take a Dog.
        delegate void DogHandler(Dog d);

        // Method takes an Animal (which covers Dogs).
        static void TreatAnimal(Animal a) 
        {
            Console.WriteLine($"Treating {a.Name}..."); // Output: Treating Animal...
        }

        // To run this file: dotnet run --property:StartupObject=Concepts.DelegatesAndEvents.CovarianceContravariance
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Covariance and Contravariance Demo ---"); // Output: --- Covariance and Contravariance Demo ---

            // --- Covariance Demo ---
            Console.WriteLine("\n1. Covariance (Return Type):"); // Output: \n1. Covariance (Return Type):
            
            // Delegate expects Animal, but we point it to a method returning Dog.
            // This works because Dog IS-A Animal.
            AnimalFactory factory = GetDog; 
            
            Animal result = factory(); 
            Console.WriteLine($"Got: {result.GetType().Name}"); // Output: Got: Dog

            // --- Contravariance Demo ---
            Console.WriteLine("\n2. Contravariance (Parameter Type):"); // Output: \n2. Contravariance (Parameter Type):

            // Delegate expects a Dog.
            // We point it to a method that takes an Animal.
            // This works because if the method can handle ANY Animal, it can certainly handle a Dog.
            DogHandler vet = TreatAnimal;

            Dog myDog = new Dog();
            vet(myDog); 
        }
    }
}
