using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("what is the magic number?");
        //string number = Console.ReadLine();

        Random randomNumber = new Random();
        int number = randomNumber.Next(1, 101);

        int UserGuess = -1;

        while (UserGuess != number)
        {
            Console.Write("What is your guess? ");
            UserGuess = int.Parse(Console.ReadLine());

            if (number > UserGuess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < UserGuess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }                    

    }
}