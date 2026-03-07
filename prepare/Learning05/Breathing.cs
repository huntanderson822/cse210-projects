// Breathing.cs
// The breathing activity class. Walks the user through breathing in and out
// slowly until the timer runs out. Super simple but honestly kind of relaxing.

using System;
using System.Diagnostics;

public class Breathing : Activity
{
    // How many seconds each breath in/out should take
    private int _breathInSeconds;
    private int _breathOutSeconds;

    // Constructor default to 4 seconds each which is pretty standard
    public Breathing() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. " +
        "Clear your mind and focus on your breathing.")
    {
        _breathInSeconds = 4;
        _breathOutSeconds = 6; // breathe out a bit longer, that's the good stuff
    }

    // The actual breathing loop -- alternates between breathe in and breathe out
    protected override void RunActivity()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool breathingIn = true;

        // Keep going until we've hit the duration the user wanted
        while (stopwatch.Elapsed.TotalSeconds < Duration)
        {
            if (breathingIn)
            {
                Console.Write("\nBreathe in...");
                ShowBreathAnimation(_breathInSeconds, breathingIn: true);
            }
            else
            {
                Console.Write("\nBreathe out...");
                ShowBreathAnimation(_breathOutSeconds, breathingIn: false);
            }

            breathingIn = !breathingIn; // flip for next iteration
        }
    }

    // This is the stretch challenge animation! The text grows and shrinks
    // to kind of mimic the feeling of your lungs expanding and contracting.
    // Thought it was a cool touch -- way better than just a countdown
    private void ShowBreathAnimation(int seconds, bool breathingIn)
    {
        // We'll use dots to represent the "size" of the breath
        string[] sizes = { ".", "..", "...", "....", ".....", "......" };

        int totalSteps = sizes.Length;
        int msPerStep = (seconds * 1000) / totalSteps;

        if (breathingIn)
        {
            // Grow the animation (inhale = expanding)
            for (int i = 0; i < totalSteps; i++)
            {
                Console.Write($"\r  {sizes[i]}      ");
                System.Threading.Thread.Sleep(msPerStep);
            }
        }
        else
        {
            // Shrink the animation (exhale = contracting)
            for (int i = totalSteps - 1; i >= 0; i--)
            {
                Console.Write($"\r  {sizes[i]}      ");
                System.Threading.Thread.Sleep(msPerStep);
            }
        }

        Console.Write("\r             \r"); // clean up the line
    }
}