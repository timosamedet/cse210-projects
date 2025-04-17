using System;

public class Running : Activity{

    private double _distance;

    public Running(string date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetPace()
    {
        double pace = _length /_distance;
        return Math.Ceiling(pace * 100) / 100;
    }

    public override double GetSpeed()
    {
        return (_distance / _length) * 60;
    }
}