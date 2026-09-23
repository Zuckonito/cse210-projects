using System;

// I added a smart word selection feature to the 'HideRandomWords' method. It only selects from words that 
//    are not already hidden using basic array loops. This avoids hiding the same word twice.
// And I also added a scripture library feature in Program.cs using a simple fixed-size array 
// of Scripture objects to randomly pick a scripture for the user.

class Program
{
    static void Main(string[] args)
    {
        Scripture[] scriptureLibrary = new Scripture[3];
        scriptureLibrary[0] = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        scriptureLibrary[1] = new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scriptureLibrary[2] = new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.");

        Random random = new Random();
        int randomIndex = random.Next(0, scriptureLibrary.Length);
        Scripture selectedScripture = scriptureLibrary[randomIndex];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }
    }
}