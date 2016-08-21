using System;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (String.Compare(input, endCommand, StringComparison.Ordinal) == 0)
                {
                    return;
                }
                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}
