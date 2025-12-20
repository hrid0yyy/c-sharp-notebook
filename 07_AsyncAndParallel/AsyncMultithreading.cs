using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concepts.AsyncAndParallel
{
    // ==========================================
    // Topic: Async/Await and Multithreading
    // ==========================================
    //
    // STORY LINE:
    // THE BREAKFAST CHEF:
    //
    // SYNCHRONOUS (The Bad Chef):
    // 1. Put bread in toaster.
    // 2. Stare at toaster for 2 minutes until it pops. (Blocking)
    // 3. Pour coffee.
    // 4. Fry eggs.
    // Total time: Long. Customers angry.
    //
    // ASYNCHRONOUS (The Good Chef - Async/Await):
    // 1. Put bread in toaster.
    // 2. Don't stare! Start pouring coffee while bread toasts. (Non-blocking)
    // 3. When toaster pops (Await), butter the toast.
    //
    // MULTITHREADING (The Kitchen Team):
    // You hire 3 chefs (Threads).
    // Chef A toasts bread. Chef B fries eggs. Chef C pours coffee.
    // They work at the exact same time.
    // Danger: If Chef A and Chef B try to grab the ONLY salt shaker at the same time, they crash (Race Condition).
    // Solution: Use a Lock (Only one person holds the salt at a time).
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Async/Await: Frees up the current thread (usually UI) while waiting for I/O (Database, Web API).
    // - Task: Represents a unit of work that will complete in the future.
    // - Thread: The worker that executes the code.
    // - Lock: Ensures only one thread accesses a shared resource at a time.
    //
    // ==========================================

    class AsyncMultithreading
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AsyncMultithreading
        public static async Task Main(string[] args)
        {
            Console.WriteLine("--- Async and Multithreading Demo ---"); // Output: --- Async and Multithreading Demo ---

            // 1. Async/Await Demo
            Console.WriteLine("\n1. Starting Breakfast (Async)..."); // Output: \n1. Starting Breakfast (Async)...
            Task<string> toastTask = ToastBreadAsync();
            Task<string> eggTask = FryEggsAsync();

            Console.WriteLine("Chef is pouring coffee while food cooks..."); // Output: Chef is pouring coffee while food cooks...
            
            // Wait for both to finish
            string toast = await toastTask;
            string eggs = await eggTask;

            Console.WriteLine($"Breakfast is ready: {toast} and {eggs}"); // Output: Breakfast is ready: Buttered Toast and Fried Eggs

            // 2. Multithreading & Locking Demo
            Console.WriteLine("\n2. Multithreading & Locking (The Salt Shaker)..."); // Output: \n2. Multithreading & Locking (The Salt Shaker)...
            Thread t1 = new Thread(UseSalt);
            Thread t2 = new Thread(UseSalt);
            
            t1.Start();
            t2.Start();
            
            t1.Join();
            t2.Join();
        }

        static async Task<string> ToastBreadAsync()
        {
            Console.WriteLine("  -> Bread in toaster..."); // Output:   -> Bread in toaster...
            await Task.Delay(2000); // Simulate 2 seconds work without blocking
            Console.WriteLine("  -> Toast popped!"); // Output:   -> Toast popped!
            return "Buttered Toast";
        }

        static async Task<string> FryEggsAsync()
        {
            Console.WriteLine("  -> Eggs in pan..."); // Output:   -> Eggs in pan...
            await Task.Delay(2000);
            Console.WriteLine("  -> Eggs cooked!"); // Output:   -> Eggs cooked!
            return "Fried Eggs";
        }

        // Shared Resource
        static object saltLock = new object();
        static void UseSalt()
        {
            // Without lock, output might be mixed up
            lock (saltLock)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} grabbed the salt."); // Output: Thread [ID] grabbed the salt.
                Thread.Sleep(500); // Using salt
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} put back the salt."); // Output: Thread [ID] put back the salt.
            }
        }
    }
}
