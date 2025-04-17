using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name , string description, int points) : base(name, description, points) {
        _isComplete = false;
    }


    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_shortName},{_description},{_points},{_isComplete}";
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public void SetIsComplete(bool isComplete){
        _isComplete = isComplete;
    }





}