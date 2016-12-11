using System;
using System.Data.Entity.Validation;
using System.Linq;
using GringottsDatabase.Models;


namespace GringottsDatabase
{
    class Program
    {
        static void Main()
        {
            var dumbledore = new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false
            };

            var context = new WizardDepositsContext();

            try
            {
                //context.WizardDepositses.Add(dumbledore);
                context.WizardDepositses.Count();
                context.SaveChanges();
            }
            catch (DbEntityValidationException edb)
            {
                foreach (var eve in edb.EntityValidationErrors)
                {
                    foreach (var eveValidationError in eve.ValidationErrors)
                    {
                        Console.WriteLine(eveValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
