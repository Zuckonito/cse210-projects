using System;

// EXCEEDING REQUIREMENTS:
// Added a mood/feeling score (scale 1-10) saved along with the entry text.
// Also added basic input validation for file handling and empty inputs.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How would you rate your mood today (1-10)? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = $"[Mood: {mood}/10] {response}";

                    theJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded!\n");
                    break;

                case "2": 
                    theJournal.DisplayAll();
                    break;

                case "3": 
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case "5": 
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.\n");
                    break;
            }
        }
    }
}