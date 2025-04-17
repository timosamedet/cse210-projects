using System;

public class Activity{

    protected string _name;
    protected string _description;
    protected int _duration; 

    protected List<string> _spinnerCharList = new List<string>{"|","/","-", "\\", "|", "/", "-", "\\"};
    private int spinnerDuration = 5;
    public void DisplayStartingMessage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}. \n");
        Console.WriteLine($"{_description} \n");
        Console.Write("How long, in seconds would you like for your sessions? ");

        _duration = int.Parse(Console.ReadLine());

    }

    public void DisplayEndingMessage(){
        Console.WriteLine("Well done!!");
        ShowSpinner(spinnerDuration);
        Console.WriteLine("");
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(spinnerDuration);
    }

    public void ShowSpinner(int seconds){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while(DateTime.Now < endTime){
            string spinnerChar = _spinnerCharList[i];

            Console.Write(spinnerChar);
            Thread.Sleep(200);
            Console.Write("\b \b");

            i++;
            if(_spinnerCharList.Count() <= i){
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds){
        for(int i = seconds; i > 0 ; i--){
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
        }
    }

}