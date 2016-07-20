namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LogsAggregator
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, uint>> usersLogs = new Dictionary<string, Dictionary<string, uint>>();
            uint numberLines = uint.Parse(Console.ReadLine());
            for (int i = 0; i < numberLines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string ip = inputArgs[0];
                string userName = inputArgs[1];
                uint duration = uint.Parse(inputArgs[2]);
                if (!usersLogs.ContainsKey(userName))
                {
                    usersLogs.Add(userName, new Dictionary<string, uint>());
                }
                if (!usersLogs[userName].ContainsKey(ip))
                {
                    usersLogs[userName].Add(ip, 0);
                }
                usersLogs[userName][ip] += duration;
            }
            var orderUsersLogs = usersLogs.OrderBy(x => x.Key);
            foreach (var logsInfo in orderUsersLogs)
            {
                StringBuilder userLog = new StringBuilder();
                userLog.Append($"{logsInfo.Key}: ");
                long totalDuration = logsInfo.Value.Sum(x => x.Value);
                userLog.Append($"{totalDuration} ");
                var sortedIps = logsInfo.Value.OrderBy(x => x.Key).Select(x => x.Key);
                userLog.Append($"[{String.Join(", ", sortedIps)}]");
                Console.WriteLine(userLog);
            }
        }
    }
}
