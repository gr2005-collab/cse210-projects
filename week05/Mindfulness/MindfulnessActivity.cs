using System;
using System.IO;
using System.Threading;

public abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        RunActivity();
        EndActivity();
        LogActivity();
    }

    protected abstract void RunActivity();

    private void EndActivity()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b");
            index = (index + 1) % spinner.Length;
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void LogActivity()
    {
        string log = $"{DateTime.Now}: Completed {_name} for {_duration} seconds.";
        File.AppendAllText("activity_log.txt", log + Environment.NewLine);
    }

    protected void ShowBreathingVisual(string direction, int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.Write($"\r{direction} " + new string('*', i));
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
