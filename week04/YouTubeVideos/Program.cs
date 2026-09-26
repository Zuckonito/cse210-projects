using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();


        Video video1 = new Video("C# Abstraction Basics", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Really helped with my assignment."));
        video1.AddComment(new Comment("Charlie", "Can you make a video on interfaces next?"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 PC Gaming Builds", "Tech Master", 900);
        video2.AddComment(new Comment("Dave", "Build #3 is amazing value."));
        video2.AddComment(new Comment("Eve", "Prices are a bit high right now."));
        video2.AddComment(new Comment("Frank", "Awesome video as always!"));
        videos.Add(video2);


        Video video3 = new Video("How to Bake Sourdough Bread", "Chef Maria", 1200);
        video3.AddComment(new Comment("Grace", "My bread turned out great!"));
        video3.AddComment(new Comment("Heidi", "What flour brand do you recommend?"));
        video3.AddComment(new Comment("Ivan", "Clear step-by-step guide, thanks."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("\nComments:");
            

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetCommenterName()}: \"{comment.GetText()}\"");
            }
            Console.WriteLine();
        }
    }
}