using System;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("-------------------- Math Assignment --------------------");
       MathAssignment mathAssignment = new MathAssignment("7.9", "8-19", "Samuel Timothy", "Algorithm & Data Structure");
       Console.WriteLine(mathAssignment.GetSummary());
       Console.WriteLine(mathAssignment.GetHomeworkList());
       Console.WriteLine('\n');

       Console.WriteLine("-------------------- Writing Assignment --------------------");
       WritingAssignment writingAssignment = new WritingAssignment("Living Your Dream", "Udofia Etukidem", "Self Motivation");
       Console.WriteLine(writingAssignment.GetSummary());
       Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}