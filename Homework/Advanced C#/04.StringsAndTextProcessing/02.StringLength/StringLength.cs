using System;

class StringLength
{
    static void Main()
    {
        string inputStr = Console.ReadLine();
        if (inputStr.Length >= 20)
        {
            Console.WriteLine(inputStr.Substring(0, 20));
        }
        else
        {
            Console.WriteLine(inputStr.PadRight(20, '*'));
        }
        
    }
}