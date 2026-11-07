using System.Collections.Generic;
using System;


class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        Journal journal = new Journal();
        

        List<string> prompts = new List<string>
{
    "Who was the most interesting person I interacted with today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I could do one thing over today, what would it be?",
    "Who first said 'I love you' in my relationship, and what do I remember about it?",
    "What gift or act of kindness has blessed me recently?",
    "What was my first international trip, and what do I remember most about it?",
    "Where would I like to go on vacation, and why?",
    "What is one part of my character I would like to improve?",
    "What is one of my greatest strengths?"
};

Random randomGenerator = new Random();

while (choice != 5)
{
    Console.WriteLine("Please select one of the following choices:");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Load");
    Console.WriteLine("4. Save");
    Console.WriteLine("5. Quit");
    Console.Write("What would you like to do? ");

    string input = Console.ReadLine();

    if (!int.TryParse(input, out choice))
{
    Console.WriteLine("Please enter a number from 1 to 5.");
    choice = 0;
}
else if (choice == 1)
{
    int promptIndex = randomGenerator.Next(prompts.Count);

    Entry newEntry = new Entry();
    newEntry._date = DateTime.Now.ToShortDateString();
    newEntry._prompt = prompts[promptIndex];

    Console.WriteLine(newEntry._prompt);
    Console.Write("> ");
    newEntry._response = Console.ReadLine() ?? "";

    journal.AddEntry(newEntry);
}
else if (choice == 2)
{
    journal.DisplayAll();
}

else if (choice == 3)
{
    Console.Write("Enter the filename to load: ");
    string filename = Console.ReadLine();
    journal.LoadFromFile(filename);
    Console.WriteLine("Journal loaded.");
}

else if (choice == 4)
{
    Console.Write("Enter a filename (for example, journal.txt): ");
    string filename = Console.ReadLine();
    journal.SaveToFile(filename);
    Console.WriteLine("Journal saved.");
}

    
    
}
    }
}
