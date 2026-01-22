using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Get the list set up
        List<int> numbers = new List<int>();

        // Prompt the user for numbers
        int userNumber = -1;
        // Keep asking until they enter 0
        while (userNumber != 0)
        {
            Console.WriteLine("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            // Add the number to the list (unless they end it)
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        // Get the sum, average, and max
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}