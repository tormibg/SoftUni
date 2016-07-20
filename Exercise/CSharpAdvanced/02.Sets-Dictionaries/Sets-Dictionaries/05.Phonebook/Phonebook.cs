namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            string inputStr = Console.ReadLine();
            List<string> commandsStrings = new List<string>();
            Dictionary<string,string> phoneBookDictionary = new Dictionary<string, string>();

            while (inputStr != "search")
            {
                AddNameToDictionary(inputStr, phoneBookDictionary);
                inputStr = Console.ReadLine();
            }
            inputStr = Console.ReadLine();
            while (inputStr != "stop")
            {
                GetNameFromDictionary(inputStr, phoneBookDictionary);
                inputStr = Console.ReadLine();
            }
        }

        private static void GetNameFromDictionary(string name, Dictionary<string, string> phoneBookDictionary)
        {
            if (phoneBookDictionary.ContainsKey(name))
            {
                Console.WriteLine($"{name} -> {phoneBookDictionary[name]}");
            }
            else
            {
                Console.WriteLine($"Contact {name} does not exist.");
            }
        }

        private static void AddNameToDictionary(string commandsString, Dictionary<string, string> phoneBookDictionary)
        {
            string[] inputCommands = commandsString.Split(new char[] { '-' });
            string name = inputCommands[0];
            string tel = inputCommands[1];
            if (!phoneBookDictionary.ContainsKey(name))
            {
                phoneBookDictionary.Add(name,"");
            }
            phoneBookDictionary[name] = tel;
        }
    }
}
