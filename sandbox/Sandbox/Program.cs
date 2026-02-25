using System;
using System.Configuration.Assemblies;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main()
    {
        List<int> ages = new List<int> {12, 17, 18, 21, 15, 30};

        foreach (int age in ages)
        {
            if (CanVote(age))
            {
                Console.WriteLine(age + " can vote.");
            }
            else
            {
                Console.WriteLine(age + " cannont vote.");
            }
        }
    }
    public static bool CanVote(int age)
    {
        return age >= 18;
    }
}