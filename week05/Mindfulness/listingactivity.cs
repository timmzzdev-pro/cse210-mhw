using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
              "Listing",
              "This activity will help you reflect on the good things in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        DisplayEndingMessage();
    }
}