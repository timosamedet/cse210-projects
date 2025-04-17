using System;

class Program
{
    /** 
        EXCEEDED REQUIREMENT:
        I have exceeded requirement by ensuring that no random prompts/questions are selected until they have all been used at least once in that session. 

    **/
    
    public static List<string> menu = new List<string> {"Start breathing activity", "Start reflecting activity", "Start listing activity", "Quit"};
    public static int choice;

    public static List<string> reflecting_prompts = new List<string>{
                                                    "Think of a time when you stood up for someone else.",
                                                    "Think of a time when you did something really difficult.",
                                                    "Think of a time when you helped someone in need.",
                                                    "Think of a time when you did something truly selfless."
                                                    };
    public static List<string> questions = new List<string>{
                                                        "Why was this experience meaningful to you?",
                                                        "Have you ever done anything like this before?",
                                                        "How did you get started?",
                                                        "How did you feel when it was complete?",
                                                        "What made this time different than other times when you were not as successful?",
                                                        "What is your favorite thing about this experience?",
                                                        "What could you learn from this experience that applies to other situations?",
                                                        "What did you learn about yourself through this experience?",
                                                        "How can you keep this experience in mind in the future?"
                                                        };
    public static List<string> listing_prompts = new List<string>{
                                                                    "Who are people that you appreciate?",
                                                                    "What are personal strengths of yours?",
                                                                    "Who are people that you have helped this week?",
                                                                    "When have you felt the Holy Ghost this month?",
                                                                    "Who are some of your personal heroes?"
                                                                    };


    static void Main(string[] args)
    {
        DisplayMenu();
    }

    public static void DisplayMenu(){
        Console.Clear();
        Console.WriteLine("Menu Options:");

        foreach(string item in menu){
            Console.WriteLine($"  {menu.IndexOf(item) + 1}. {item}");
        }

        Console.Write("Select a choice from the menu: ");
        choice = int.Parse(Console.ReadLine());

        if(choice == 1){
            BreathingActitvity breathing = new BreathingActitvity();
            breathing.Run();
        }
        else if(choice == 2){
            ReflectingActivity reflecting = new ReflectingActivity(reflecting_prompts, questions);
            reflecting.Run();
        }
        else if(choice == 3){
            ListingActivity listing = new ListingActivity(10, listing_prompts);
            listing.Run();
        }
        else if(choice == 4){
            return;
        }
       
       DisplayMenu();
    }
}