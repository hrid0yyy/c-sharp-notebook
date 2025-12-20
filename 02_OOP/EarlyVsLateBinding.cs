using System;
using System.Reflection;

namespace Concepts
{
    // ==========================================
    // Topic: Early Binding vs Late Binding
    // ==========================================
    //
    // STORY LINE:
    // EARLY BINDING (The Scripted Play):
    // The actors (Compiler) have the script (Code) weeks before the show.
    // They know exactly what lines to say. "Romeo, Romeo, where art thou?"
    // If there is a typo in the script, the director catches it during rehearsal (Compile Time).
    // It is fast and safe.
    //
    // LATE BINDING (The Improv Show):
    // The actors don't know what they will say until they are on stage.
    // The audience shouts "Be a pirate!", and the actor has to figure out how to be a pirate right then (Runtime).
    // If the audience shouts "Be a toaster!", and the actor doesn't know how, the show crashes (Runtime Error).
    // It is slower because the actor has to think, but it's flexible.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Early Binding (Static Binding): The compiler knows exactly which method to call at compile time.
    // - Late Binding (Dynamic Binding): The method to be called is decided at runtime using Reflection or the 'dynamic' keyword.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Early Binding: Performance, Type Safety, IntelliSense.
    // - Late Binding: Working with external libraries (COM objects, Office Automation), JSON where structure is unknown, or Reflection.
    //
    // ==========================================

    class Actor
    {
        public void Speak()
        {
            Console.WriteLine("Actor: To be or not to be...");
        }
    }

    class EarlyVsLateBinding
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.EarlyVsLateBinding
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Early vs Late Binding Demo ---");

            // 1. Early Binding
            Console.WriteLine("\n1. Early Binding (Compile Time):");
            Actor actor = new Actor();
            actor.Speak(); // Compiler knows 'Speak' exists.

            // 2. Late Binding (Using Reflection)
            Console.WriteLine("\n2. Late Binding (Reflection):");
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type? type = assembly.GetType("Concepts.Actor");
            
            if (type != null)
            {
                object? obj = Activator.CreateInstance(type);
                MethodInfo? method = type.GetMethod("Speak");
                
                if (obj != null && method != null)
                {
                    method.Invoke(obj, null); // We look up the method at runtime.
                }
            }

            // 3. Late Binding (Using dynamic)
            Console.WriteLine("\n3. Late Binding (dynamic keyword):");
            dynamic dynamicActor = new Actor();
            dynamicActor.Speak(); // Compiler doesn't check this. Runtime checks it.

            try
            {
                Console.WriteLine("Trying to call a method that doesn't exist...");
                dynamicActor.Dance(); // No error at compile time! Crash at runtime.
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Story: The audience asked for a dance, but the actor doesn't know how!");
            }
        }
    }
}
