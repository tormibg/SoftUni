using System;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        long h = int.Parse(Console.ReadLine());
        long d = int.Parse(Console.ReadLine());
        long p = int.Parse(Console.ReadLine());
        decimal hWork = d*0.90m;
        decimal hd = Math.Floor(hWork*12*p/100.0m);
        if (hd - h >= 0)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(hd-h);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine(hd - h);
        }
    }
}