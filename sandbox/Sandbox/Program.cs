using System;
using System.Configuration.Assemblies;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        List<double> prices = new List<double>();

        AddPrices(prices);
        PrintSummary(prices);
    }    
    static void AddPrices(List<double> prices)
    {
        Console.WriteLine("Enter a price (or type done): ");
        string userInput = Console.ReadLine();
        if (userInput == "done")
        {
            
        }
        else
        {
            int price = int.Parse(userInput);
            prices.Add(price);
        }
    }

    static double GetToal(List<double> prices)
    {
        
    }
    static double GetAverage(List<double> prices)
    {
        // TODO: return average (handle empty list)
        return 0;
    }

    static double GetHighest(List<double> prices)
    {
        // TODO: return highest price (handle empty list)
        return 0;
    }

    static void PrintSummary(List<double> prices)
    {
        // TODO: use the functions above and print results
    }
}