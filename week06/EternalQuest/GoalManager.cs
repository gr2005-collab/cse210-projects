public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int points = _goals[goalIndex].RecordEvent();
            _score += points;
            Console.WriteLine(points >= 0
                ? $"You earned {points} points!"
                : $"Oops! You lost {-points} points.");
        }
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
    }

    public int GetScore() => _score;

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
                writer.WriteLine(goal.SaveData());
        }
    }

    public void Load(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            switch (type)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(parts[4]);
                    var simple = new SimpleGoal(name, desc, points);
                    if (isComplete) simple.RecordEvent(); // simulate completion
                    _goals.Add(simple);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;
                case "ChecklistGoal":
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);
                    var checklist = new ChecklistGoal(name, desc, points, target, bonus);
                    for (int j = 0; j < completed; j++) checklist.RecordEvent();
                    _goals.Add(checklist);
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(name, desc, -points));
                    break;
            }
        }
    }
}
