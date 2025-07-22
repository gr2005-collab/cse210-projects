// Enhancement: This program avoids hiding already hidden words by tracking unhidden words only.
// It also supports verse ranges (e.g., Proverbs 3:5-6) and separates all classes into their own files.
// Future improvements may include loading scripture from a file or allowing a hint mode.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Customize your scripture here
        var reference = new Reference("Proverbs", 3, 5, 6);
        var scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";

        var scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words have been hidden. Good job!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }
    }
}
