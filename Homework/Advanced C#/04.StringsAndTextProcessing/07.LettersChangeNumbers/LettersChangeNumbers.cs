using System;
using System.Linq;
using System.Threading;

class LettersChangeNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToArray();
        decimal sum = 0;

        foreach (string str in input)
        {
            char firstLetter = str[0];
            char lastLetter = str[str.Length - 1];
            string numberString = "";
            for (int i = 1; i < str.Length - 1; i++)
            {
                numberString += str[i];
            }

            int number = int.Parse(numberString);
            decimal result;

            if ((int)firstLetter >= 65 && (int)firstLetter <= 90)
            {
                result = (decimal)number / ((int)firstLetter - 64);
            }
            else
            {
                result = (decimal)number * ((int)firstLetter - 96);
            }

            if ((int)lastLetter >= 65 && (int)lastLetter <= 90)
            {
                result -= ((int)lastLetter - 64);
            }
            else
            {
                result += ((int)lastLetter - 96);
            }

            sum += result;
        }

        Console.WriteLine("{0:f2}", sum);
    }
}