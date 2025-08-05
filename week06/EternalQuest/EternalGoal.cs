public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) {}

    public override int RecordEvent() => GetPoints();

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[∞] {GetName()}";

    public override string SaveData() =>
        $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
}
