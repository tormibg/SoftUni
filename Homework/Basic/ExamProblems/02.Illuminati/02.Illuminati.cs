using System;

class Illuminati
{
    static void Main()
    {
        //A = 65, E = 69, I = 73, O = 79, U = 85
        string strIllum = Console.ReadLine();
        int iLeeterCount = 0, iLetterSum = 0;
        for (int i = 0; i < strIllum.Length; i++)
        {
            switch (strIllum[i])
            {
                case 'A':
                case 'a':
                {
                    iLeeterCount++;
                    iLetterSum += 65;
                }
                    break;

                case 'E':
                case 'e':
                    {
                        iLeeterCount++;
                        iLetterSum += 69;
                    }
                    break;

                case 'I':
                case 'i':
                    {
                        iLeeterCount++;
                        iLetterSum += 73;
                    }
                    break;

                case 'O':
                case 'o':
                    {
                        iLeeterCount++;
                        iLetterSum += 79;
                    }
                    break;

                case 'U':
                case 'u':
                    {
                        iLeeterCount++;
                        iLetterSum += 85;
                    }
                    break;

                default:
                    break;
            }
        }
        Console.WriteLine(iLeeterCount);
        Console.WriteLine(iLetterSum);
    }
}