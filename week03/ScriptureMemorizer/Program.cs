using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        // Load each passage from the file and create its Reference and Scripture objects.
        foreach (string line in File.ReadAllLines("scriptures.txt"))
        {
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string scriptureText = parts[4];

            Reference scriptureReference;

            if (startVerse == endVerse)
            {
                scriptureReference = new Reference(book, chapter, startVerse);
            }
            else
            {
                scriptureReference =
                    new Reference(book, chapter, startVerse, endVerse);
            }

            scriptures.Add(new Scripture(scriptureReference, scriptureText));
        }

        // Creativity: Loads several passages from a file, reviews each one, and then advances to the next.
        for (int scriptureIndex = 0;
             scriptureIndex < scriptures.Count;
             scriptureIndex++)
        {
            Scripture scripture = scriptures[scriptureIndex];

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.Write(
                    "Press Enter to hide more words, type clue for a clue, or type quit to finish: ");

                string response = Console.ReadLine() ?? "";

                if (response.Trim().Equals(
                    "quit",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
                if (response.Trim().Equals(
    "quit",
    StringComparison.OrdinalIgnoreCase))
{
    return;
}

// Creativity: A clue gives the position and first letter of a hidden word.
if (response.Trim().Equals(
    "clue",
    StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine(scripture.GetRandomHiddenWordClue());
    Console.WriteLine("Press Enter to return to the scripture.");
    Console.ReadLine();
    continue;
}


                scripture.HideRandomWords(3);
            }

            // Show the fully hidden passage, then reveal it for the memory check.
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            scripture.ShowAllWords();

            Console.WriteLine();
            Console.WriteLine("Memory check — here is the complete passage:");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scriptureIndex < scriptures.Count - 1)
            {
                Console.Write("Press Enter to hide more words, type clue for a clue, or type quit to finish: ");

                string response = Console.ReadLine() ?? "";

                if (response.Trim().Equals(
                    "quit",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("You have finished all the passages.");
                Console.ReadLine();
            }
        }
    }
}