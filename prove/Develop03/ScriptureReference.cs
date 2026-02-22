// ScriptureReference.cs
// This class handles storing the book, chapter, and verse(or verses) of a scripture.
// I made two constructors because some scriptures are a single verse and
// others span a range the assignment literally requires it so here we go.

public class ScriptureReference
{
    // Private Fields
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse; // only used if it's a verse range

    // Constructor for a single verse (for example, "John 3:16") 
    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse; // start and end are the same for a single verse
    }

    // Constructor for a verse range (for example, "Proverbs 3:5-6")
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    //Returns the reference formatted nicely as a string 
    // If it's a range, shows "Book Chapter:Start-End", otherwise "Book Chapter:Verse"
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}