using System;

/*
EXCEEDING REQUIREMENTS:
I added an option that tracks how many activities
the user has completed during the session.
*/

class Program
{
    static void Main(string[] args)
    {
        int completedActivities = 0;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Activities Completed: {completedActivities}");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}