using System;
using System.Linq;
using System.Text.RegularExpressions;


internal class CommandInterpreter
{
    private static void Main()
    {
      //  string input = "";
        string input = Console.ReadLine();
        //string[] arrStr = new string[] {"1", "2", "5", "8", "7", "3", "10", "6", "4", "9"};
        string[] arrStr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        input = Console.ReadLine();
        while (input != "end")
        {
            if (input.Substring(0, input.IndexOf(" ")) == "reverse")
            {
                arrStr = ReversArray(arrStr,input);
            }
            else if (input.Substring(0, input.IndexOf(" ")) == "sort")
            {
                arrStr = SortArray(arrStr, input);
            }
            else if (input.Substring(0, input.IndexOf(" ")) == "rollRight")
            {
                arrStr = RollShift(arrStr, input, "right");
            }
            else if (input.Substring(0, input.IndexOf(" ")) == "rollLeft")
            {
                arrStr = RollShift(arrStr, input, "left");
            }
            input = Console.ReadLine();
        }
        PrintArr(arrStr);
    }

    private static string[] RollShift(string[] array, string input, string right)
    {
    //    int shift = int.Parse(input.Substring(9, input.IndexOf(" ", 11)));
        Regex rxRegex = new Regex(@"\w+\s(-?[0-9]*)");
        MatchCollection matches = rxRegex.Matches(input);
        int shift = int.Parse(matches[0].Groups[1].Value);

        shift = shift%array.Count();

        if (shift > 0)
        {
            for (int i = 0; i < shift; i++)
            {
                if (right == "right")
                {
                    array = ShitfRight(array);
                }
                else if (right == "left")
                {
                    array = ShitfLeft(array);
                }   
            }

            //bool tmp = true;
            //PrintArr(tmp, array);
            return array;
        }

        else
        {
            //bool tmp = false;
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp, array);
            return array;
        }
    }

    private static string[] ShitfLeft(string[] array)
    {
        string[] demo = new string[array.Length];
        for (int i = 0; i < array.Length - 1; i++)
        {
            demo[i] = array[i + 1];
        }
        demo[demo.Length - 1] = array[0];

        return demo;
    }

    private static string[] ShitfRight(string[] array)
    {
        string[] demo = new string[array.Length];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            demo[(i + 1) % demo.Length] = array[i];
        }
        return demo;
    }


    private static string[] SortArray(string[] arrStr, string input)
    {
        
        Regex rxRegex = new Regex(@"\w+\s([0-9]*)");
        MatchCollection matches = rxRegex.Matches(input);
        int index = 0, count = 0;
        if (!string.IsNullOrEmpty(matches[1].Groups[1].Value))
        {
            index = int.Parse(matches[1].Groups[1].Value.ToString());
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp,arrStr);
            return arrStr;
            
        }
        if (!string.IsNullOrEmpty(matches[2].Groups[1].Value))
        {
            count = int.Parse(matches[2].Groups[1].Value.ToString());
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp,arrStr);
            return arrStr;
        }
        //int index = int.Parse(input.Substring(10, input.IndexOf(" ", 11) - 10));
        //int count = int.Parse(input.Substring(input.IndexOf(" ", 11) + 6, input.Length - input.LastIndexOf(" ")));
        if (!(index < 0 || index > arrStr.Length - 1) && (!(count <= 0 || count > arrStr.Length - 1)))
        {
            string[] tmpStr = new string[count];
            for (int i = index; i < index + count; i++)
            {
                tmpStr[i - index] = arrStr[i];
            }
            Array.Sort(tmpStr);
            string[] returnStr = new string[arrStr.Length];
            for (int i = 0; i < arrStr.Count(); i++)
            {
                if (!(i >= index && (i < (index + count))))
                {
                    returnStr[i] = arrStr[i];
                }
                else
                {
                    returnStr[i] = tmpStr[i - index];
                }
            }
            return returnStr;
            //bool tmp = true;
            //PrintArr(tmp,returnStr);
        }
        else
        {
            //bool tmp = false;
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp,arrStr);
            return arrStr;
        }
    }

    private static string[] ReversArray(string[] arrStr, string input)
    {
        Regex rxRegex = new Regex(@"\w+\s([0-9]*)");
        MatchCollection matches = rxRegex.Matches(input);
        int index = 0, count = 0;
        if (!string.IsNullOrEmpty(matches[1].Groups[1].Value))
        {
            index = int.Parse(matches[1].Groups[1].Value.ToString());
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp,arrStr);
            return arrStr;

        }
        if (!string.IsNullOrEmpty(matches[2].Groups[1].Value))
        {
            count = int.Parse(matches[2].Groups[1].Value.ToString());
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp,arrStr);
            return arrStr;
        }
        //int index = int.Parse(input.Substring(13, input.IndexOf(" ", 14) - 13));
        //int count = int.Parse(input.Substring(input.IndexOf(" ", 14) + 6, input.Length - input.LastIndexOf(" ")));
        if (!(index < 0 || index > arrStr.Length - 1) && (!(count <= 0 || count > arrStr.Length - 1)))
        {
            string[] tmpStr = new string[count];
            for (int i = index; i < index + count; i++)
            {
                tmpStr[i - index] = arrStr[i];
            }
            Array.Reverse(tmpStr);
            string[] returnStr = new string[arrStr.Length];
            for (int i = 0; i < arrStr.Count(); i++)
            {
                if (!(i >= index && (i < (index + count))))
                {
                    returnStr[i] = arrStr[i];
                }
                else
                {
                    returnStr[i] = tmpStr[i - index];
                }
            }

            //bool tmp = true;
            //PrintArr(tmp, returnStr);
            return returnStr;
        }
        else
        {
            //bool tmp = false;
            Console.WriteLine("Invalid input parameters.");
            //PrintArr(tmp, arrStr);
            return arrStr;
        }
    }

    private static void PrintArr(string[] finalStr)
    {
        bool tmp = true;
        if (tmp)
        {
            Console.Write("[");
            for (int i = 0; i < finalStr.Count(); i++)
            {
                if (i != finalStr.Count() - 1)
                {
                    Console.Write("{0}, ", finalStr[i]);
                }
                else
                {
                    Console.Write("{0}", finalStr[i]);
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
        //else
        //{
        //    Console.WriteLine("keep the collection unchanged");
        //}
    }
}