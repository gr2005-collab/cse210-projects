using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.\n");

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# in 1 Hour", "Tech Guru", 3600);
        video1.AddComment(new Comment("Alice", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "I got lost around 45 minutes."));
        video1.AddComment(new Comment("Charlie", "Great explanation!"));

        Video video2 = new Video("Beginner Python Tutorial", "CodeWithMe", 2700);
        video2.AddComment(new Comment("Diana", "Simple and easy to follow."));
        video2.AddComment(new Comment("Eli", "Can you do a Django video next?"));
        video2.AddComment(new Comment("Fiona", "Loved it!"));

        Video video3 = new Video("Web Dev Basics", "Dev Simplified", 1800);
        video3.AddComment(new Comment("George", "Please update for 2025!"));
        video3.AddComment(new Comment("Hannah", "Saved my life in my bootcamp."));
        video3.AddComment(new Comment("Ian", "Clear and concise."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
