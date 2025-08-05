public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public string GetDate() => _date;
    public int GetLength() => _lengthMinutes;

    // Abstract methods to be overridden in subclasses
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Summary method (uses overridden methods)
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthMinutes} min): " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}
