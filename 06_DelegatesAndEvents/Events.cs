using System;

namespace Concepts.DelegatesAndEvents
{
    // ==========================================
    // Topic: Events
    // ==========================================
    //
    // STORY LINE:
    // THE NEWSPAPER SUBSCRIPTION:
    // 1. Publisher (The Newspaper Company): They have news to share.
    // 2. Subscriber (You): You want to know when news happens.
    // 3. Event (The Subscription List): The company keeps a list of subscribers.
    //
    // When news happens (Event Raised), the company notifies everyone on the list.
    // You cannot just walk into the company and shout "News!" (Invoke Event directly). 
    // Only the Publisher can do that. You can only Subscribe (+=) or Unsubscribe (-=).
    //
    // ==========================================

    // Delegate for the event
    public delegate void Notify(string message);

    class Publisher
    {
        // Define the Event
        // 'event' keyword adds a layer of protection over the delegate.
        public event Notify? OnNewsPublished;

        public void PublishNews()
        {
            Console.WriteLine("Publisher: Printing the newspaper..."); // Output: Publisher: Printing the newspaper...
            Console.WriteLine("Publisher: Sending out delivery boys..."); // Output: Publisher: Sending out delivery boys...

            // Raise the Event
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

        public void ReadNews(string message)
        {
            Console.WriteLine($"Subscriber {Name} received: {message}"); // Output: Subscriber [Name] received: [message]
        }
    }

    class Events
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.DelegatesAndEvents.Events
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Events Demo ---"); // Output: --- Events Demo ---

            Publisher nyt = new Publisher();
            Subscriber alice = new Subscriber("Alice");
            Subscriber bob = new Subscriber("Bob");

            // Subscribe
            nyt.OnNewsPublished += alice.ReadNews;
            nyt.OnNewsPublished += bob.ReadNews;

            // Action!
            nyt.PublishNews();
            // Output:
            // Publisher: Printing the newspaper...
            // Publisher: Sending out delivery boys...
            // Subscriber Alice received: BREAKING NEWS: C# is awesome!
            // Subscriber Bob received: BREAKING NEWS: C# is awesome!

            Console.WriteLine("\nBob cancels subscription..."); // Output: \nBob cancels subscription...
            nyt.OnNewsPublished -= bob.ReadNews;

            nyt.PublishNews();
            // Output:
            // Publisher: Printing the newspaper...
            // Publisher: Sending out delivery boys...
            // Subscriber Alice received: BREAKING NEWS: C# is awesome!
        }
    }
}
