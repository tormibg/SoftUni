namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            Dictionary<string, string> nameAndEmailsDictionary = new Dictionary<string, string>();
            while (true)
            {
                string inputName = Console.ReadLine();
                if (inputName == "stop")
                {
                    break;
                }
                string inputEmail = Console.ReadLine();
                string tmpStr = inputEmail.Substring(inputEmail.Length - 2).ToLower();
                if (tmpStr != "us" && tmpStr != "uk")
                {
                    if (!nameAndEmailsDictionary.ContainsKey(inputName))
                    {
                        nameAndEmailsDictionary.Add(inputName,"");
                    }
                    nameAndEmailsDictionary[inputName] = inputEmail;
                }
            }
            foreach (KeyValuePair<string, string> keyValuePair in nameAndEmailsDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
