using System;



// I added a counter tracking system ('activityCounter') in the main menu loop.
// It tracks how many total mindfulness activities the user has completed during the current
// session and displays this count on the menu screen to motivate the user.


class Program
{
    static void Main(string[] args)
    {
        int activityCounter = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine($"\n[Total activities completed this session: {activityCounter}]");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                activityCounter++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                activityCounter++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                activityCounter++;
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid option. Please enter a number from 1 to 4.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}