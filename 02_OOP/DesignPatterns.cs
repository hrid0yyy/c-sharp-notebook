using System;
using System.Collections.Generic;

namespace Concepts
{
    // ==========================================
    // Topic: Design Patterns (Singleton, Factory, Repository)
    // ==========================================

    // 1. Singleton - Only ONE president ever
    class President
    {
        private static President? _instance;
        private President() { Console.WriteLine("President Elected!"); }
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

    // 2. Factory - Creates different pizzas without exposing logic
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

    // 3. Repository - Hides where data really comes from
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        public override string ToString()
            => $"#{Id} {Name,-12} ${Price}";
    }

    interface IProductRepository
    {
        Product? GetById(int id);
        List<Product> GetAll();
        List<Product> FindByName(string namePart);
        void Add(Product product);
    }

    class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Apple",     Price = 0.35m },
            new Product { Id = 2, Name = "Banana",    Price = 0.25m },
            new Product { Id = 3, Name = "Mango",     Price = 1.20m },
            new Product { Id = 4, Name = "Orange",    Price = 0.60m },
            new Product { Id = 5, Name = "Pineapple", Price = 2.99m },
        };

        public Product? GetById(int id) => _products.Find(p => p.Id == id);

        public List<Product> GetAll() => new List<Product>(_products);

        public List<Product> FindByName(string namePart)
            => _products.FindAll(p => p.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase));

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            Console.WriteLine($"Added → {product}");
        }
    }

    // ──────────────────────────────────────────

    class DesignPatterns
    {
        // To run: dotnet run --property:StartupObject=Concepts.DesignPatterns
        public static void Main(string[] args)
        {
            // Output: === Design Patterns Demo ===
            Console.WriteLine("=== Design Patterns Demo ===\n");

            // ── Singleton demo ────────────────────────────────────────
            // Output:
            // 1. Singleton:
            // President Elected!
            // I am the President.
            // p1 == p2 ? True
            Console.WriteLine("1. Singleton:");
            President p1 = President.Instance;
            President p2 = President.Instance;
            p1.Announce();
            Console.WriteLine($"p1 == p2 ? {ReferenceEquals(p1, p2)}\n");

            // ── Factory demo ──────────────────────────────────────────
            // Output:
            // 2. Factory:
            // Eating Pepperoni Pizza
            Console.WriteLine("2. Factory:");
            var pizza = PizzaFactory.CreatePizza("Pepperoni");
            pizza?.Eat();
            Console.WriteLine();

            // ── Repository demo ───────────────────────────────────────
            // Output:
            // 3. Repository:  
            Console.WriteLine("3. Repository:");
            IProductRepository warehouse = new InMemoryProductRepository();

            Console.WriteLine("Get product #3:");
            var item = warehouse.GetById(3);
            Console.WriteLine(item ?? (object)"Not found");
            Console.WriteLine();
            // Get product #3:
            // #3 Mango        $1.20
            //

            Console.WriteLine("All products:");
            foreach (var p in warehouse.GetAll())
                Console.WriteLine($"  {p}");
            Console.WriteLine();
            // All products:
            //   #1 Apple       $0.35
            //   #2 Banana      $0.25
            //   #3 Mango       $1.20
            //   #4 Orange      $0.60
            //   #5 Pineapple   $2.99

            Console.WriteLine("Search 'an':");
            foreach (var p in warehouse.FindByName("an"))
                Console.WriteLine($"  {p}");
            Console.WriteLine();
            // Search 'an':
            //   #1 Apple       $0.35
            //   #2 Banana      $0.25
            //   #3 Mango       $1.20

            Console.WriteLine("Adding new product...");
            warehouse.Add(new Product { Name = "Kiwi", Price = 0.85m });
            Console.WriteLine();
            // Adding new product...
            // Added → #6 Kiwi        $0.85

            Console.WriteLine("After adding — GetAll again:");
            foreach (var p in warehouse.GetAll())
                Console.WriteLine($"  {p}");
            // After adding — GetAll again:
            //   #1 Apple       $0.35
            //   #2 Banana      $0.25
            //   #3 Mango       $1.20
            //   #4 Orange      $0.60
            //   #5 Pineapple   $2.99
            //   #6 Kiwi        $0.85
        }
    }
}
