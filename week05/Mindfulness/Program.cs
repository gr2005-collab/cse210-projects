using System;

/*
Enhancements added to exceed requirements:
1. Logged all completed activities to a file (activity_log.txt) with date and duration.
2. Prevented repeating prompts and questions in a session using shuffled queues.
3. Added animated breathing visuals using expanding asterisks.
4. Used countdowns and spinners for all pauses.
*/

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (choice == "4" || activity == null)
                break;

            activity.StartActivity();
        }

        Console.WriteLine("Goodbye!");
    }
}
