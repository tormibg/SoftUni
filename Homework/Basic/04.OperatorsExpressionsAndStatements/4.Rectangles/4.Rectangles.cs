using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double ldWidth, ldHeight;
            Console.Write("Enter width  : ");
            ldWidth = double.Parse(Console.ReadLine());
            Console.Write("Enter height : ");
            ldHeight = double.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Perimeter -> {0} and area -> {1}", 2 * (ldWidth + ldHeight), ldWidth * ldHeight);
        }
    }
}