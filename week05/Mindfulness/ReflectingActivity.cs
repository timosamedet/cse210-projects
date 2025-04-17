using System;

public class ReflectingActivity : Activity{ 
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private List<string> _shuffledQuestions = new List<string>();
    private List<string> _shuffledPrompts = new List<string>();
    private int currentQuestionIndex = 0;
    private int currentPromptIndex = 0;
    private string _questionType = "QUESTIONS";
    private string _promptType = "PROMPT";


    public ReflectingActivity(List<string> prompt, List<string> questions)
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 50;
        _prompts = prompt;
        _questions = questions;
        Shuffle(_questionType);
        Shuffle(_promptType);
    }

    public void Run(){
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("");
        DisplayPrompt();
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); 
        
        while(DateTime.Now < endTime){
            DisplayQuestions();
        }
        Console.WriteLine("");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt(){
        return GetNext(_promptType);
    }

    public string GetRandomQuestion(){
        return GetNext(_questionType);
    }

    private void Shuffle(string listType)
    {
        Random random = new Random();
        if(listType == _questionType){
            _shuffledQuestions = new List<string>(_questions);
            int n = _shuffledQuestions.Count();

            for(int i = 0; i < n; i++){
                int j = random.Next(i, n);
                var temp = _shuffledQuestions[i];
                _shuffledQuestions[i] = _shuffledQuestions[j];
                _shuffledQuestions[j] = temp;
            }

            currentQuestionIndex = 0;
            
        } 
        else if(listType == _promptType){
            _shuffledPrompts = new List<string>(_prompts);
            int n = _shuffledPrompts.Count();

            for(int i = 0; i < n; i++){
                int j = random.Next(i, n);
                var temp = _shuffledPrompts[i];
                _shuffledPrompts[i] = _shuffledPrompts[j];
                _shuffledPrompts[j] = temp;
            }

            currentPromptIndex = 0;
        }
    }

    public string GetNext(string listType)
    {
        if(listType == _questionType){
            if (currentQuestionIndex >= _shuffledQuestions.Count()){
                Shuffle(listType);
            }
            return _shuffledQuestions[currentQuestionIndex++];
        }
        else if(listType == _promptType){
            if (currentPromptIndex >= _shuffledPrompts.Count()){
                Shuffle(listType);
            }
            return _shuffledPrompts[currentPromptIndex++];
        }
        else{
            return null;
        }
    }

    public void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt: \n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine($"When you have something in mind, press enter to continue");

        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write($"You may begin in: ");

        ShowCountDown(5);
    }

    public void DisplayQuestions(){
        Console.Write($"> {GetRandomQuestion()} ");
        ShowSpinner(10);
        Console.Write("\n");
    }
}