public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _targetCount)
            return GetPoints() + _bonusPoints;
        return GetPoints();
    }

    public override bool IsComplete() => _timesCompleted >= _targetCount;

    public override string GetStatus() =>
        $"[{(_timesCompleted >= _targetCount ? "X" : " ")}] {GetName()} -- Completed {_timesCompleted}/{_targetCount}";

    public override string SaveData() =>
        $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonusPoints}|{_timesCompleted}";
}
