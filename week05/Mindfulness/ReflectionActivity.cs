using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Queue<string> _questionQueue;

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    private void ShuffleQuestions()
    {
        Random rand = new Random();
        _questionQueue = new Queue<string>(_questions.OrderBy(q => rand.Next()));
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(4);

        if (_questionQueue == null || _questionQueue.Count == 0)
            ShuffleQuestions();

        int timePerQuestion = 6;
        int elapsed = 0;

        while (elapsed + timePerQuestion <= _duration && _questionQueue.Count > 0)
        {
            string question = _questionQueue.Dequeue();
            Console.WriteLine("> " + question);
            ShowSpinner(timePerQuestion);
            elapsed += timePerQuestion;
        }
    }
}
