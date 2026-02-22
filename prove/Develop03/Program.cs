using System;

// Program.cs
// Scripture Memorizer - Develop 03
//
// Basically this program shows you a scripture and then slowly hides the words
// each time you hit enter until you can't see any of them. Kinda forces you to
// actually remember it instead of just staring at the screen. Also picks a
// random scripture each time so it's not the same verse every run.

// ---------------------THE STUFF I DID TO GET ABOVE 93% ----------------------
//
// 1: STRETCH CHALLENGE: The HideRandomWords() method in Scripture.cs only picks
//    from words that aren't already hidden. Had to filter the list first to make
//    that work but it wasn't too bad once I figured out.
//
// 2: SCRIPTURE LIBRARY: Made a whole ScriptureLibrary class that stores a bunch
//    of verses and randomly picks one at the start. Way more interesting than
//    just hardcoding John 3:16 every time like the basic version would.
//
// 3: ENCAPSULATION: Tried to keep everything private that didn't need to be
//    public. Took me a second to figure out what actually needed to be exposed
//    but I think it's pretty clean now. Four separate class files total.
// Using the library to grab a random scripture — way more fun than one verse
ScriptureLibrary library = new ScriptureLibrary();
Scripture scripture = library.GetRandomScripture();

// Main game loop — keeps going until all words are hidden or user types quit
while (true)
{
    // Clear the screen and show the current state of the scripture
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine();

    // If every word is hidden, we're done — great job memorizing!
    if (scripture.IsCompletelyHidden())
    {
        Console.WriteLine("You did it! All words are hidden. Great memorizing!");
        break;
    }

    // Prompt the user to either keep going or quit
    Console.Write("Press Enter to continue or type 'quit' to exit: ");
    string input = Console.ReadLine();

    // Check if they want to quit
    if (input != null && input.Trim().ToLower() == "quit")
    {
        Console.WriteLine("Goodbye! Keep practicing!");
        break;
    }

    // Hide a few more random words for the stretch challenge, only from the visible ones!
    scripture.HideRandomWords(3);
}