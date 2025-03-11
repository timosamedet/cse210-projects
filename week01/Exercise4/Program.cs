using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        double number;
        List<double> numbers = new List<double>();
        double total = 0;
        double average;
        double maxNumber;
        double smallestPositiveNumber = new double();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do{
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if(number != 0){
                numbers.Add(number);
                
                if(smallestPositiveNumber == 0.0){
                    smallestPositiveNumber = number;
                }

                if(number > 0 && number < smallestPositiveNumber){
                    smallestPositiveNumber = number;
                }
            }
        }
        while(number != 0);

        foreach(int num in numbers){
            total += num;
        }

        maxNumber = numbers.Max();
        average = total / numbers.Count;

    
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        if(smallestPositiveNumber != 0.0){
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");

        foreach(double num in numbers){
            Console.WriteLine(num);
        }
    }
}