using System;

class FruitMarket
{
    static void Main()
    {
        string strDay = Console.ReadLine();
        double firstQuan = double.Parse(Console.ReadLine());
        string firstPro = Console.ReadLine();
        double secondQuan = double.Parse(Console.ReadLine());
        string secondPro = Console.ReadLine();
        double thirdQuan = double.Parse(Console.ReadLine());
        string thirdPro = Console.ReadLine();
        double allCoef = 1, fruCoef = 1, vegCoef = 1,banCoef = 1;
        switch (strDay)
        {
            case "Friday" :
            {
                allCoef = 0.9;
                break;
            }
            case "Sunday":
            {
                allCoef = 0.95;
                break;
            }
            case "Tuesday":
            {
                fruCoef = 0.8;
                break;
            }
            case "Wednesday":
            {
                vegCoef = 0.9;
                break;
            }
            case "Thursday":
            {
                banCoef = 0.7;
                break;
            }
            default:
                break;
        }
        double dSum = 0;
        dSum = dSum + GetPrice(firstQuan, firstPro, allCoef, fruCoef, vegCoef, banCoef);
        dSum = dSum + GetPrice(secondQuan, secondPro, allCoef, fruCoef, vegCoef, banCoef);
        dSum = dSum + GetPrice(thirdQuan, thirdPro, allCoef, fruCoef, vegCoef, banCoef);
        Console.WriteLine("{0:F2}",dSum);
    }

    private static double GetPrice(double firstQuan, string firstPro, double allCoef, double fruCoef, double vegCoef, double banCoef)
    {
        double result = 0;
        switch (firstPro)
        {
            case "banana":
            {
                result = firstQuan*allCoef*fruCoef*banCoef*1.8d;
                break;
            }
            case "cucumber":
            {
                result = firstQuan * allCoef * vegCoef*2.75d;
                break;
            }
            case "tomato":
            {
                result = firstQuan * allCoef * vegCoef*3.20d;
                break;
            }
            case "orange":
            {
                result = firstQuan * allCoef * fruCoef*1.6d;
                break;
            }
            case "apple":
            {
                result = firstQuan * allCoef * fruCoef*0.86d;
                break;
            }
        }
        return result;
    }
}