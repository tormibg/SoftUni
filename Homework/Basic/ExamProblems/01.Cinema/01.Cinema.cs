using System;

class Cinema
{
    static void Main()
    {
        const decimal iPremiera = 12.00m;
        const decimal iNormal = 7.50m;
        const decimal iDiscount = 5.00m;
        string sType = Console.ReadLine();
        int iRows = int.Parse(Console.ReadLine());
        int iColumns = int.Parse(Console.ReadLine());
        decimal tmpX = 0;
        switch (sType)
        {
            case "Premiere":
            {
                tmpX = iPremiera;
            }
                break;
            case "Normal":
                {
                    tmpX = iNormal;
                }
                break;
            case "Discount":
                {
                    tmpX = iDiscount;
                }
                break;
        }
        decimal finalResult = iRows*iColumns*tmpX;
        Console.WriteLine("{0:f} leva",finalResult);
    }
}