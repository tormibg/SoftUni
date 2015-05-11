using System;

class ProgrammerDNA
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char chInput = char.Parse(Console.ReadLine());
        int chIndex = 0;
        char[] aChars = {'A', 'B', 'C', 'D', 'E', 'F', 'G'};
        for (int i = 0; i < 7; i++)
        {
            if (aChars[i] == chInput)
            {
                chIndex = i;
                break;
            }
        }
        int center = 4;
        int leftSide = 2;
        int rightSide = center;
        int iCount = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (iCount == 0 && col == center - 1)
                {
                    Console.Write("{0}",aChars[chIndex]);
                    chIndex = GetNewIndex(chIndex);
                }
                else if (iCount > 0 && col >= leftSide && col <= rightSide)
                {
                    Console.Write("{0}", aChars[chIndex]);
                    chIndex = GetNewIndex(chIndex);
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();

            if (iCount > 0 && iCount <= center - 2)
            {
                leftSide--;
                rightSide++;
            }
            else if (iCount > 0 && iCount >= center - 1)
            {
                leftSide++;
                rightSide--;
            }
            iCount++;
            if (iCount == 7)
            {
                iCount = 0;
                leftSide = 2;
                rightSide = center;
            }
        }
    }

    private static int GetNewIndex(int chIndex)
    {
        chIndex++;
        if (chIndex == 7)
        {
            chIndex = 0;
        }
        return chIndex;
    }
}