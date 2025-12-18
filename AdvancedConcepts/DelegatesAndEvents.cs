using System;

namespace Concepts
{
    // ==========================================
    // Topic: Delegates and Events
    // ==========================================
    //
    // STORY LINE:
    // THE NEWSPAPER SUBSCRIPTION:
    // 1. Publisher (The Newspaper Company): They have news to share.
    // 2. Subscriber (You): You want to know when news happens.
    // 3. Delegate (The Delivery Boy): He knows WHERE you live (Method Pointer).
    // 4. Event (The Subscription List): The company keeps a list of delivery boys.
    //
    // When news happens (Event Raised), the company tells all the delivery boys on the list (Invoke Delegate).
    // The delivery boys go to their respective houses and throw the paper (Execute Method).
    //
    // ------------------------------------------
    // WHAT IS IT?
    // - Delegate: A type-safe function pointer. It holds a reference to a method.
    // - Event: A wrapper around a delegate. It allows clients to "Subscribe" (+=) or "Unsubscribe" (-=), but prevents them from clearing the whole list (= null) or invoking it directly.
    //
    // ------------------------------------------
    // WHY IS IT NEEDED?
    // - Decoupling: The Publisher doesn't need to know WHO the Subscribers are. It just shouts "News!", and whoever is listening reacts.
    // - GUI Programming: Button clicks, mouse movements.
    //
    // ==========================================

    // 1. Define the Delegate (The Delivery Boy's Job Description)
    // He can carry a message (string).
    public delegate void Notify(string message);

    class Publisher
    {
        // 2. Define the Event (The Subscription List)
        public event Notify? OnNewsPublished;

        public void PublishNews()
        {
            Console.WriteLine("Publisher: Printing the newspaper...");
            Console.WriteLine("Publisher: Sending out delivery boys...");

            // 3. Raise the Event (Tell the boys to go)
            if (OnNewsPublished != null)
            {
                OnNewsPublished("BREAKING NEWS: C# is awesome!");
            }
        }
    }

    class Subscriber
    {
        private string Name;

        public Subscriber(string name)
        {
            Name = name;
        }

        // The Method (Your House)
        public void ReadNews(string message)
        {
            Console.WriteLine($"Subscriber {Name} received: {message}");
        }
    }

    class DelegatesAndEvents
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.DelegatesAndEvents
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Delegates and Events Demo ---");

            Publisher nyt = new Publisher();
            Subscriber alice = new Subscriber("Alice");
            Subscriber bob = new Subscriber("Bob");

            // 4. Subscribe (Sign up)
            // We give the Publisher a pointer to our method.
            nyt.OnNewsPublished += alice.ReadNews;
            nyt.OnNewsPublished += bob.ReadNews;

            // 5. Action!
            nyt.PublishNews();

            Console.WriteLine("\nBob cancels subscription...");
            nyt.OnNewsPublished -= bob.ReadNews;

            nyt.PublishNews();
        }
    }
}
