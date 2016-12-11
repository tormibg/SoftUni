using System;
using System.Linq;
using InheritCars.Models;

namespace InheritCars
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car()
            {
                Model = "Lada",
                Price = 2000
            };

            var car2 = new BatMobil()
            {
                Model = "iBat",
                Price = 4000,
                BatExtra = "Extra"
            };

            var car3 = new LuxiriosCar()
            {
                Model = "BMW",
                Price = 5000,
                NumberOfWomen = 10
            };

            var context = new CarsContext();
            context.Database.Initialize(true);

            //context.Cars.Add(car1);
            //context.Cars.Add(car2);
            //context.Cars.Add(car3);

            //context.SaveChanges();

            //var abv = context.Cars.OfType<BatMobil>().First();
            //Console.WriteLine(abv.BatExtra);
        }
    }
}
