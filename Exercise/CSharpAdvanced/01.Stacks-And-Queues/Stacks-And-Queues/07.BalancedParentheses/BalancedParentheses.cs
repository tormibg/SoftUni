namespace _07.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            char[] inputChars = Console.ReadLine().ToCharArray();
            if (inputChars.Length % 2 != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Stack<char> stack = new Stack<char>();
                bool isOK = true;
                foreach (char c in inputChars)
                {
                    if (c == '{' || c == '[' || c == '(')
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        char currChar = stack.Pop();
                        switch (c)
                        {
                            case '}':
                                if (currChar != '{')
                                {
                                    isOK = false;
                                }
                                break;
                            case ']':
                                if (currChar != '[')
                                {
                                    isOK = false;
                                }
                                break;
                            case ')':
                                if (currChar != '(')
                                {
                                    isOK = false;
                                }
                                break;
                        }
                        if (!isOK)
                        {
                            break;
                        }
                    }
                }
                if (isOK)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

            }
        }
    }
}
