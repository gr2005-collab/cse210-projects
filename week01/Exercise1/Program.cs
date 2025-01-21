using System;

class Program
{
    static void Main(string[] args)
    {
         Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the name in the required format
        Console.WriteLine($"Your name is {lastName: KELLA}, {firstName:MARIAMA} {lastName:KELLA}.");
    }
}