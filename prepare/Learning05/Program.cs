// Program.cs
// Main entry point for the Mindfulness App.
// Handles the menu, creates activities, and logs how many times
// each activity has been done (stretch challenge #1 -- activity log).
// The log saves to a file so it persists between runs too.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static int _menuChoice;

    // Stretch challenge: track how many times each activity has been run
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>
    {
        { "Breathing", 0 },
        { "Reflection", 0 },
        { "Listing", 0 }
    };

    private static string _logFilePath = "activity_log.txt";

    static void Main(string[] args)
    {
        // Load the saved log if it exists from a previous run
        LoadLog();

        bool keepGoing = true;

        while (keepGoing)
        {
            DisplayMenu();
            _menuChoice = GetMenuChoice();

            if (_menuChoice == 4)
            {
                // Show them their stats before quitting, pretty motivating ngl
                Console.Clear();
                Console.WriteLine("Here's how many times you've done each activity:\n");
                foreach (var entry in _activityLog)
                {
                    Console.WriteLine($"  {entry.Key}: {entry.Value} time{(entry.Value == 1 ? "" : "s")}");
                }
                Console.WriteLine("\nGood work! Keep it up. Press Enter to exit.");
                Console.ReadLine();
                keepGoing = false;
            }
            else
            {
                Activity activity = CreateActivity(_menuChoice);

                if (activity != null)
                {
                    activity.Run();

                    // Log which activity was just completed
                    string activityName = GetActivityName(_menuChoice);
                    if (_activityLog.ContainsKey(activityName))
                    {
                        _activityLog[activityName]++;
                        SaveLog(); // save after every completed activity
                    }
                }
            }

            if (keepGoing)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    // Prints the main menu to the screen
    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness App ===\n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start Breathing Activity");
        Console.WriteLine("  2. Start Reflection Activity");
        Console.WriteLine("  3. Start Listing Activity");
        Console.WriteLine("  4. Quit");
        Console.WriteLine();
    }

    // Gets a valid menu selection from the user -- keeps asking until they behave
    private static int GetMenuChoice()
    {
        Console.Write("Select a choice from the menu: ");
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.Write("Please enter a number between 1 and 4: ");
        }

        return choice;
    }

    // Factory method -- takes the choice and hands back the right activity object
    private static Activity CreateActivity(int choice)
    {
        switch (choice)
        {
            case 1: return new Breathing();
            case 2: return new Reflection();
            case 3: return new Listing();
            default:
                Console.WriteLine("Not sure how you got here, but that's not valid.");
                return null;
        }
    }

    // Helper to get the name string for logging purposes
    private static string GetActivityName(int choice)
    {
        switch (choice)
        {
            case 1: return "Breathing";
            case 2: return "Reflection";
            case 3: return "Listing";
            default: return "Unknown";
        }
    }

    // Saves the activity log to a text file so it persists between sessions
    private static void SaveLog()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath))
            {
                foreach (var entry in _activityLog)
                {
                    writer.WriteLine($"{entry.Key}:{entry.Value}");
                }
            }
        }
        catch (Exception e)
        {
            // Not the end of the world if saving fails, just warn them
            Console.WriteLine($"Couldn't save log: {e.Message}");
        }
    }

    // Loads the activity log from the file if it exists
    private static void LoadLog()
    {
        if (!File.Exists(_logFilePath)) return;

        try
        {
            string[] lines = File.ReadAllLines(_logFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && _activityLog.ContainsKey(parts[0]))
                {
                    if (int.TryParse(parts[1], out int count))
                    {
                        _activityLog[parts[0]] = count;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Couldn't load log: {e.Message}");
        }
    }
}