using System;

namespace Concepts.AdvancedConcepts
{
    // ==========================================
    // Topic: Pattern Matching
    // ==========================================
    //
    // STORY LINE:
    // THE SMART SECURITY GUARD:
    // Imagine a security guard at a high-tech facility.
    //
    // OLD WAY (The "Ask and Check" Guard):
    // 1. Guard: "Are you an Employee?"
    // 2. Person: "Yes."
    // 3. Guard: "Okay, let me see your badge." (Casting)
    // 4. Guard: "Is your clearance level > 5?"
    // 5. Guard: "Okay, enter."
    // It's slow and involves multiple steps.
    //
    // NEW WAY (Pattern Matching Guard):
    // 1. Guard: "If you are an Employee with Clearance > 5, enter."
    // It happens in one smooth look. The guard checks the TYPE and the PROPERTY values simultaneously.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // Pattern matching tests an expression to see if it has a certain characteristic (type, value, or property structure).
    // It makes code more concise and readable, especially in conditional logic.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Eliminates messy `is` checks followed by casting.
    // - Makes `switch` statements much more powerful (Switch Expressions).
    // - Allows logic based on the *shape* of data rather than just its type.
    //
    // ==========================================

    public abstract class Shape { }
    public class Circle : Shape { public double Radius { get; set; } }
    public class Rectangle : Shape { public double Width { get; set; } public double Height { get; set; } }
    public class Triangle : Shape { public double Base { get; set; } public double Height { get; set; } }

    class PatternMatching
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AdvancedConcepts.PatternMatching
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Pattern Matching Demo ---");

            Shape s1 = new Circle { Radius = 5 };
            Shape s2 = new Rectangle { Width = 10, Height = 10 };
            Shape s3 = new Rectangle { Width = 5, Height = 8 };
            Shape s4 = new Triangle { Base = 6, Height = 4 };
            object? nullShape = null;

            // 1. Type Pattern (The "is" expression with variable declaration)
            Console.WriteLine("\n1. Type Pattern:");
            if (s1 is Circle c) // Checks type AND assigns to variable 'c' in one step
            {
                Console.WriteLine($"It's a circle with radius {c.Radius}");
            }

            // 2. Switch Expressions (The concise switch)
            Console.WriteLine("\n2. Switch Expressions:");
            Console.WriteLine($"Shape 1 Area: {CalculateArea(s1)}");
            Console.WriteLine($"Shape 2 Area: {CalculateArea(s2)}");
            Console.WriteLine($"Shape 4 Area: {CalculateArea(s4)}");

            // 3. Property Patterns & Relational Patterns
            Console.WriteLine("\n3. Property & Relational Patterns:");
            Console.WriteLine(DescribeShape(s2)); // Square
            Console.WriteLine(DescribeShape(s3)); // Rectangle
            Console.WriteLine(DescribeShape(s1)); // Circle

            // 4. Logical Patterns (and, or, not)
            Console.WriteLine("\n4. Logical Patterns:");
            int temperature = 25;
            if (temperature is >= 20 and <= 30)
            {
                Console.WriteLine("The temperature is comfortable.");
            }
            
            // 5. Null checking with patterns
            if (nullShape is not Circle)
            {
                 Console.WriteLine("nullShape is definitely not a Circle (it is null).");
            }
        }

        // Switch Expression Example
        static double CalculateArea(Shape shape) => shape switch
        {
            Circle c => Math.PI * c.Radius * c.Radius,
            Rectangle r => r.Width * r.Height,
            Triangle t => 0.5 * t.Base * t.Height,
            _ => 0 // The discard pattern (default case)
        };

        // Property Pattern Example
        static string DescribeShape(Shape shape) => shape switch
        {
            // "If it is a Rectangle AND Width equals Height"
            Rectangle { Width: var w, Height: var h } when w == h => $"A Square of size {w}",
            
            // "If it is a Rectangle" (fallback for non-squares)
            Rectangle r => $"A Rectangle {r.Width}x{r.Height}",
            
            // "If it is a Circle with Radius < 10"
            Circle { Radius: < 10 } => "A small circle",
            
            Circle => "A big circle",
            _ => "Unknown shape"
        };
    }
}
