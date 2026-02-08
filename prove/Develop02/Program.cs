using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string choice = "";
        
        while (choice != "5")
        {
            // Display the menu for the journal program
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine($"Current entries: {journal._entries.Count}");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                // Write a new journal entry
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                
                // Get the current date
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                
                // Create and add new entry
                Entry newEntry = new Entry(dateText, prompt, response);
                journal.AddEntry(newEntry);
                
                Console.WriteLine("Entry added successfully!");
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                // Display all entries
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Save to file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                // Load from file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                // Quit
                Console.WriteLine("Thank you for using the Journal Program!");
            }
            else
            {
                // Invalid choice
                Console.WriteLine("Invalid choice. Please select a number from 1 to 5.");
                Console.WriteLine();
            }
        }
    }
}

// Represents a single journal entry with a prompt, response, and date
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // Constructor
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Display the entry to the console
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    // Convert entry to a string format for file saving (using ~|~ as separator)
    public string ToFileFormat()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    // Create an Entry object from a file format string
    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split("~|~");
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null;
    }
}

// Manages a collection of journal entries and handles file operations
public class Journal
{
    public List<Entry> _entries;

    // Constructor
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
        Console.WriteLine();
    }

    // Load the journal from a file (replaces the current entries)
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} does not exist.");
            Console.WriteLine();
            return;
        }

        _entries.Clear(); // Clear the current entries
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileFormat(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {filename}");
        Console.WriteLine();
    }
}

// Manages a list of journal prompts and provides random selection
public class PromptGenerator
{
    public List<string> _prompts;

    // Initializes the list of prompts
    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What am I grateful for today?"
        };
    }

    // Returns a random prompt from the list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}