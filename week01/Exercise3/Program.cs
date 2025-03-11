using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random numberGenerator = new Random();
        int magicNumber = numberGenerator.Next(1, 101);

        int guessNumber = -1;
        int guessCount = 0;

        do{
            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());
            guessCount++;


            if(magicNumber > guessNumber){
                Console.WriteLine("Higher");
            }
            else if(magicNumber < guessNumber){
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"You made a total of {guessCount} guess(es)");
                Console.WriteLine("");

                Console.Write("Do you want to continue the game? ");
                string continueGame = Console.ReadLine();

                if(continueGame.ToLower().Equals("yes")){
                    guessNumber++;
                    guessCount = 0;

                    magicNumber = numberGenerator.Next(1, 101);
                }
                else{
                    Console.WriteLine("Game Over!");
                }
            }
            
        }
        while(magicNumber != guessNumber);
    }
}