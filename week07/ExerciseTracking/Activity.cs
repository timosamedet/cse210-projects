using System;

public abstract class Activity{
    private string _date;
    protected int _length;

    public Activity(string date, int length){
        _date = date;
        _length = length;
    }


    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary(){
        return $"{_date} {GetType().Name} ({_length} min):Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }

}