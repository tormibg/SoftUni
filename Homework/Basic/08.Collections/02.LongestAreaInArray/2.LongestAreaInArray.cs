using System;

class LongestAreaInArray
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.Write("How many strings : ");
            uint uiNumber = uint.Parse(Console.ReadLine());
            string[] aStrings = new string[uiNumber];
            uint uiCount = 0, uiMaxCount = 0;
            string sMaxString = "";
            for (int i = 0; i < uiNumber; i++)
            {
                Console.Write("Enter {0}-st string : ", i + 1);
                aStrings[i] = Console.ReadLine();
            }

            //Spored uslovieto ne bi triabvalo da sortirame, a da se gleda posledovatelnost taka kakto se vavejdat !!!
            //Array.Sort(aStrings);

            string sTmpStr = aStrings[0];
            for (int i = 0; i < uiNumber; i++)
            {
                if (sTmpStr == aStrings[i])
                {
                    uiCount++;
                    if (uiCount > uiMaxCount)
                    {
                        uiMaxCount = uiCount;
                        sMaxString = aStrings[i];
                    }
                }
                else
                {
                    uiCount = 1;
                }
                sTmpStr = aStrings[i];
            }
            Console.WriteLine(uiMaxCount);
            for (int i = 0; i < uiMaxCount; i++)
            {
                Console.WriteLine(sMaxString);
            }
        }
    }
}