using System;

class Program
{
    static void Main(string[] args)
    {
         Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int gradePercentage;

        // Validate input
        if (!int.TryParse(userInput, out gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        // Core Requirement 2: Determine the letter grade
        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement 3: Determine pass/fail
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying, and you'll succeed next time.");
        }

        // Stretch Challenge 1: Add "+" or "-" to the grade
        if (letter != "F") // No "+" or "-" for F grades
        {
            int lastDigit = gradePercentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }

            // Stretch Challenge 2: Handle the A+ case (No A+ grade)
            if (letter == "A" && sign == "+")
            {
                sign = ""; // Reset sign for A+
            }
        }

        // Stretch Challenge 3: Handle F grades (No F+ or F-)
        if (letter == "F")
        {
            sign = ""; // Reset sign for F
        }

        // Core Requirement 4: Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");
    }
}