using System;

public class Swimming : Activity{

    private int _numberOfLabs;

    public Swimming(string date, int length, int numberOfLabs) : base(date, length)
    {
        _numberOfLabs = numberOfLabs;
    }

    public override double GetDistance()
    {
        return _numberOfLabs * 50 / 100;
    }

    public override double GetPace()
    {
        double pace =  _length / GetDistance();
        return Math.Ceiling(pace * 100) / 100;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _length) * 60;
    }
}