using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== Eternal Quest =====");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("\nSelect goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            score += earned;

            Console.WriteLine($"You earned {earned} points!");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);

            foreach (Goal g in goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Saved!");
    }

    static void LoadGoals()
    {
        goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");

        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string data = parts[1];

            string[] values = data.Split(',');

            if (type == "SimpleGoal")
            {
                var g = new SimpleGoal(values[0], values[1], int.Parse(values[2]));
                goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                var g = new EternalGoal(values[0], values[1], int.Parse(values[2]));
                goals.Add(g);
            }
            else if (type == "ChecklistGoal")
            {
                var g = new ChecklistGoal(
                    values[0],
                    values[1],
                    int.Parse(values[2]),
                    int.Parse(values[4]),
                    int.Parse(values[5])
                );

                goals.Add(g);
            }
        }

        Console.WriteLine("Loaded!");
    }
}