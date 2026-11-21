using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Make Jollof Rice", "Blessing Cooks", 420);
        video1.AddComment(new Comment("Maya", "This was easy to follow."));
        video1.AddComment(new Comment("Daniel", "My family enjoyed these."));
        video1.AddComment(new Comment("Ruth", "I will try this tomorrow."));
        video1.AddComment(new Comment("Gabby", "Omo! this jollof Rice bang!"));

        Video video2 = new Video("A Walk Through Luanda", "Travel with Paulo", 615);
        video2.AddComment(new Comment("Ana", "The views are beautiful."));
        video2.AddComment(new Comment("Peter", "I would love to visit."));
        video2.AddComment(new Comment("Grace", "Thank you for sharing this."));

        Video video3 = new Video("Study Tips for Beginners", "Learning Corner", 530);
        video3.AddComment(new Comment("Sam", "These tips are helpful."));
        video3.AddComment(new Comment("Joy", "I will use this for my studies."));
        video3.AddComment(new Comment("Chris", "Please make another video."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"{comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}