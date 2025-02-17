using System;

public class RewardSystem
{
    private int level;
    private int points;

    public RewardSystem()
    {
        level = 1;
        points = 0;
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        Console.WriteLine($"You earned {newPoints} points! Total: {points}");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredPoints = level * 1000;
        if (points >= requiredPoints)
        {
            level++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {level}!");
        }
    }

    public int GetPoints() => points;
    public int GetLevel() => level;
}
