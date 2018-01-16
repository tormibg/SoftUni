using System.Collections.Generic;
using System.Linq;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Log;

namespace CarDealer.Services
{
    public class LogsService : Service
    {
        public LogsAllPageVm GetAllLogsPageVm(string username, int? page)
        {
            var currentPage = 1;
            if (page != null)
            {
                currentPage = page.Value;
            }

            IEnumerable<Log> logs;
            if (username != null)
            {
                logs = this.Context.Logs.Where(l => l.User.Username == username);
            }
            else
            {
                logs = this.Context.Logs;
            }

            int allLogPageCount = logs.Count() / 20 + (logs.Count() % 20 == 0 ? 0 : 1);
            int logsToTake = 20;
            if (allLogPageCount == currentPage)
            {
                logsToTake = logs.Count() % 20 == 0 ? 20 : logs.Count() % 20;
            }
            logs.Skip((currentPage - 1) * 20).Take(logsToTake);
            List<LogAllVm> logsVM = new List<LogAllVm>();
            foreach (var log in logs)
            {
                logsVM.Add(new LogAllVm()
                {
                    Operation = log.Operation,
                    ModifiedAt = log.ModifiedAt,
                    ModfiedTable = log.ModifiedTableName,
                    UserName = log.User.Username
                });
            }
            LogsAllPageVm vms = new LogsAllPageVm()
            {
                Logs = logsVM,
                CurrentPage = currentPage,
                TotalNumberOfPages = allLogPageCount,
                WantedUserName = username
            };

            return vms;
        }

        public void DeleteAllLogs()
        {
            this.Context.Logs.RemoveRange(this.Context.Logs);
            this.Context.SaveChanges();
        }
    }
}