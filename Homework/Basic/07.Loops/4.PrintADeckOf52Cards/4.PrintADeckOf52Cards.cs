using System;

class PrintADeckOf52Cards
{
    static void Main()
    {
        for (int i = 2; i < 15; i++)
        {
            string sNum;
            switch (i)
            {
                case 11:
                    {
                        sNum = "J";
                        break;
                    }
                case 12:
                    {
                        sNum = "Q";
                        break;
                    }
                case 13:
                    {
                        sNum = "K";
                        break;
                    }
                case 14:
                    {
                        sNum = "A";
                        break;
                    }
                default:
                    {
                        sNum = i.ToString();
                        break;
                    }

            }
            for (int k = 0; k < 4; k++)
            {
                char? cCard = null;
                switch (k)
                {
                    case 0:
                    {
                        cCard = '\u2663';
                        break;
                    }
                    case 1:
                    {
                        cCard = '\u2666';
                        break;
                    }
                    case 2:
                    {
                        cCard = '\u2665';
                        break;
                    }
                    case 3:
                    {
                        cCard = '\u2660';
                        break;
                    }
                }
                Console.Write("{0,3}",sNum+cCard);
            }
            Console.WriteLine();
        }
    }
}