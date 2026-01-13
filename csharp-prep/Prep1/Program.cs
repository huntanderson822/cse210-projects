using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the User for their first name
        Console.WriteLine("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the user for their last name
        Console.WriteLine("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the name in a way that sounds like James Bond
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}. ");
    }
}