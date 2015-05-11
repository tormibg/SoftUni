using System;

class ComparingFloats
{
    static void Main()
    {
        double eps = 0.000001d;
        Console.Write("Enter first number : ");
        double ldFirstNumber = double.Parse(Console.ReadLine());
        Console.Write("Enter second number : ");
        double ldSecNumber = double.Parse(Console.ReadLine());
        bool lbIfEqual = Math.Abs(ldFirstNumber - ldSecNumber) < eps;
        Console.WriteLine("Equal (with precision eps=0.000001) : {0}",lbIfEqual);
    }
}
