using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            string inputNum = Console.ReadLine();
           try
            {
                int number;
                number = int.Parse(inputNum);
                if (number < 0)
                {
                    throw new FormatException("Invalid number");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
           catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
           finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
