using System;

namespace EnterNumbers
{
    class EnterNumbers
    {
        const int Min = 1;
        const int Max = 100;
        const int MaxEntNum = 11;

        static void Main()
        {
            int startNum = EnterStartEnd("Enter START number", Min, Max-12);
            int endNum = EnterStartEnd("Enter END number", startNum+11, Max-1);
            ReadNumber(startNum, endNum);
        }

        private static void ReadNumber(int startNum, int endNum)
        {
            string inputStr;
            int num, count = 1, recount = 10;
            while (true)
            {
                Console.Write("Enter number between [{0}..{1}] : {2} - ", startNum, endNum, count);
                inputStr = Console.ReadLine();
                try
                {
                    num = int.Parse(inputStr);
                    if (num > startNum && num < endNum)
                    {
                        count++;
                        recount--;
                        startNum = num;
                       if ((startNum+recount) >= endNum)
                        {
                            Console.WriteLine("No more space for numbers !");
                            Console.WriteLine("Good bye");
                            break;
                        }
                        if (count == MaxEntNum)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Good bye");
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();   
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number! Only numbers between [{0}..{1}]", startNum, endNum);
                }
            }
            
        }

        private static int EnterStartEnd(string p, int minNum, int maxNum)
        {
            string inputStr;
            int num;
            while (true)
            {
                Console.Write("{0} [{1}..{2}] : ",p,minNum, maxNum);
                inputStr = Console.ReadLine();
                try
                {
                    num = int.Parse(inputStr);
                    if (num >= minNum && num <= maxNum)
                    {
                        return num;
                    }
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number! Only numbers between [{0}..{1}]",minNum, maxNum);
                }
            }
        }
    }
}
