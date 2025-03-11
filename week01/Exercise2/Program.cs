using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        string letterSign;

        Console.Write("Eneter your grade percentage: ");
        int gradePerent = int.Parse(Console.ReadLine());

        if(gradePerent >= 90){
            letter = "A";
        }
        else if(gradePerent >= 80){
            letter = "B";
        }
        else if(gradePerent >= 70){ 
            letter = "C";
        }
        else if(gradePerent >= 60){
            letter = "D";
        }
        else{
            letter = "F";
        }

        int remainder = gradePerent % 10;
        if(remainder >= 7){
            letterSign = "+";
            if(letter == "A" || letter == "F"){
                letterSign = "";
            }
        }
        else if(remainder < 3 ){
            letterSign = "-";
            if(letter == "F"){
                letterSign = "";
           }
        }
        else{
            letterSign = "";
        }
        Console.WriteLine($"Your grade is: {letter}{letterSign}");

        if(gradePerent >= 70){
            Console.WriteLine("Congratulations you passed!");
        }
        else{
            Console.WriteLine("Unfortunately you did not pass, we encourage you put in more effort in your studies.");
        }

    }
}