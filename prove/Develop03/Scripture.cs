// Scripture.cs
// This class ties together the reference and the list of words.
// It handles displaying the scripture and hiding random words each round.
// The stretch challenge (only hiding words that aren't already hidden) is
// implemented here, so I figured I'd go for the full points while I'm at it.

public class Scripture
{
    // Private fields to store the scripture reference, the list of Word objects, 
    // and a random number generator for hiding words
    private ScriptureReference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor
    // Takes a reference object and the full scripture text as a single string,
    // then splits it into individual Word objects. Pretty clean honestly.
    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _random = new Random();

        // Split the text into words and wrap each one in a Word object
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Hides a few random words that are NOT already hidden 
    // This is the stretch challenge version which only picks from visible words.
    // The number of words hidden per round is 3, but it can be tweaked.
    public void HideRandomWords(int wordsToHide = 3)
    {
        // Get a list of words that are still visible
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If there's nothing left to hide, just return early
        if (visibleWords.Count == 0) return;

        // Don't try to hide more words than are actually visible
        int hideCount = Math.Min(wordsToHide, visibleWords.Count);

        for (int i = 0; i < hideCount; i++)
        {
            // Pick a random visible word and hide it
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // remove it so we don't pick it again this round
        }
    }

    // Returns true when every single word is hidden
    // Used in Program.cs to know when to stop the loop
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    //Builds the full display string for the scripture
    // Hidden words show as underscores, visible ones show normally
    public string GetDisplayText()
    {
        string wordsDisplay = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordsDisplay}";
    }
}