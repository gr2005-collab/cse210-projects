using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter points for the goal:");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose goal type: 1 - Simple, 2 - Eternal, 3 - Checklist");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.WriteLine("Enter target count:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        DisplayGoals();
        Console.WriteLine("Enter the number of the goal you completed:");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            score += goals[index].Points;
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.GetStatus()}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                score = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);

                    if (type == "SimpleGoal")
                        goals.Add(new SimpleGoal(name, points));
                    else if (type == "EternalGoal")
                        goals.Add(new EternalGoal(name, points));
                    else if (type == "ChecklistGoal")
                    {
                        int target = int.Parse(parts[3]);
                        int bonus = int.Parse(parts[4]);
                        goals.Add(new ChecklistGoal(name, points, target, bonus));
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
