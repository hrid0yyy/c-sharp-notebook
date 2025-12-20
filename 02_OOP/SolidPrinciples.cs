using System;

namespace Concepts
{
    // ==========================================
    // Topic: SOLID Principles
    // ==========================================
    //
    // STORY LINE:
    // THE LEGO MASTER BUILDER:
    //
    // S - Single Responsibility (The Specialist):
    // A Lego brick should do ONE thing. A wheel is a wheel. It shouldn't also be a wing.
    // If a class handles Database AND Email AND Logging, it's a mess. Split it up.
    //
    // O - Open/Closed (The Extension Pack):
    // You bought a Lego castle. You want to add a dragon.
    // You shouldn't have to melt the castle walls to attach the dragon.
    // You should be able to just CLICK the dragon onto the existing studs.
    // (Open for extension, Closed for modification).
    //
    // L - Liskov Substitution (The Standard Brick):
    // If a manual says "Use a 2x4 Red Brick", you should be able to use a "2x4 Blue Brick" and the wall shouldn't collapse.
    // A subclass should behave like its parent without breaking the app.
    //
    // I - Interface Segregation (The Menu):
    // Don't give a customer a menu with "Pizza, Sushi, Car Repair, and Dental Surgery".
    // Give them small, specific menus.
    // Don't force a class to implement methods it doesn't need.
    //
    // D - Dependency Inversion (The Power Outlet):
    // Your lamp doesn't need to be hardwired into the nuclear power plant.
    // It just needs a standard plug (Interface).
    // You can plug it into the wall, a battery, or a generator. The lamp doesn't care.
    //
    // ==========================================

    // S: Single Responsibility
    class ReportGenerator
    {
        public void Generate() { Console.WriteLine("Generating Report..."); } // Output: Generating Report...
    }
    class ReportSaver // Separate class for saving
    {
        public void SaveToFile() { Console.WriteLine("Saving to File..."); } // Output: Saving to File...
    }

    // O: Open/Closed
    abstract class Shape
    {
        public abstract void Draw();
    }
    class Circle : Shape
    {
        public override void Draw() { Console.WriteLine("Drawing Circle"); } // Output: Drawing Circle
    }
    class Square : Shape // We added Square without changing Shape or Circle!
    {
        public override void Draw() { Console.WriteLine("Drawing Square"); } // Output: Drawing Square
    }

    class SolidPrinciples
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.SolidPrinciples
        public static void Main(string[] args)
        {
            Console.WriteLine("--- SOLID Principles Demo ---"); // Output: --- SOLID Principles Demo ---
            
            // O: Open/Closed Usage
            Shape s1 = new Circle();
            Shape s2 = new Square();
            s1.Draw();
            s2.Draw();

            Console.WriteLine("See comments in code for full stories!"); // Output: See comments in code for full stories!
        }
    }
}
