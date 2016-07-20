namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserLogs
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> usersLogsDictionary = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] inputStr = Console.ReadLine().Split();
                if (inputStr[0] == "end")
                {
                    break;
                }
                string ip = inputStr[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
                string user = inputStr[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (!usersLogsDictionary.ContainsKey(user))
                {
                    usersLogsDictionary.Add(user,new Dictionary<string, int>());
                }
                if (!usersLogsDictionary[user].ContainsKey(ip))
                {
                    usersLogsDictionary[user].Add(ip,0);
                }
                usersLogsDictionary[user][ip]++;
            }
            List<string> usersList = new List<string>(usersLogsDictionary.Keys);
            usersList.Sort();
            for (int i = 0; i < usersList.Count; i++)
            {
                Console.WriteLine($"{usersList[i]}:");
                StringBuilder ipsStr = new StringBuilder();
                foreach (KeyValuePair<string, int> ips in usersLogsDictionary[usersList[i]])
                {
                    ipsStr.Append($"{ips.Key} => {ips.Value}, ");
                }
                ipsStr.Remove(ipsStr.Length - 2, 2);
                ipsStr.Append(".");
                Console.WriteLine(ipsStr);
            }
        }
    }
}
