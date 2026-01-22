using System;

class Program
{
    static void Main(string[] args)
    {
        // Unit conversion from farenheight to celceius
        Console.WriteLine("Enter a tempreture in Fahrenheit: ");
        float fTemp = float.Parse(Console.ReadLine());

        double cTemp = (fTemp - 32) * (5.0 / 9.0);

        Console.WriteLine($"The equivalent of {fTemp} in celcius tempreture is {cTemp} ");
    }
}