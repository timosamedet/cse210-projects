using System;

class Program
{
    static void Main(string[] args)
    {

        Comment comment1 = new Comment("Michael Frank", "The Lord's hand is a wonderful video.");
        Comment comment2 = new Comment("Joe Parkinson", "Wow! it is amazing what the lord's hand can do.");
        Comment comment3 = new Comment("Ferdinan Bent", "It moves mountain; the lords hand.");
        
        List<Comment> videoComments1 = new List<Comment>{comment1, comment2, comment3};

        Comment comment4 = new Comment("Patrick Cupper", "Deliverance is the work of Christ Jesus.");
        Comment comment5 = new Comment("Akpan Udofia", "A life in christ is a turn around for eternal deliverance.");
        Comment comment6 = new Comment("Etukidem Uyai-Abasi", "They that trust in Him shall be delivered, Hallelujah.");
        
        List<Comment> videoComments2 = new List<Comment>{comment4, comment5, comment6};

        Comment comment7 = new Comment("Sifon Friday", "Wow! the great awaking brought great revival the America.");
        Comment comment8 = new Comment("Archibong Akpan", "It had so much impact in my life and family; the Great Awakening");
        Comment comment9 = new Comment("Toro-Obong Inokon", "God bless Billy Graham for ministry of Evangelism.");

        List<Comment> videoComments3 = new List<Comment>{comment7, comment8, comment9};

        Video video1 = new Video("The Lords Hand", "Jim Simeon", 1500, videoComments1);
        Video video2 = new Video("Deliverance", "Jonny Parker", 1950, videoComments2);
        Video video3 = new Video("The Great Awakening", "Billy Graham", 3500, videoComments3);

        List<Video> videos = new List<Video>{video1, video2, video3};

        foreach(Video video in videos){
            Console.WriteLine($"==================== VIDEO {videos.IndexOf(video) + 1} ====================");

            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()}s");
            Console.WriteLine($"Number Of Comments: {video.GetNumberOfComments()}");
            
            Console.WriteLine("--------------------------------------------------");
            foreach(string text in video.GetComments()){
            Console.WriteLine(text);        
            }
            Console.WriteLine("\n");
        }
    }
}