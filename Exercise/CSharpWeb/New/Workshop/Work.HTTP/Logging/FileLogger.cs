using System.IO;

namespace Work.HTTP.Logging
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllLines("log.txt", new[] { message });
        }
    }
}