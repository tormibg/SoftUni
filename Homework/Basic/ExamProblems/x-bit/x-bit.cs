using System;
using System.Collections.Generic;

class xbit
{
    private static void Main()
    {
        int sum = 0;
        List<int> numbers = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }
        for (int i = 0; i < (8 - 2); i++)
        {
            int firstNumber = numbers[i];
            int maskOnes = Convert.ToInt32("111", 2);
            int firstMask = Convert.ToInt32("101", 2);
            for (int j = 0; j < (32 - 2); j++)
            {

                int firstCheck = (firstNumber >> j) & maskOnes;
                if ((firstCheck ^ firstMask) == 0)
                {
                    int secondNumber = numbers[i + 1];
                    int thirdNumber = numbers[i + 2];
                    int secondCheck = (secondNumber >> j) & maskOnes;
                    int thirdCheck = (thirdNumber >> j) & maskOnes;
                    int secondMask = Convert.ToInt32("010", 2);
                    if ((secondCheck ^ secondMask) == 0 &&
                        (thirdCheck ^ firstMask) == 0)
                    {
                        sum++;
                    }
                }
            }
        }
        Console.WriteLine(sum);
    }
}