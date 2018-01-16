using System;
using CarDealer.Data;
using CarDealer.Models.EntityModels;

namespace CarDealer.Services
{
    public class Service
    {
        private CarDealerContext context;

        protected Service()
        {
            this.context = new CarDealerContext();
        }

        protected CarDealerContext Context => this.context;

        protected void AddLog(int userId, OperationLog operation, string table)
        {
            User user = this.Context.Users.Find(userId);
            Log log = new Log()
            {
                User = user,
                ModifiedAt = DateTime.Now,
                ModifiedTableName = table,
                Operation = operation
            };
            this.Context.Logs.Add(log);
            this.Context.SaveChanges();
        }
    }
}