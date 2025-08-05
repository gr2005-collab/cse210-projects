public class Running : Activity
{
    private double _distanceKm;

    public Running(string date, int lengthMinutes, double distanceKm)
        : base(date, lengthMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;
    public override double GetSpeed() => (_distanceKm / GetLength()) * 60;
    public override double GetPace() => GetLength() / _distanceKm;
}
