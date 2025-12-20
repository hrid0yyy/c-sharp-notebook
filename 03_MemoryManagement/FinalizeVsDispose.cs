using System;
using System.IO;

namespace Concepts
{
    // ==========================================
    // Topic: Finalize vs Dispose
    // ==========================================
    //
    // STORY LINE:
    // Imagine you borrow a book from the library.
    //
    // DISPOSE (The Responsible Reader):
    // You finish the book. You immediately walk to the library and hand it to the librarian.
    // The book is now available for others instantly. You are in control.
    //
    // FINALIZE (The Forgetful Reader):
    // You finish the book but leave it on your coffee table.
    // You forget about it.
    // Weeks later, the "Library Janitor" (Garbage Collector) comes to your house to clean up.
    // He sees the book, realizes it belongs to the library, and takes it back.
    // You don't know WHEN he will come. It could be tomorrow, or next month.
    // Meanwhile, the book is unavailable to others.
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Dispose(): A method from the IDisposable interface. It is called EXPLICITLY by the developer to release unmanaged resources (files, database connections) immediately.
    // - Finalize() (Destructor): A method called IMPLICITLY by the Garbage Collector (GC) before the object is destroyed. You cannot control when it runs.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Unmanaged resources (like file handles) are not automatically managed by the CLR.
    // - Dispose ensures they are released as soon as you are done.
    // - Finalize is a safety net in case you forgot to call Dispose.
    //
    // ------------------------------------------
    // REAL LIFE SCENARIO:
    // - Reading a file: Use 'using' block (which calls Dispose) to close the file immediately so others can open it.
    //
    // ==========================================

    class ResourceHolder : IDisposable
    {
        // Constructor
        public ResourceHolder()
        {
            Console.WriteLine("ResourceHolder: Acquired resources (Book borrowed).");
        }

        // Dispose Method (The Responsible Way)
        public void Dispose()
        {
            Console.WriteLine("ResourceHolder: Dispose called. Releasing resources immediately (Book returned).");
            GC.SuppressFinalize(this); // Tell the Janitor he doesn't need to visit.
        }

        // Destructor / Finalizer (The Safety Net)
        ~ResourceHolder()
        {
            Console.WriteLine("ResourceHolder: Finalizer called by GC. Releasing resources late (Janitor took the book).");
        }
    }

    class FinalizeVsDispose
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.FinalizeVsDispose
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Finalize vs Dispose Demo ---");

            // 1. Using Dispose (Explicit)
            Console.WriteLine("\nScenario 1: The Responsible Reader");
            using (ResourceHolder responsible = new ResourceHolder())
            {
                Console.WriteLine("Using the resource...");
            } // Dispose is called automatically here at the end of the block.
            Console.WriteLine("End of Scenario 1.");

            // 2. Relying on Finalize (Implicit)
            Console.WriteLine("\nScenario 2: The Forgetful Reader");
            CreateForgetfulObject();
            
            Console.WriteLine("Object created and abandoned. Forcing Garbage Collection...");
            GC.Collect(); // Force the Janitor to come
            GC.WaitForPendingFinalizers(); // Wait for him to finish
            Console.WriteLine("End of Scenario 2.");
        }

        static void CreateForgetfulObject()
        {
            ResourceHolder forgetful = new ResourceHolder();
            // We do NOT call Dispose. We just let the variable go out of scope.
        }
    }
}
