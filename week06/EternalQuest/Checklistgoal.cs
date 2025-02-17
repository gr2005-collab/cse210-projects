using System;

public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        currentCount = 0;
    }

    public override void RecordEvent()
    {
        currentCount++;
        Console.WriteLine($"Recorded progress for '{Name}'. {Points} points earned.");

        if (currentCount == targetCount)
        {
            IsComplete = true;
            Console.WriteLine($"Congratulations! '{Name}' completed. Bonus {bonusPoints} points awarded.");
        }
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name} (Completed {currentCount}/{targetCount})" : $"[ ] {Name} (Completed {currentCount}/{targetCount})";
    }
}