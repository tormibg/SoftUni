namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            string resultStr = String.Empty;
            int numberCommands = int.Parse(Console.ReadLine());
            Stack<string> commandsStack = new Stack<string>();
            for (int i = 0; i < numberCommands; i++)
            {
                string[] inputArg = Console.ReadLine().Split();
                switch (inputArg[0])
                {
                    case "1":
                        resultStr = AppendText(inputArg[1], resultStr, commandsStack);
                        /*Console.WriteLine(resultStr);*/
                        break;
                    case "2":
                        resultStr = EraseText(int.Parse(inputArg[1]), resultStr, commandsStack);
                        break;
                    case "3":
                        ReturnsElement(int.Parse(inputArg[1]), resultStr);
                        break;
                    case "4":
                        resultStr = UndoText(commandsStack);
                        break;
                }
            }
        }

        private static string UndoText(Stack<string> commandsStack)
        {
            return commandsStack.Pop();
        }

        private static void ReturnsElement(int i, string resultStr)
        {
            Console.WriteLine(resultStr[i-1]);
        }

        private static string EraseText(int i, string resultStr, Stack<string> commandsStack)
        {
            commandsStack.Push(resultStr);
            return resultStr.Remove(resultStr.Length - i);
        }

        private static string AppendText(string s, string resultStr, Stack<string> commandsStack)
        {
            commandsStack.Push(resultStr);
            return resultStr + s;
        }
    }
}
