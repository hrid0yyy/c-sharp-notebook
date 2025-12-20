using System;

namespace Concepts.CoreFundamentals
{
    // ==========================================
    // Topic: Control Flow (If, Switch, Loops)
    // ==========================================
    //
    // STORY LINE:
    // THE TRAFFIC CONTROLLER:
    // Imagine a busy intersection.
    //
    // 1. IF/ELSE (The Traffic Light):
    //    "If light is Green, Go. Else if Yellow, Slow down. Else (Red), Stop."
    //    Simple, binary decisions.
    //
    // 2. SWITCH (The Roundabout Sign):
    //    "Take exit 1 for City Center. Exit 2 for Airport. Exit 3 for Mall."
    //    Directs traffic based on a specific destination value.
    //
    // 3. LOOPS (The Race Track):
    //    "Keep driving around the track 10 times (For Loop)."
    //    "Keep driving until you run out of gas (While Loop)."
    //    "Drive at least once, then check if you want to continue (Do-While)."
    //
    // ==========================================

    class ControlFlow
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.CoreFundamentals.ControlFlow
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Control Flow Demo ---");

            // 1. If/Else
            int speed = 85;
            Console.WriteLine($"\n1. Speed Check ({speed} km/h):");
            if (speed > 100)
            {
                Console.WriteLine("  Too fast! Slow down.");
            }
            else if (speed > 60)
            {
                Console.WriteLine("  Good speed.");
            }
            else
            {
                Console.WriteLine("  Too slow!");
            }

            // 2. Switch Statement
            string trafficLight = "Yellow";
            Console.WriteLine($"\n2. Traffic Light ({trafficLight}):");
            switch (trafficLight)
            {
                case "Green":
                    Console.WriteLine("  Go!");
                    break;
                case "Yellow":
                    Console.WriteLine("  Prepare to stop.");
                    break;
                case "Red":
                    Console.WriteLine("  Stop!");
                    break;
                default:
                    Console.WriteLine("  Broken light, proceed with caution.");
                    break;
            }

            // 3. Loops
            Console.WriteLine("\n3. Loops:");
            
            // For Loop (Known number of iterations)
            Console.Write("  For Loop (Count to 3): ");
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // While Loop (Unknown iterations, check first)
            Console.Write("  While Loop (Fuel check): ");
            int fuel = 3;
            while (fuel > 0)
            {
                Console.Write($"[Fuel {fuel}] ");
                fuel--;
            }
            Console.WriteLine("Empty!");

            // Do-While Loop (Run at least once)
            Console.Write("  Do-While (One lap): ");
            int laps = 0;
            do
            {
                Console.Write("Lap finished. ");
                laps++;
            } while (laps < 1);
            Console.WriteLine();
            
            // Foreach Loop (Iterate collection)
            Console.Write("  Foreach (Cars): ");
            string[] cars = { "Ford", "BMW", "Toyota" };
            foreach (var car in cars)
            {
                Console.Write($"{car} ");
            }
            Console.WriteLine();
        }
    }
}
