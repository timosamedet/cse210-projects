using System;

public class ListingActivity : Activity{

    private int _count ;
    private List<string> _prompts = new List<string>();
    private List<string> _shuffledPrompts = new List<string>();
    private int currentIndex;

    public ListingActivity(int count, List<string> prompts){
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 50;
        _count = count;
        _prompts = prompts;
        Shuffle();
    }

    public void Run(){
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("");
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");

        Console.Write($"You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine($"You listed {GetListFromUser().Count()} items!\n");
        
        DisplayEndingMessage();
    }

    public string GetRandomPrompt(){
        // Random random = new Random();
        // int index = random.Next(0, _prompts.Count());

        // return _prompts[index];
        return GetNext();
    }

    private void Shuffle(){
        Random random = new Random();
        _shuffledPrompts = new List<string>(_prompts);
        int n = _shuffledPrompts.Count();

        for(int i = 0; i < n; i++){
            int j = random.Next(i, n);
            var temp = _shuffledPrompts[i];
            _shuffledPrompts[i] = _shuffledPrompts[j];
            _shuffledPrompts[j] = temp;
        }
        currentIndex = 0;
    }
    
    public string GetNext()
    {
        if (currentIndex >= _shuffledPrompts.Count()){
            Shuffle();
        }
        return _shuffledPrompts[currentIndex++];
    }


    public List<string> GetListFromUser(){
        List<string> responses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); 
        
         Console.WriteLine("\n");
        while(DateTime.Now < endTime){
            Console.Write($"> ");
            string response = Console.ReadLine();
            responses.Add(response);
        }
        return responses;
    }

}