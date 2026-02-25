using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        // Test base Assignment
        Assignment assignment1 = new Assignment("Sam Ben", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        //MathAssignment
        MathAssignment mathAssignment1 = new MathAssignment("Robert Preswitch", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());
        Console.WriteLine();

        // Writing Assignment
        WritingAssignment writingAssignment1 = new WritingAssignment("Jane Doe", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());

    }
}