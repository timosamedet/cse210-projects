using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Clear();

       Running running = new Running("15 Nov 2021", 30, 54.9);
       Swimming swimming = new Swimming("19 Oct 1998", 120, 80);
       Cycling cycling = new Cycling("29 Feb 2024", 60, 40.3);

       List<Activity> activities = new List<Activity>{running, swimming, cycling};
       
       foreach(Activity activity in activities){
         Console.WriteLine(activity.GetSummary());
       }
    }
}