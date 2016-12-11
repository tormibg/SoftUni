using System;
using System.Data.Entity.Validation;
using VehiclesInfoData;

namespace VehiclesInfoClient
{
    class Program
    {
        static void Main()
        {
            try
            {
                var context = new VehiclesInfoContex();
                context.Database.Initialize(true);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
