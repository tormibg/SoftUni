using System;

class NumberAsWords
{
    static void Main()
    {
        while (true)
        {
        string lsNumAsWords = "";
        ushort lusNumber;
        Console.Write("Enter int number in range [1...999]: ");
        if (ushort.TryParse(Console.ReadLine(),out lusNumber));
            {

                if (lusNumber <= 999)
                {

                    switch (lusNumber/100)
                    {
                        case 1:
                            lsNumAsWords = lsNumAsWords + "one hundred ";
                            break;
                        case 2:
                            lsNumAsWords = lsNumAsWords + "two hundred ";
                            break;
                        case 3:
                            lsNumAsWords = lsNumAsWords + "tree hundred ";
                            break;
                        case 4:
                            lsNumAsWords = lsNumAsWords + "tour hundred ";
                            break;
                        case 5:
                            lsNumAsWords = lsNumAsWords + "tive hundred ";
                            break;
                        case 6:
                            lsNumAsWords = lsNumAsWords + "six hundred ";
                            break;
                        case 7:
                            lsNumAsWords = lsNumAsWords + "seven hundred ";
                            break;
                        case 8:
                            lsNumAsWords = lsNumAsWords + "eight hundred ";
                            break;
                        case 9:
                            lsNumAsWords = lsNumAsWords + "nine hundred ";
                            break;
                        default:
                            break;
                    }

                    if (lusNumber%100 != 0 && lusNumber/100 != 0)
                    {
                        if (!String.IsNullOrEmpty(lsNumAsWords))
                        {
                            lsNumAsWords = lsNumAsWords + "and ";
                        }
                    }

                    switch (lusNumber/10%10)
                    {
                        case 1:
                            switch (lusNumber%10)
                            {
                                case 0:
                                    lsNumAsWords = lsNumAsWords + "ten ";
                                    break;
                                case 1:
                                    lsNumAsWords = lsNumAsWords + "eleven ";
                                    break;
                                case 2:
                                    lsNumAsWords = lsNumAsWords + "twelve ";
                                    break;
                                case 3:
                                    lsNumAsWords = lsNumAsWords + "thirteen ";
                                    break;
                                case 4:
                                    lsNumAsWords = lsNumAsWords + "fourteen ";
                                    break;
                                case 5:
                                    lsNumAsWords = lsNumAsWords + "fiveteen ";
                                    break;
                                case 6:
                                    lsNumAsWords = lsNumAsWords + "sixteen ";
                                    break;
                                case 7:
                                    lsNumAsWords = lsNumAsWords + "seventeen ";
                                    break;
                                case 8:
                                    lsNumAsWords = lsNumAsWords + "eighteen ";
                                    break;
                                case 9:
                                    lsNumAsWords = lsNumAsWords + "nineteen ";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            lsNumAsWords = lsNumAsWords + "twenty ";
                            break;
                        case 3:
                            lsNumAsWords = lsNumAsWords + "thirty ";
                            break;
                        case 4:
                            lsNumAsWords = lsNumAsWords + "forty ";
                            break;
                        case 5:
                            lsNumAsWords = lsNumAsWords + "fifty ";
                            break;
                        case 6:
                            lsNumAsWords = lsNumAsWords + "sixty ";
                            break;
                        case 7:
                            lsNumAsWords = lsNumAsWords + "seventy ";
                            break;
                        case 8:
                            lsNumAsWords = lsNumAsWords + "eighty ";
                            break;
                        case 9:
                            lsNumAsWords = lsNumAsWords + "ninety ";
                            break;
                        default:
                            break;
                    }
                    switch (lusNumber%10)
                    {
                        case 0:
                            if (lusNumber == 0)
                            {
                                Console.WriteLine("Zero");
                            }
                            break;
                        case 1:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "one";
                            break;
                        case 2:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "two";
                            break;
                        case 3:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "three";
                            break;
                        case 4:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "four";
                            break;
                        case 5:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "five";
                            break;
                        case 6:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "six";
                            break;
                        case 7:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "seven";
                            break;
                        case 8:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "eight";
                            break;
                        case 9:
                            if (lusNumber/10%10 == 1)
                                break;
                            lsNumAsWords = lsNumAsWords + "nine";
                            break;
                        default:
                            break;
                    }
                    if (lusNumber != 0)
                    {
                        char[] a = lsNumAsWords.ToCharArray();
                        a[0] = char.ToUpper(a[0]);
                        lsNumAsWords = new string(a);
                        Console.WriteLine(lsNumAsWords);
                    }
                }
                else
                {
                    Console.WriteLine(" Out of range! ");
                }
            }
        }
    }
}