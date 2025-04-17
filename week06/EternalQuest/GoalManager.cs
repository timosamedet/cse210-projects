using System;
using System.Data;

public class GoalManager{

    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private Dictionary<int, Goal> _map = new Dictionary<int, Goal>();

    public GoalManager(){

    }


    public void Start(){
        List<string> menu = new List<string> {"Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"};
        int choice;

        Console.WriteLine($"You have {_score} points.\n");
        Console.WriteLine("Menu Options:");

        foreach(string item in menu){
            Console.WriteLine($"  {menu.IndexOf(item) + 1}. {item}");
        }

        Console.Write("Select a choice from the menu: ");
        choice = int.Parse(Console.ReadLine());

        if(choice == 1){
            CreateGoal();
        }
        else if(choice == 2){
            DisplayGoalDetails();
        }
        else if(choice == 3){
            SaveGoals(_goals);
        }
        else if(choice == 4){
           _goals.AddRange(LoadGoals());
        }
        else if(choice == 5){
            RecordEvent();
        }else if(choice == 6){
            return;
        }
        Start();
    }

    public string DisplayPlayerInfo(){
        return " ";
    }

    public List<string> ListGoalNames(){
        List<string> goalNames = new List<string>();
        _map.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("The Goals are: ");
        foreach(Goal goal in _goals){
            goalNames.Add(goal.GetName());
            if(goal.IsComplete()){
                Console.WriteLine($"{_goals.IndexOf(goal) + 1}. {goal.GetName()} ✔️");
            }
            else{
                Console.WriteLine($"{_goals.IndexOf(goal) + 1}. {goal.GetName()}");
            }

            _map.Add(_goals.IndexOf(goal) + 1, goal);
    
        }
        return goalNames;
    }

    public List<string> ListGoalDetails(){
        string goalDetails;
        List<string> detailsList = new List<string>();

        foreach(Goal goal in _goals){
            string mark = goal.IsComplete() ? "[X]" : "[ ]";
            goalDetails = $"{_goals.IndexOf(goal) + 1}. {mark} {goal.GetDetailsString()}";
            detailsList.Add(goalDetails);
        }

        return detailsList;
    }

    public void DisplayGoalDetails(){
        Console.WriteLine("The Goals are: ");
        List<string> details = ListGoalDetails();

        foreach(string detail in details){
            Console.WriteLine(detail);
        }
        Console.WriteLine(" ");
    }

    public void CreateGoal(){
        List<string> goalTypes = new List<string> {"Simple Goal", "Eternal Goal", "Checklist Goal"};
        int choice;

        Console.WriteLine("The types of Goals are:");

        foreach(string item in goalTypes){
            Console.WriteLine($"  {goalTypes.IndexOf(item) + 1}. {item}");
        }

        Console.Write("Which type of goal would you like to create? ");
        choice = int.Parse(Console.ReadLine());

        if(choice == 1){
            createGoal(1);
        }
        else if(choice == 2){
            createGoal(2);
        }
        else if(choice == 3){
            createGoal(3);
        }
        return;
    }

    private void createGoal(int goalTypeIndex){
        Console.Write("What is the name of your goal? ");
        string goalName =  Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription =  Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points =  int.Parse(Console.ReadLine());

        if(goalTypeIndex == 1){
            SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, points);
            _goals.Add(simpleGoal);

            Console.WriteLine("");
        }
        else if(goalTypeIndex == 2){
            EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, points);
            _goals.Add(eternalGoal);

            Console.WriteLine("");
        }
        else if(goalTypeIndex == 3){
            Console.Write("How many times does this goal need to be completed for a bonus? ");
            int target =  int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus =  int.Parse(Console.ReadLine());

            ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, points, target, bonus);
            _goals.Add(checklistGoal);

            Console.WriteLine("");
        }
        else{
            return;
        }
    } 


    public void RecordEvent(){
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine());
        Goal goal = _map[index];

        if(goal.IsComplete()){
            Console.WriteLine("You've already completed this goal! create another goal to record event.\n");
            return;
        }

        goal.RecordEvent();
        _score+= goal.GetPoints();
        
        Console.WriteLine($"Congratulations! you have earned {goal.GetPoints()} points!");
        Console.WriteLine($"You now have {_score} points.\n");
    }

    public void SaveGoals(List<Goal> goals){
        Console.Write("What is the file name for the goal file? ");
        string fileName = Console.ReadLine();

        using(StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach(Goal goal in goals){
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public List<Goal> LoadGoals(){
        List<Goal> goals = new List<Goal>();

        Console.Write("What is the file name for the goal file? ");

        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            if(Array.IndexOf(lines, line) == 0){
                _score = int.Parse(line);
                continue;
            }
            string[] parts = line.Split(":");
            string className = parts[0];
            string[] classAttributes = parts[1].Split(",");

            string name = classAttributes[0];
            string description = classAttributes[1];
            int points = int.Parse(classAttributes[2]);

            if(className == typeof(SimpleGoal).Name){
                bool isComplete = bool.Parse(classAttributes[3]);

                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                simpleGoal.SetIsComplete(isComplete);
                goals.Add(simpleGoal);
            }
            else if(className == typeof(EternalGoal).Name){
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                goals.Add(eternalGoal);
            }
            else if(className == typeof(ChecklistGoal).Name){
                    int bonus = int.Parse(classAttributes[3]);
                    int target = int.Parse(classAttributes[4]);
                    int amountCompleted = int.Parse(classAttributes[5]);

                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    checklistGoal.SetAmountCompleted(amountCompleted);
                    goals.Add(checklistGoal);
            }
    
        }
        return goals;
    }
}