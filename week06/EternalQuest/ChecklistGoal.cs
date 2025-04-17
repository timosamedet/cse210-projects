using System;

public class ChecklistGoal : Goal
{

    private int _amountCompleted;
    private int _target;
    private int  _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points){
        _target = target;
        _bonus = bonus;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }

    public override bool IsComplete()
    {
        return _target == _amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if(IsComplete()){
            _points += _bonus;
        }

    }

    public override string GetDetailsString(){
        return $"{_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";;
    }

    public void SetAmountCompleted(int amountCompleted){
        _amountCompleted = amountCompleted;
    }
}