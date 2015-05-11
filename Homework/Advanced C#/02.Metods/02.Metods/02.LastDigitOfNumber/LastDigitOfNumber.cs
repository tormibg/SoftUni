using System;

class LastDigitOfNumber
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetLastDigitAsWord(number));
        }
    }

    private static string GetLastDigitAsWord(int number)
    {
        string[] words = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        int indx = number % 10;

        return words[indx];
    }
}