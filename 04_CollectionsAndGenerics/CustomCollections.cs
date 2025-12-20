using System;
using System.Collections;
using System.Collections.Generic;

namespace Concepts.CollectionsAndGenerics
{
    // ==========================================
    // Topic: Custom Collections (IEnumerable)
    // ==========================================
    //
    // STORY LINE:
    // THE MUSIC PLAYLIST:
    // Imagine you have a custom MP3 Player.
    // You want to be able to loop through songs using 'foreach'.
    // To do that, your MP3 Player must promise it is "Enumerable" (Countable/Listable).
    // It implements IEnumerable.
    //
    // The 'foreach' loop is just a magic trick. It actually calls:
    // 1. GetEnumerator() -> "Give me the cursor."
    // 2. MoveNext() -> "Go to next song."
    // 3. Current -> "Play this song."
    //
    // ==========================================

    // A simple custom collection
    class Playlist : IEnumerable<string>
    {
        private List<string> _songs = new List<string>();

        public void Add(string song) => _songs.Add(song);

        // This is the magic method required by 'foreach'
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var song in _songs)
            {
                // 'yield return' pauses execution and returns the value.
                // Next time the loop asks, it resumes right here.
                yield return song; 
            }
        }

        // Legacy support (required by interface)
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class CustomCollections
    {
        // To run this file: dotnet run --property:StartupObject=Concepts.CollectionsAndGenerics.CustomCollections
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Custom Collections Demo ---"); // Output: --- Custom Collections Demo ---

            Playlist myJams = new Playlist();
            myJams.Add("Bohemian Rhapsody");
            myJams.Add("Stairway to Heaven");
            myJams.Add("Hotel California");

            Console.WriteLine("Playing Playlist:"); // Output: Playing Playlist:
            // Because Playlist implements IEnumerable, we can use foreach!
            foreach (var song in myJams)
            {
                Console.WriteLine($"🎵 Now Playing: {song}"); // Output: 🎵 Now Playing: Bohemian Rhapsody
            }
        }
    }
}
