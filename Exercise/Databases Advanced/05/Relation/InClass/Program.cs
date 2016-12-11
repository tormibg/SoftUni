using InClass.Models;

namespace InClass
{
    class Program
    {
        static void Main()
        {
            var context = new WorldContext();
            context.Database.Initialize(true);

            context.Students.Add(new Student() { Name = "Ilia", StudentAddress = new StudentAddress() { Address = "Niakade tam" } });

            context.SaveChanges();
        }
    }
}
