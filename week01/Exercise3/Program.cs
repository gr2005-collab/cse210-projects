using System;

class Program
{
    static void Main()
    {
        string playAgain;

        do
        {
            // Create random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100 inclusive

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I have picked a magic number between 1 and 100. Try to guess it!");

            // Main guessing loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

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
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
