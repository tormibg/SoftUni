using System;

class StudentCables
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int iSumCablesSM = 0;
        int iCount = 0;
        for (int i = 0; i < num; i++)
        {
            int iCoef = 1;
            int iNum = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure == "meters")
            {
                iCoef = 100;
            }
            int cableSM = iNum*iCoef;

            if (cableSM >= 20)
            {
                iSumCablesSM += cableSM;
                iCount++;
            }
        }
        if (iCount > 0)
        {
            int joinCab = 0;
            int smRG = 0;
            joinCab = (iCount - 1)*3;
            int cableLeght = iSumCablesSM - joinCab;
            int numCables = 0;
            if (cableLeght >= 504)
            {
                do
                {
                    cableLeght = cableLeght - 504;
                    numCables++;
                } while (cableLeght >= 504);
                Console.WriteLine(numCables);
                Console.WriteLine(cableLeght);
            }
            else
            {
                Console.WriteLine(0);
                Console.WriteLine(cableLeght);
            }
        }
    }
}