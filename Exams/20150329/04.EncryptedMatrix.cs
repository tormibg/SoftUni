using System;

class EncryptedMatrix
{
    private static void Main()
    {
        string inputStr = Console.ReadLine();
        string numStr = "";
        for (int i = 0; i < inputStr.Length; i++)
        {
            //Console.WriteLine((((int)inputStr[i])%10).ToString());
            numStr += (((int) inputStr[i])%10).ToString();
        }
        string strMatrix = "";
        for (int i = 0; i < numStr.Length; i++)
        {
            int temNum = int.Parse(numStr[i].ToString());
            if (temNum%2 != 0 && temNum != '0') //Odd
            {
                int leftNum = 0;
                int rightNum = 0;
                if ((i - 1) < 0)
                {
                    leftNum = 0;
                }
                else
                {
                    leftNum = int.Parse(numStr[i - 1].ToString());
                }
                if ((i + 1) == numStr.Length)
                {
                    rightNum = 0;
                }
                else
                {
                    rightNum = int.Parse(numStr[i + 1].ToString());
                }
                temNum = temNum + leftNum + rightNum;
            }
            else //Even
            {
                temNum = temNum*temNum;

            }
            strMatrix += temNum.ToString();
        }
        //  Console.WriteLine(numStr);
        //  Console.WriteLine(strMatrix);
        int nMatrix = strMatrix.Length;
        string slash = Console.ReadLine();
        if (slash == @"/")
        {
            for (int i = 0; i < nMatrix; i++)
            {
                for (int j = 0; j < nMatrix; j++)
                {
                    if (j == nMatrix-1-i && i == 0+i)
                    {
                        Console.Write("{0} ",strMatrix[nMatrix-1-i]);
                    }
                    else
                    {
                        Console.Write("0 ");   
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i < nMatrix; i++)
            {
                for (int j = 0; j < nMatrix; j++)
                {
                    if (j == 0+i && i == 0 + i)
                    {
                        Console.Write("{0} ",strMatrix[i]);
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
         
        }
    }
}
