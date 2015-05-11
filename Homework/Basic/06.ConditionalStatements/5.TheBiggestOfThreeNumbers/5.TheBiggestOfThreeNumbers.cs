using System;

class TheBiggestOfThreeNumbers
{
    private static void Main()
    {
        while (true)
        {
            double a = 0, b = 0, c = 0, ldMaxNumber = 0;
            Console.Write("Enter first real number : ");
            var tmpA = Console.ReadLine();
            Console.Write("Enter second real number : ");
            var tmpB = Console.ReadLine();
            Console.Write("Enter third real number : ");
            var tmpC = Console.ReadLine();
            if (double.TryParse(tmpA, out a) && double.TryParse(tmpB, out b) && double.TryParse(tmpC, out c))
            {
                ldMaxNumber = Math.Max(Math.Max(a, b), c);

                Console.WriteLine("The max number is : {0}", ldMaxNumber);
            }
            else
            {
                Console.WriteLine("Only numbers");
            }
        }
    }
}