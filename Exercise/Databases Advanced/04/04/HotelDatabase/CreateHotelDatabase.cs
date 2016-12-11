using System.Linq;

namespace HotelDatabase
{
    class CreateHotelDatabase
    {
        static void Main()
        {
            var context = new HotelContext();
            context.Database.Initialize(true);
            context.Employees.Count();
        }
    }
}
