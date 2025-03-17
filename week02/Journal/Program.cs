using System;

class Program
{
    static void Main(string[] args)
    {
        /**
        I have ensured that entries are not loaded into already loaded entries to avoid duplicate entries
        I have ensured that users are prompted to save changes when they want to quit.
        I have provided the user with the functionality to search the entries. 
        **/

        Console.WriteLine("Welcome to the Journal Program!");
        Journal journal = new Journal();
        journal.DisplayMenu();
    }
}