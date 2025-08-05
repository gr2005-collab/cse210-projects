using System;
using System.Collections.Generic;
using System.Linq;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Queue<string> _promptQueue;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    private void ShufflePrompts()
    {
        Random rand = new Random();
        _promptQueue = new Queue<string>(_prompts.OrderBy(p => rand.Next()));
    }

    protected override void RunActivity()
    {
        if (_promptQueue == null || _promptQueue.Count == 0)
            ShufflePrompts();

        string prompt = _promptQueue.Dequeue();
        Console.WriteLine(prompt);
        Console.WriteLine("You may begin in:");
        Countdown(5);

        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                entries.Add(input);
        }

        Console.WriteLine($"You listed {entries.Count} items.");
    }
}
