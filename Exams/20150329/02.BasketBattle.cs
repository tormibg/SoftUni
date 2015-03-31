sing System;

class BasketBattle
{
    private static void Main()
    {
        int MAX = 500;
        string nameOdd = Console.ReadLine();
        string nameEven = "";
        if (nameOdd == "Simeon")
        {
            nameEven = "Nakov";
        }
        else
        {
            nameEven = "Simeon";
        }
        int numRounds = int.Parse(Console.ReadLine());
        int[] aRonds = new int[numRounds];
        int sumOdd = 0, sumEven = 0;
        bool isWinner = false;
        int gameRounds = 1;
        for (int i = 1; gameRounds <= numRounds; i++)
        {
            int scoreRound = int.Parse(Console.ReadLine());
            string scoreResult = Console.ReadLine();
            if (scoreResult == "success")
            {
                if (i % 2 != 0)
                {
                    if ((sumOdd + scoreRound) == MAX)
                    {
                        Console.WriteLine(nameOdd);
                        Console.WriteLine(gameRounds);
                        Console.WriteLine(sumEven);
                        isWinner = true;
                        gameRounds = numRounds;
                        break;
                    }
                    else if ((sumOdd + scoreRound) < MAX)
                    {
                        sumOdd += scoreRound;
                    }
                }
                else
                {
                    if ((sumEven + scoreRound) == MAX)
                    {
                        Console.WriteLine(nameEven);
                        Console.WriteLine(gameRounds);
                        Console.WriteLine(sumOdd);
                        isWinner = true;
                        gameRounds = numRounds;
                        break;
                    }
                    else if ((sumEven + scoreRound) < MAX)
                    {
                        sumEven += scoreRound;
                    }
                }
            }
            if (i % 2 == 0)
            {
                gameRounds++;
                string testStr = nameEven;
                nameEven = nameOdd;
                nameOdd = testStr;
                int testSum = sumEven;
                sumEven = sumOdd;
                sumOdd = testSum;
            }
        }
        if (!isWinner)
        {
            if (sumEven == sumOdd)
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(sumOdd);
            }
            else
            {
                if (sumEven > sumOdd)
                {
                    Console.WriteLine(nameEven);
                    Console.WriteLine(Math.Abs(sumEven-sumOdd));
                }
                else
                {
                    Console.WriteLine(nameOdd);
                    Console.WriteLine(Math.Abs(sumEven - sumOdd));
                }
            }
        }
    }
}
