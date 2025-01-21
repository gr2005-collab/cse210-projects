using System;

class Program
{
    static void Main(string[] args)
    {
         Random randomGenerator = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = 0;
            int attempts = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");

            // Loop until the user guesses the magic number
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                    Console.WriteLine($"It took you {attempts} attempts.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again (yes/no)? ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}