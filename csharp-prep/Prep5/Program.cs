using System;

class Program
{
    static void Main(string[] args)
    {
        //Displat the welcome
        DisplayWelcome();

        // Call functions
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        int birthYear;
        PromptUserBirthYear(out birthYear);

        // Display the results
        DisplayResult(userName, squaredNumber, birthYear);

    }
    // Function definitions
    // Display the message
    static void DisplayWelcome()
    {
        Console.WriteLine("Heyyy welcome to my code/program!!");
    }
    // Prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    // Prompt the user for a number
    static int PromptUserNumber()
    {
        Console.Write("Enter a number: ");
        string numberString = Console.ReadLine();
        int number = int.Parse(numberString);
        return number;
    }
    // Prompt the user for their birth year
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("What year were you born? ");
        string birthYearString = Console.ReadLine();
        birthYear = int.Parse(birthYearString);
    }
    // Calculate the square of a number
    static int SquareNumber(int number)
    {
        int squared = number * number;
        return squared;
    }
    // Display the results
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"Hello {name}!");
        Console.WriteLine($"The square of your number is {squaredNumber}.");
        Console.WriteLine($"You were born in {birthYear}.");
    }
}