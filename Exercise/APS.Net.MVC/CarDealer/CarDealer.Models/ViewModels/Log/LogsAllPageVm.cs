using System.Collections.Generic;

namespace CarDealer.Models.ViewModels.Log
{
    public class LogsAllPageVm
    {
        public int CurrentPage { get; set; }

        public int TotalNumberOfPages { get; set; }

        public IEnumerable<LogAllVm> Logs { get; set; }

        public string WantedUserName { get; set; }
    }
}