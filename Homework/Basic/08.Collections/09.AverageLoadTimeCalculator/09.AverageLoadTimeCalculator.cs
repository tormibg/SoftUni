using System;
using System.Collections.Generic;

class AverageLoadTimeCalculator
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter line, for end pres ENTER :");
            Dictionary<string,double> dUrlTime = new Dictionary<string, double>();
            Dictionary<string,uint> dUrlCount = new Dictionary<string, uint>();
            string sTmpStr = Console.ReadLine();
            while (sTmpStr != string.Empty)
            {
                string[] aTmpStr = sTmpStr.Split(' ');
                string sURL = aTmpStr[2];
                double dTime = double.Parse(aTmpStr[3]);
                if (!dUrlTime.ContainsKey(sURL))
                {
                    dUrlTime[sURL] = dTime;
                    dUrlCount[sURL] = 1;
                }
                else
                {
                    dUrlCount[sURL]++;
                    dUrlTime[sURL] = dUrlTime[sURL] + dTime;
                }
                Console.WriteLine("Enter line, for end pres ENTER :");
                sTmpStr = Console.ReadLine();
            }
            foreach (string sUrl in dUrlTime.Keys)
            {
                Console.WriteLine("{0} -> {1}",sUrl,dUrlTime[sUrl]/dUrlCount[sUrl]);
            }
        }
    }
}