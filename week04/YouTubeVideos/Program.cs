using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Learn C# in 10 Minutes",
            "Code Academy",
            600);

        video1.AddComment(
            new Comment("John",
            "Very helpful tutorial!"));

        video1.AddComment(
            new Comment("Sarah",
            "Thanks for explaining clearly."));

        video1.AddComment(
            new Comment("Mike",
            "Great video!"));

        Video video2 = new Video(
            "Top 10 Programming Tips",
            "Tech World",
            850);

        video2.AddComment(
            new Comment("Alice",
            "Excellent tips."));

        video2.AddComment(
            new Comment("David",
            "I learned a lot."));

        video2.AddComment(
            new Comment("Grace",
            "Please make more videos."));

        Video video3 = new Video(
            "Object-Oriented Programming",
            "Programming Hub",
            1200);

        video3.AddComment(
            new Comment("Daniel",
            "This helped me understand OOP."));

        video3.AddComment(
            new Comment("Esther",
            "Well explained."));

        video3.AddComment(
            new Comment("Peter",
            "Thanks!"));

        Video video4 = new Video(
            "Data Structures Explained",
            "CS Tutorials",
            950);

        video4.AddComment(
            new Comment("James",
            "Very informative."));

        video4.AddComment(
            new Comment("Mary",
            "I finally understand linked lists."));

        video4.AddComment(
            new Comment("Samuel",
            "Awesome content."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}