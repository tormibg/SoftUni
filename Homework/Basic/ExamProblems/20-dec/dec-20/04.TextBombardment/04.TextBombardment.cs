using System;

class TextBombardment
{
    static void Main()
    {
        string inputText = Console.ReadLine();
        int tableWidth = int.Parse(Console.ReadLine());
        string columnNumbersString = Console.ReadLine();
        string[] columnNumbersArrayStrings = columnNumbersString.Split();
        int[] columnNumbersIntArray = new int[columnNumbersArrayStrings.Length];
        for (int i = 0; i < columnNumbersArrayStrings.Length; i++)
        {
            columnNumbersIntArray[i] = int.Parse(columnNumbersArrayStrings[i]);
        }
        string outputText = inputText;
        for (int i = 0; i < columnNumbersIntArray.Length; i++)
        {
            bool flag = false;
            int currentBomb = columnNumbersIntArray[i];
            for (int j = currentBomb; j < outputText.Length; j += tableWidth)
            {
                if (flag && outputText[j] == ' ')
                {
                    break;
                }
                if (outputText[j] != ' ')
                {
                    flag = true;
                }
                outputText = outputText.Substring(0, j) + " " + outputText.Substring(j + 1);
            }
        }
        Console.WriteLine(outputText);
    }
}