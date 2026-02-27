using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concepts.AsyncAndParallel
{
    // ==========================================
    // Topic: SemaphoreSlim
    // ==========================================
    //
    // STORY LINE:
    // THE EXCLUSIVE NIGHTCLUB:
    //
    // Imagine a nightclub with only 3 open booths.
    // 8 groups of friends arrive and want to sit down.
    //
    // THE BOUNCER (SemaphoreSlim):
    //   - He has a clicker that tracks how many booths are free.
    //   - He lets people in only when a booth is available.
    //   - When a group leaves (releases), the clicker goes up and the next group enters.
    //
    // WITHOUT A BOUNCER (No SemaphoreSlim):
    //   - All 8 groups rush in at once.
    //   - People are fighting over seats, chaos everywhere (Resource Exhaustion / System Overload).
    //
    // REAL WORLD EXAMPLE:
    //   - You have 100 async tasks that each call an external API.
    //   - Without SemaphoreSlim: You fire 100 requests simultaneously -> API rate-limit error / crash.
    //   - With SemaphoreSlim(3): Only 3 requests run at a time, the rest politely wait.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - SemaphoreSlim: A lightweight synchronization primitive that limits concurrent access to a resource.
    //
    // CONSTRUCTOR: new SemaphoreSlim(initialCount, maxCount)
    //   - initialCount: How many threads/tasks can enter RIGHT NOW (booths open at start).
    //                   If 0 -> nobody enters until someone calls Release() first.
    //                   If 3 -> 3 tasks can enter immediately without waiting.
    //   - maxCount:     The MAXIMUM number of concurrent entries EVER allowed (total booth count).
    //                   Acts as a ceiling. You cannot Release() beyond this number.
    //                   If omitted, defaults to int.MaxValue (no upper cap).
    //
    // EXAMPLE SCENARIOS:
    //   new SemaphoreSlim(3)      -> starts open for 3, no max cap.
    //   new SemaphoreSlim(3, 3)   -> starts open for 3, max is 3. (Most common: same value.)
    //   new SemaphoreSlim(0, 5)   -> starts CLOSED (0 free), max 5. Good for signaling patterns.
    //   new SemaphoreSlim(5, 5)   -> starts open for 5, max 5.
    //
    // KEY METHODS:
    //   WaitAsync() -> Async wait. Decrements the count. Blocks if count is 0.
    //   Wait()      -> Sync wait. Same but blocks the thread.
    //   Release()   -> Increments the count. Lets the next waiter in.
    //   CurrentCount -> How many slots are free right now.
    //
    // ==========================================

    class SemaphoreSlimDemo
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.AsyncAndParallel.SemaphoreSlimDemo

        // THE BOUNCER: only 3 groups (tasks) allowed inside at once, max cap is also 3.
        // initialCount = 3 -> 3 slots open immediately.
        // maxCount     = 3 -> you can never Release() to more than 3 (prevents over-releasing).
        private static readonly SemaphoreSlim _bouncer = new SemaphoreSlim(initialCount: 3, maxCount: 3);

        public static async Task Main(string[] args)
        {
            Console.WriteLine("--- SemaphoreSlim Demo ---"); // Output: --- SemaphoreSlim Demo ---
            Console.WriteLine("8 groups arrive, but only 3 booths exist.\n"); // Output: 8 groups arrive, but only 3 booths exist.

            // Fire all 8 tasks at once
            var groups = new Task[8];
            for (int i = 1; i <= 8; i++)
            {
                int groupId = i;
                groups[i - 1] = EnterNightclubAsync(groupId);
            }

            await Task.WhenAll(groups);

            Console.WriteLine("\nAll groups have been seated and left. Night over!"); // Output: All groups have been seated and left. Night over!

            // -----------------------------------------------
            // DEMO: SemaphoreSlim(0, 1) - The Signaling Pattern
            // initialCount = 0 -> starts CLOSED. Nobody enters until Release() is called.
            // maxCount     = 1 -> only one entry at a time (binary semaphore / manual-reset style).
            // Use case: Task B must wait for Task A to finish before it can proceed.
            // -----------------------------------------------
            Console.WriteLine("\n--- Signaling Pattern: initialCount=0, maxCount=1 ---"); // Output: --- Signaling Pattern: initialCount=0, maxCount=1 ---
            var signal = new SemaphoreSlim(initialCount: 0, maxCount: 1);

            var taskB = Task.Run(async () =>
            {
                Console.WriteLine("Task B: Waiting for Task A to signal..."); // Output: Task B: Waiting for Task A to signal...
                await signal.WaitAsync(); // Blocks here because initialCount is 0
                Console.WriteLine("Task B: Got the signal! Proceeding."); // Output: Task B: Got the signal! Proceeding.
            });

            await Task.Delay(1500); // Simulate Task A doing some work
            Console.WriteLine("Task A: Work done. Releasing signal."); // Output: Task A: Work done. Releasing signal.
            signal.Release(); // Opens the gate for Task B

            await taskB;
        }

        static async Task EnterNightclubAsync(int groupId)
        {
            Console.WriteLine($"Group {groupId}: Waiting outside... (Free slots: {_bouncer.CurrentCount})"); // Output: Group N: Waiting outside...

            // Async wait - does NOT block the thread, just suspends until a slot opens
            await _bouncer.WaitAsync();

            try
            {
                Console.WriteLine($"Group {groupId}: >>> Inside the club! <<<"); // Output: Group N: >>> Inside the club! <<<
                await Task.Delay(2000); // Simulate time spent inside (e.g., an API call)
            }
            finally
            {
                // ALWAYS release in finally so the slot is freed even if an exception occurs
                _bouncer.Release();
                Console.WriteLine($"Group {groupId}: Left the club. (Free slots: {_bouncer.CurrentCount})"); // Output: Group N: Left the club.
            }
        }
    }
}

