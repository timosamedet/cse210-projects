using System;

public class Cycling : Activity{

    private double _speed;

    public Cycling(string date, int length, double speed) : base(date, length){
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _length) / 60;
    }

    public override double GetPace()
    {
        double pace =  60 / _speed;
        return Math.Ceiling(pace * 100) / 100;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}