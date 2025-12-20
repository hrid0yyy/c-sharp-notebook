using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Concepts.AsyncAndParallel
{
    // ==========================================
    // Topic: Task Parallel Library (TPL) - Parallel.For
    // ==========================================
    //
    // STORY LINE:
    // THE ASSEMBLY LINE:
    //
    // 1. SEQUENTIAL LOOP (One Worker):
    //    Imagine painting 100 fences.
    //    One guy paints Fence 1, then Fence 2, then Fence 3...
    //    It takes 100 hours.
    //
    // 2. PARALLEL LOOP (Team of Workers):
    //    You hire 10 guys.
    //    Guy A paints Fence 1-10. Guy B paints Fence 11-20...
    //    They work at the SAME TIME (Multicore).
    //    It takes 10 hours.
    //
    // WARNING:
    // If they all try to dip their brush in the SAME paint bucket (Shared Resource) at the exact same time, they will bump heads (Race Condition).
    //
    // ==========================================

    class TaskParallelLibrary
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AsyncAndParallel.TaskParallelLibrary
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Parallel Programming Demo ---");

            int totalItems = 10;

            // 1. Sequential Loop
            Console.WriteLine("\n1. Sequential Loop (One Thread):");
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < totalItems; i++)
            {
                DoHeavyWork(i);
            }
            sw.Stop();
            Console.WriteLine($"Sequential took: {sw.ElapsedMilliseconds} ms");

            // 2. Parallel Loop
            Console.WriteLine("\n2. Parallel Loop (Multiple Threads):");
            sw.Restart();
            // The TPL automatically divides the work among available CPU cores.
            Parallel.For(0, totalItems, i =>
            {
                DoHeavyWork(i);
            });
            sw.Stop();
            Console.WriteLine($"Parallel took: {sw.ElapsedMilliseconds} ms");
        }

        static void DoHeavyWork(int id)
        {
            // Simulate work (100ms sleep)
            System.Threading.Thread.Sleep(100);
            // Console.WriteLine is thread-safe, but output might be jumbled.
            // Console.WriteLine($"Processing item {id} on Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
