using System;


// Exceeded requirements by:
// 1. Added mood tracking for each journal entry.
// 2. Added extra prompts beyond the required minimum.
// 3. Added error handling to prevent crashes from invalid input.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");

            try
            {
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine(prompt);
                    Console.Write("> ");

                    string response = Console.ReadLine();

                    Console.Write("What was your mood today? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();

                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._mood = mood;

                    theJournal.AddEntry(newEntry);

                    Console.WriteLine("Entry added.\n");
                }

                else if (choice == 2)
                {
                    Console.WriteLine();

                    theJournal.DisplayAll();
                }

                else if (choice == 3)
                {
                    Console.Write("Enter filename to save: ");

                    string file = Console.ReadLine();

                    theJournal.SaveToFile(file);

                    Console.WriteLine("Journal saved.\n");
                }

                else if (choice == 4)
                {
                    Console.Write("Enter filename to load: ");

                    string file = Console.ReadLine();

                    theJournal.LoadFromFile(file);

                    Console.WriteLine("Journal loaded.\n");
                }

                else if (choice == 5)
                {
                    Console.WriteLine("Goodbye!");
                }

                else
                {
                    Console.WriteLine("Please enter a number from 1 to 5.\n");
                }
            }

            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }
}