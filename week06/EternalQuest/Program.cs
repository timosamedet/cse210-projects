using System;

class Program
{
    /** 
        EXCEEDED REQUIREMENT:
        I have exceeded requirement by ensuring that completed goals does record new event.The user have to create a new goal to record event
        Also when listing Goal names for recording of event, I have added a check icon (emoji) to let the user know and avoid completed events.

    **/
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}