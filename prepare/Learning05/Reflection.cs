// Reflection.cs
// The reflection activity class. Shows the user a prompt about a time they
// were strong or did something meaningful, then asks follow-up questions
// to get them thinking deeper about it. Pretty powerful stuff honestly.

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Reflection : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    // These track which prompts/questions we've already used this session
    // (stretch challenge -- don't repeat until all have been used)
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public Reflection() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength " +
        "and resilience. This will help you recognize the power you have and how you can use it " +
        "in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a fear."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Start with copies so we can track what's been used
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    // Picks a random prompt, but won't repeat until all have been shown
    private string GetRandomPrompt()
    {
        // Refill the unused list if we've gone through all of them
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string chosen = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return chosen;
    }

    // Same thing but for the follow-up questions
    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);
        string chosen = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return chosen;
    }

    protected override void RunActivity()
    {
        // Show the opening prompt and give them a moment to think
        Console.WriteLine($"\nConsider the following prompt:\n");
        Console.WriteLine($"  --- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they come up.");
        Console.WriteLine("Don't let yourself off the hook -- really think about them!\n");
        ShowSpinner(5);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Keep asking questions until the time is up
        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            Console.WriteLine($"\n> {GetRandomQuestion()}");
            ShowSpinner(8); // give them a good chunk of time to think
        }
    }
}