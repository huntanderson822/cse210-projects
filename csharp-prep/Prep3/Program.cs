using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the random numbers
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        // Initialize the guess variable
        

        // Get the game started
        Console.WriteLine("Welcome to the number guessing game!");
        Console.WriteLine("---------------------------------------");
        //Console.WriteLine("What is the magic number?");
        //int mqgicNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("I am thinking of a magic number between 1 and 101!");
        
        
        Console.WriteLine("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());


        while (guess != number)
        {
            if (guess < number)
            {
                Console.WriteLine("Too low! Try again: ");
                guess = int.Parse(Console.ReadLine());
            }
            else if (guess > number)
            {
                Console.WriteLine("Too high! Try again: ");
                guess = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Congrats! You guessed the number!");
            }
        }
    }
}