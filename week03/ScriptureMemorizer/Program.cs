using System;

class Program
{
    static void Main(string[] args)
    {
        /*
           To demonstrate creativity, instead of a single scripture, I have a list of scriptures
           that is presented to user at random each time He runs the application.
        */


        string proverbText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths.";
        string johnText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        string firstTimothyText = "I exhort therefore, that, first of all, supplications, prayers, intercessions, and giving of thanks, be made for all men;";
        string actText = "There was a certain man in Caesarea called Cornelius, a centurion of the band called the Italian band, A devout man, and one that feared God with all his house, which gave much alms to the people, and prayed to God alway. A devout man, and one that feared God with all his house, which gave much alms to the people, and prayed to God alway. He saw in a vision evidently about the ninth hour of the day an angel of God coming in to him, and saying unto him, Cornelius.";
        string galationText = "To redeem them that were under the law, that we might receive the adoption of sons.";
        
        List<Scripture> scriptures = new List<Scripture>{
                                            new Scripture(new Reference("Proverbs", 3,5,6), proverbText),
                                            new Scripture(new Reference("John", 3, 16), johnText),
                                            new Scripture(new Reference("1Timothy", 2, 1), firstTimothyText),
                                            new Scripture(new Reference("John", 10, 1,3), actText),
                                            new Scripture(new Reference("John", 4, 5), galationText)};

        int numberOfWordsToHide = 3;
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.Clear();

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Press enter to continue or type `quit` to finish:");
        string enterText = Console.ReadLine();

        while(!enterText.ToLower().Equals("quit")){
            Console.Clear();
            scripture.HideRandomWords(numberOfWordsToHide);
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type `quit` to finish:");
            enterText = Console.ReadLine();

            if(scripture.IsCompletelyHidden()){
                break;
            }
        }
    }
}