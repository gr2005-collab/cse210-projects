using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.RecordEvent();
                    break;
                case "3":
                    manager.DisplayGoals();
                    break;
                case "4":
                    Console.WriteLine($"Your current score is: {manager.GetScore()}");
                    break;
                case "5":
                    manager.SaveGoals();
                    break;
                case "6":
                    manager.LoadGoals();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
