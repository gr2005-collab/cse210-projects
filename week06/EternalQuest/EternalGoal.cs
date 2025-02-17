using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress for '{Name}'. {Points} points earned.");
    }

    public override string GetStatus()
    {
        return $"[∞] {Name}";
    }
}