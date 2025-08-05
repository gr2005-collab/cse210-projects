public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints) 
        : base(name, description, -penaltyPoints) {}

    public override int RecordEvent() => GetPoints(); // returns negative points

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[⚠] {GetName()} (Penalty)";

    public override string SaveData() =>
        $"NegativeGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
}
