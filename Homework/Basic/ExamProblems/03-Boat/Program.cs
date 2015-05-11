using System;

//(n-1)/2
class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i <= number / 2; i++)
        {
            string LeftPart = new string('.', number - (1 + 2* i));
            string sailPart = new string('*', 1 + 2 * i);
            string rightPart = new string('.', number);
            Console.WriteLine(LeftPart + sailPart + rightPart);
        }
        for (int i = number / 2; i > 0 ; i--)
        {
            string leftpart = new string('.', number - (2 * i -1));
            string sailPart = new string('*', 2 * i -1);
            string rightPart = new string('.', number);
            Console.WriteLine(leftpart + sailPart + rightPart);
        }
        for (int i = 0; i < (number - 1) / 2; i++)
        {
            string sea = new string('.',i);
            string boat = new string('*', 2 * (number - i));
            Console.WriteLine("{0}{1}{0}",sea,boat);
        }
    }
}