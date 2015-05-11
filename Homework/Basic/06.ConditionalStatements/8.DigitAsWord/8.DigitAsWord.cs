using System;

class DigitAsWord
{
    private static void Main()
    {
        while (true)
        {
            string lsResult, lsEntNumber;
            sbyte lsbNumber = 0;
            Console.Write("Enter number between 0 and 9 : ");
            lsEntNumber = Console.ReadLine();
            if (sbyte.TryParse(lsEntNumber, out lsbNumber))
            {
                switch (lsbNumber)
                {
                    case 0:
                        lsResult = "zero";
                        break;
                    case 1:
                        lsResult = "one";
                        break;
                    case 2:
                        lsResult = "two";
                        break;
                    case 3:
                        lsResult = "three";
                        break;
                    case 4:
                        lsResult = "four";
                        break;
                    case 5:
                        lsResult = "five";
                        break;
                    case 6:
                        lsResult = "six";
                        break;
                    case 7:
                        lsResult = "seven";
                        break;
                    case 8:
                        lsResult = "eight";
                        break;
                    case 9:
                        lsResult = "nine";
                        break;
                    default:
                        lsResult = "not a digit";
                        break;
                }
            }
            else
            {
                lsResult = "not a digit";
            }
            Console.WriteLine("{0} -> {1}", lsEntNumber, lsResult);
        }
    }
}