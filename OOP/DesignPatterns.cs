using System;

namespace Concepts
{
    // ==========================================
    // Topic: Design Patterns (Singleton, Factory, Repository)
    // ==========================================
    //
    // STORY LINE:
    //
    // SINGLETON (The President):
    // There can be only ONE President of the country.
    // If you ask "Who is the President?", you always get the same person.
    // You don't elect a new President every time you ask.
    //
    // FACTORY (The Pizza Machine):
    // You don't make pizza yourself. You go to a machine.
    // You press "Pepperoni", it gives you a Pepperoni Pizza.
    // You press "Cheese", it gives you a Cheese Pizza.
    // You don't need to know HOW to bake it. The machine handles the creation logic.
    //
    // REPOSITORY (The Warehouse Manager):
    // You are a shopkeeper. You need products.
    // You don't go to the factory, or the farm, or the mine.
    // You just ask the Warehouse Manager: "Get me 5 Apples".
    // He knows where to find them (Database, File, API). You just trust him.
    //
    // ==========================================

    // 1. Singleton
    class President
    {
        private static President? _instance;
        private President() { Console.WriteLine("President Elected!"); } // Private Constructor

        public static President Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new President();
                return _instance;
            }
        }
        public void Announce() { Console.WriteLine("I am the President."); }
    }

    // 2. Factory
    abstract class Pizza { public abstract void Eat(); }
    class CheesePizza : Pizza { public override void Eat() { Console.WriteLine("Eating Cheese Pizza"); } }
    class PepperoniPizza : Pizza { public override void Eat() { Console.WriteLine("Eating Pepperoni Pizza"); } }

    class PizzaFactory
    {
        public static Pizza? CreatePizza(string type)
        {
            if (type == "Cheese") return new CheesePizza();
            if (type == "Pepperoni") return new PepperoniPizza();
            return null;
        }
    }

    class DesignPatterns
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.DesignPatterns
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Design Patterns Demo ---");

            // Singleton
            Console.WriteLine("\n1. Singleton:");
            President p1 = President.Instance;
            President p2 = President.Instance; // Same instance! Constructor not called again.
            p1.Announce();

            // Factory
            Console.WriteLine("\n2. Factory:");
            Pizza? myPizza = PizzaFactory.CreatePizza("Cheese");
            if (myPizza != null)
            {
                myPizza.Eat();
            }
            else
            {
                Console.WriteLine("Factory returned no pizza!");
            }
        }
    }
}
