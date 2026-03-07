// Activity.cs
// This is the base class for all our mindfulness activities.
// Basically holds all the stuff that every activity has in common
// so we don't have to rewrite it three times like a dummy.

using System;
using System.Threading;

public abstract class Activity
{
    // Private member variables -- encapsulation baby
    private string _name;
    private string _description;
    private int _duration;

    // Constructor to set up the activity with a name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Getters so the subclasses can actually access this stuff
    protected string Name => _name;
    protected string Description => _description;
    protected int Duration => _duration;

    // Shows the opening screen for any activity -- same for all of them
    public void OpeningDisplay()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = PromptDuration();
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(5);
        Console.Clear();
    }

    // Shows the closing screen -- good job, you did the thing
    public void ClosingDisplay()
    {
        Console.WriteLine("\nGood job!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou just completed the \"{_name}\" activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Asks the user how long they want the activity to be
    public int PromptDuration()
    {
        Console.Write("How long, in seconds, do you want your session to last? ");
        int seconds;
        // Keep bugging them until they give us a real number
        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds <= 0)
        {
            Console.Write("Please enter a valid positive number of seconds: ");
        }
        return seconds;
    }

    // The spinner animation -- looks cool and gives the user something to stare at
    public void ShowSpinner(int seconds)
    {
        string[] spinnerFrames = { "|", "/", "-", "\\" };
        int totalIterations = seconds * 10; // 10 ticks per second feels smooth
        for (int i = 0; i < totalIterations; i++)
        {
            Console.Write($"\r{spinnerFrames[i % spinnerFrames.Length]} ");
            Thread.Sleep(100);
        }
        Console.Write("\r  \r"); // clear the spinner when done
    }

    // Countdown that shows the number ticking down -- satisfying to watch ngl
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}  "); // extra spaces to overwrite longer numbers
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r"); // clear it when done
    }

    // This is the method each subclass MUST implement -- that's the whole point of abstract
    protected abstract void RunActivity();

    // The public method that kicks off the whole activity flow
    public void Run()
    {
        OpeningDisplay();
        RunActivity();
        ClosingDisplay();
    }
}