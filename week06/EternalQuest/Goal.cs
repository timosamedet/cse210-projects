using System;
using System.Runtime;

public abstract class Goal{

    protected string _shortName;
    protected string _description ;
    protected int _points;

    
    public Goal(string name, string description, int points){
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString(){
        return $"{_shortName} ({_description})";
    }

    public string GetName(){
        return _shortName;
    }

    public int GetPoints(){
        return _points;
    }
}