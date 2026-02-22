// ScriptureLibrary.cs
// EXCEEDING REQUIREMENTS: This class holds a collection of scriptures
// so the program doesn't just repeat the same verse every time.
// On startup, it picks one at random from the library.
// I think I could also load these from a file but hardcoding them here keeps it simple for now.

public class ScriptureLibrary
{
    // Private Fields 
    private List<Scripture> _scriptures;
    private Random _random;

    // Constructor: loads all the scriptures into the library
    public ScriptureLibrary()
    {
        _random = new Random();
        _scriptures = new List<Scripture>();
        LoadScriptures();
    }

    // Adds all the scriptures we want in the library 
    // Super easy to add more
    private void LoadScriptures()
    {
        _scriptures.Add(new Scripture(
            new ScriptureReference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
        ));

        _scriptures.Add(new Scripture(
            new ScriptureReference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"
        ));

        _scriptures.Add(new Scripture(
            new ScriptureReference("Joshua", 1, 9),
            "Have not I commanded thee Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest"
        ));

        _scriptures.Add(new Scripture(
            new ScriptureReference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me"
        ));

        _scriptures.Add(new Scripture(
            new ScriptureReference("2 Nephi", 2, 25),
            "Adam fell that men might be and men are that they might have joy"
        ));

        _scriptures.Add(new Scripture(
            new ScriptureReference("Alma", 37, 6),
            "Now ye may suppose that this is foolishness in me but behold I say unto you that by small and simple things are great things brought to pass"
        ));
    }

    // Returns a randomly selected scripture from the library
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}