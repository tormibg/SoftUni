using System;

class CheckForAPlayCard
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter integer number or char : ");
            var lvEntNum = Console.ReadLine();
            switch (lvEntNum)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                case "A":
                    Console.WriteLine("Is {0} a valid card sign ? : {1}", lvEntNum, "yes");
                    break;
                default:
                    Console.WriteLine("Is \"{0}\" a valid card sign ? : {1}", lvEntNum, "no");
                    break;
            }
        }
    }
}