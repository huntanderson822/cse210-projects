// Listing.cs
// The listing activity class. Gives the user a prompt and has them list
// as many things as they can think of. At the end it shows them how many
// they got. Kind of like a gratitude list but more structured.

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Listing : Activity
{
    private List<string> _prompts;
    private Random _random;

    // Stretch challenge: track unused prompts so we don't repeat ourselves
    private List<string> _unusedPrompts;

    public Listing() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having " +
        "you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are things in your life you are grateful for?",
            "What are skills you have worked hard to develop?"
        };

        _unusedPrompts = new List<string>(_prompts);
    }

    // Returns a random prompt, and won't repeat until all have been used
    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string chosen = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return chosen;
    }

    // The user types items until the time runs out, then we count them
    private int CollectItems()
    {
        List<string> items = new List<string>();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Keep taking input until the duration is hit
        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            // Don't count empty lines, that's cheating
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        return items.Count;
    }

    protected override void RunActivity()
    {
        string prompt = GetRandomPrompt();

        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"  --- {prompt} ---\n");
        Console.WriteLine("You may begin in: ");
        ShowCountdown(5); // give them a few seconds to think before typing

        Console.WriteLine("\nStart listing! Press Enter after each item.\n");

        int count = CollectItems();

        Console.WriteLine($"\nYou listed {count} item{(count == 1 ? "" : "s")}! Nice work!");
    }
}