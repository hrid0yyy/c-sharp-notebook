using System;

namespace Concepts.MemoryManagement
{
    // ==========================================
    // Topic: Stack vs Heap
    // ==========================================
    //
    // STORY LINE:
    // THE NOTEBOOK VS THE WHITEBOARD:
    //
    // 1. THE STACK (The Notebook):
    //    Small, personal, organized.
    //    You write tasks one by one. When a task is done, you cross it out immediately.
    //    Very fast.
    //    Stores: Value Types (int, bool, struct) and Pointers (References).
    //    "Last In, First Out" (LIFO).
    //
    // 2. THE HEAP (The Whiteboard):
    //    Huge, messy, shared.
    //    You draw big diagrams here.
    //    When you are done, you leave it there.
    //    Eventually, the Janitor (Garbage Collector) comes and wipes it clean.
    //    Slower allocation.
    //    Stores: Reference Types (Objects, Strings, Arrays).
    //
    // ==========================================

    class StackVsHeap
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.MemoryManagement.StackVsHeap
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Stack vs Heap Demo ---");

            // 1. Stack Allocation
            // 'x' and 'y' are integers. They live on the Stack.
            // Allocation is instant. Deallocation happens when Main() finishes.
            int x = 10; 
            int y = 20;
            Console.WriteLine($"Stack: x={x}, y={y}");

            // 2. Heap Allocation
            // 'p' is a reference (pointer). It lives on the Stack.
            // The actual 'Person' object lives on the Heap.
            // 'p' points to the memory address on the Heap.
            PersonHeap p = new PersonHeap(); 
            p.Age = 30;
            Console.WriteLine($"Heap: Person object created at address pointed to by 'p'. Age={p.Age}");

            // 3. Scope
            DoWork();
            // After DoWork returns:
            // - The stack frame for DoWork is popped (destroyed).
            // - The 'temp' variable is gone.
            // - The 'Person' object created inside DoWork is now an "Orphan" on the Heap.
            // - The Garbage Collector will eventually delete it.
            
            Console.WriteLine("Back in Main. The object from DoWork is now garbage.");
        }

        static void DoWork()
        {
            int temp = 5; // Stack
            PersonHeap orphan = new PersonHeap(); // Heap
            Console.WriteLine($"Inside DoWork: temp={temp}");
        }
    }

    class PersonHeap
    {
        public int Age { get; set; }
    }
}
