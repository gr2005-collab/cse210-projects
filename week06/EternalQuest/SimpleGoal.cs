using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsComplete = true;
        Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name}" : $"[ ] {Name}";
    }
}
