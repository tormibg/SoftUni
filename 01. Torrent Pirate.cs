using System;

class Program
{
    static void Main()
    {
        int movieSize = 1500;
        int speed = 2;

        double downMega = double.Parse(Console.ReadLine());
        double priceCinema = double.Parse(Console.ReadLine());
        double moneyPerHour = double.Parse(Console.ReadLine());

        double downTime = downMega / speed / 60 / 60;
   //     Console.WriteLine(downTime);
        double priceForDown = downTime * moneyPerHour;
  //      Console.WriteLine(priceForDown);
        double numMovDown = downMega / movieSize;
   //     Console.WriteLine(numMovDown);
        double cinPrice = numMovDown * priceCinema;
  //      Console.WriteLine(cinPrice);
        if (priceForDown > cinPrice)
        {
            Console.WriteLine("cinema -> {0:f}lv",cinPrice);
        }
        else
        {
            Console.WriteLine("mall -> {0:f}lv", priceForDown);
        }
    }
}
