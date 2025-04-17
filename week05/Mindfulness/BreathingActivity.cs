using System;

public class BreathingActitvity : Activity{


    public BreathingActitvity(){
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 50;
    }

    public void Run(){
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine('\n');

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); 

        int breatheIn = 4;
        int breatheOut = 6;

        while(DateTime.Now < endTime){
            Console.Write("Breathe in...");
            ShowCountDown(breatheIn);

            Console.Write("\n");
            Console.Write("Now breathe out...");
            ShowCountDown(breatheOut);
        
            Console.WriteLine("\n");
        }
        DisplayEndingMessage();
    }

    

}