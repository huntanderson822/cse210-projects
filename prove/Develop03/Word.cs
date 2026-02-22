// Word.cs
// This class represents a single word in the scripture.
// It keeps track of whether the word is hidden or not,
// so I don't have to do a bunch of string manipulation in other places.
// Encapsulation baby keeping the "hidden" logic right here where it belongs.

public class Word
{
    //Private Fields
    private string _text;
    private bool _isHidden;

    // Constructor 
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // starts visible, gets hidden over time
    }

    // Hides the word (replaces it with underscores when displayed)
    public void Hide()
    {
        _isHidden = true;
    }

    // Returns true if the word is already hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the display version of the word 
    // If hidden, shows underscores matching the word length.
    // This makes it look like a fill-in-the-blank, which is pretty cool
    //
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}