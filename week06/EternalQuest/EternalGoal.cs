using System;

public class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points) :  base(name, description, points){

    }


    public override string GetStringRepresentation()
    {
        //return $"{typeof(EternalGoal).Name}:{_shortName},{_description},{_points}";
        return $"{GetType().Name}:{_shortName},{_description},{_points}";

    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void RecordEvent(){
        return;

    }

}